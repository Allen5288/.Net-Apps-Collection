using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _01___WebApiMooc1.Controllers
{
    /// <summary>
    /// File Controller - Demonstrates file upload/download operations
    /// - File upload with validation
    /// - File download with different content types
    /// - Streaming large files
    /// - File metadata operations
    /// Route: /api/file
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly string _uploadPath;
        private static List<FileMetadata> _fileMetadata = new List<FileMetadata>();

        public FileController(ILogger<FileController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _uploadPath = Path.Combine(environment.ContentRootPath, "uploads");
            
            // Ensure upload directory exists
            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        /// <summary>
        /// POST: api/file/upload
        /// Demonstrates single file upload with validation
        /// </summary>
        /// <param name="file">File to upload</param>
        /// <param name="description">Optional file description</param>
        /// <returns>Upload result</returns>
        [HttpPost("upload")]
        [ProducesResponseType(typeof(FileUploadResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RequestSizeLimit(10 * 1024 * 1024)] // 10MB limit
        public async Task<ActionResult<FileUploadResult>> UploadFile(
            IFormFile file, 
            [FromForm] string? description = null)
        {
            // Validate file
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided or file is empty");
            }

            // File size validation (additional check)
            if (file.Length > 10 * 1024 * 1024) // 10MB
            {
                return BadRequest("File size exceeds 10MB limit");
            }

            // File type validation
            var allowedExtensions = new[] { ".txt", ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest($"File type '{fileExtension}' is not allowed. Allowed types: {string.Join(", ", allowedExtensions)}");
            }

            try
            {
                // Generate unique filename
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(_uploadPath, uniqueFileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Create metadata
                var metadata = new FileMetadata
                {
                    Id = Guid.NewGuid(),
                    OriginalFileName = file.FileName,
                    StoredFileName = uniqueFileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    Description = description,
                    UploadedAt = DateTime.UtcNow,
                    FilePath = filePath
                };

                _fileMetadata.Add(metadata);

                _logger.LogInformation("File uploaded: {originalName} -> {storedName}, Size: {size} bytes",
                    file.FileName, uniqueFileName, file.Length);

                var result = new FileUploadResult
                {
                    FileId = metadata.Id,
                    OriginalFileName = metadata.OriginalFileName,
                    Size = metadata.Size,
                    ContentType = metadata.ContentType,
                    UploadedAt = metadata.UploadedAt
                };

                return CreatedAtAction(nameof(GetFileInfo), new { id = metadata.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file: {fileName}", file.FileName);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading file");
            }
        }

        /// <summary>
        /// POST: api/file/upload-multiple
        /// Demonstrates multiple file upload
        /// </summary>
        /// <param name="files">Files to upload</param>
        /// <returns>Upload results</returns>
        [HttpPost("upload-multiple")]
        [ProducesResponseType(typeof(MultipleFileUploadResult), StatusCodes.Status207MultiStatus)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RequestSizeLimit(50 * 1024 * 1024)] // 50MB total limit
        public async Task<ActionResult<MultipleFileUploadResult>> UploadMultipleFiles(List<IFormFile> files)
        {
            if (files == null || !files.Any())
            {
                return BadRequest("No files provided");
            }

            if (files.Count > 10)
            {
                return BadRequest("Maximum 10 files allowed per request");
            }

            var result = new MultipleFileUploadResult();

            foreach (var file in files)
            {
                try
                {
                    // Use the same validation logic as single upload
                    var singleUploadResult = await UploadFile(file);
                    
                    if (singleUploadResult.Result is CreatedAtActionResult createdResult)
                    {
                        result.SuccessfulUploads.Add((FileUploadResult)createdResult.Value!);
                    }
                    else
                    {
                        result.FailedUploads.Add(new FileUploadError
                        {
                            FileName = file.FileName,
                            Error = "Upload failed"
                        });
                    }
                }
                catch (Exception ex)
                {
                    result.FailedUploads.Add(new FileUploadError
                    {
                        FileName = file.FileName,
                        Error = ex.Message
                    });
                }
            }

            _logger.LogInformation("Multiple file upload completed: {successful} successful, {failed} failed",
                result.SuccessfulUploads.Count, result.FailedUploads.Count);

            return StatusCode(StatusCodes.Status207MultiStatus, result);
        }

        /// <summary>
        /// GET: api/file/{id}
        /// Downloads a file by ID
        /// </summary>
        /// <param name="id">File ID</param>
        /// <param name="download">Force download (attachment) vs inline display</param>
        /// <returns>File content</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DownloadFile(Guid id, [FromQuery] bool download = true)
        {
            var metadata = _fileMetadata.FirstOrDefault(f => f.Id == id);
            if (metadata == null)
            {
                return NotFound($"File with ID {id} not found");
            }

            if (!System.IO.File.Exists(metadata.FilePath))
            {
                _logger.LogWarning("File not found on disk: {filePath}", metadata.FilePath);
                return NotFound("File not found on disk");
            }

            try
            {
                var fileBytes = await System.IO.File.ReadAllBytesAsync(metadata.FilePath);
                
                _logger.LogInformation("File downloaded: {fileName} (ID: {fileId})", 
                    metadata.OriginalFileName, metadata.Id);

                // Set content disposition based on download parameter
                var contentDisposition = download ? "attachment" : "inline";
                Response.Headers.Add("Content-Disposition", $"{contentDisposition}; filename=\"{metadata.OriginalFileName}\"");

                return File(fileBytes, metadata.ContentType, metadata.OriginalFileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error downloading file: {fileId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error downloading file");
            }
        }

        /// <summary>
        /// GET: api/file/{id}/stream
        /// Streams a file for large file downloads
        /// </summary>
        /// <param name="id">File ID</param>
        /// <returns>Streamed file content</returns>
        [HttpGet("{id:guid}/stream")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult StreamFile(Guid id)
        {
            var metadata = _fileMetadata.FirstOrDefault(f => f.Id == id);
            if (metadata == null)
            {
                return NotFound($"File with ID {id} not found");
            }

            if (!System.IO.File.Exists(metadata.FilePath))
            {
                return NotFound("File not found on disk");
            }

            try
            {
                var fileStream = new FileStream(metadata.FilePath, FileMode.Open, FileAccess.Read);
                
                _logger.LogInformation("File streaming started: {fileName} (ID: {fileId})", 
                    metadata.OriginalFileName, metadata.Id);

                // Add headers for streaming
                Response.Headers.Add("Content-Length", metadata.Size.ToString());
                Response.Headers.Add("Accept-Ranges", "bytes");
                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{metadata.OriginalFileName}\"");

                return File(fileStream, metadata.ContentType, metadata.OriginalFileName, enableRangeProcessing: true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error streaming file: {fileId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error streaming file");
            }
        }

        /// <summary>
        /// GET: api/file/{id}/info
        /// Gets file metadata without downloading the file
        /// </summary>
        /// <param name="id">File ID</param>
        /// <returns>File metadata</returns>
        [HttpGet("{id:guid}/info")]
        [ProducesResponseType(typeof(FileInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FileInfoResponse> GetFileInfo(Guid id)
        {
            var metadata = _fileMetadata.FirstOrDefault(f => f.Id == id);
            if (metadata == null)
            {
                return NotFound($"File with ID {id} not found");
            }

            var response = new FileInfoResponse
            {
                Id = metadata.Id,
                OriginalFileName = metadata.OriginalFileName,
                ContentType = metadata.ContentType,
                Size = metadata.Size,
                Description = metadata.Description,
                UploadedAt = metadata.UploadedAt,
                Exists = System.IO.File.Exists(metadata.FilePath)
            };

            return Ok(response);
        }

        /// <summary>
        /// GET: api/file
        /// Lists all uploaded files with pagination
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Items per page</param>
        /// <param name="contentType">Filter by content type</param>
        /// <returns>Paginated file list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FileInfoResponse>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FileInfoResponse>> GetFiles(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? contentType = null)
        {
            var query = _fileMetadata.AsQueryable();

            if (!string.IsNullOrEmpty(contentType))
            {
                query = query.Where(f => f.ContentType.Contains(contentType, StringComparison.OrdinalIgnoreCase));
            }

            var totalCount = query.Count();
            var files = query
                .OrderByDescending(f => f.UploadedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new FileInfoResponse
                {
                    Id = f.Id,
                    OriginalFileName = f.OriginalFileName,
                    ContentType = f.ContentType,
                    Size = f.Size,
                    Description = f.Description,
                    UploadedAt = f.UploadedAt,
                    Exists = System.IO.File.Exists(f.FilePath)
                })
                .ToList();

            // Add pagination headers
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            Response.Headers.Add("X-Page", page.ToString());
            Response.Headers.Add("X-Page-Size", pageSize.ToString());
            Response.Headers.Add("X-Total-Pages", ((int)Math.Ceiling((double)totalCount / pageSize)).ToString());

            return Ok(files);
        }

        /// <summary>
        /// DELETE: api/file/{id}
        /// Deletes a file and its metadata
        /// </summary>
        /// <param name="id">File ID</param>
        /// <returns>Deletion result</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteFile(Guid id)
        {
            var metadata = _fileMetadata.FirstOrDefault(f => f.Id == id);
            if (metadata == null)
            {
                return NotFound($"File with ID {id} not found");
            }

            try
            {
                // Delete physical file if it exists
                if (System.IO.File.Exists(metadata.FilePath))
                {
                    System.IO.File.Delete(metadata.FilePath);
                }

                // Remove metadata
                _fileMetadata.Remove(metadata);

                _logger.LogInformation("File deleted: {fileName} (ID: {fileId})", 
                    metadata.OriginalFileName, metadata.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {fileId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting file");
            }
        }
    }

    /// <summary>
    /// File metadata model
    /// </summary>
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long Size { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }

    /// <summary>
    /// File upload result model
    /// </summary>
    public class FileUploadResult
    {
        public Guid FileId { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public long Size { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }

    /// <summary>
    /// Multiple file upload result model
    /// </summary>
    public class MultipleFileUploadResult
    {
        public List<FileUploadResult> SuccessfulUploads { get; set; } = new List<FileUploadResult>();
        public List<FileUploadError> FailedUploads { get; set; } = new List<FileUploadError>();
    }

    /// <summary>
    /// File upload error model
    /// </summary>
    public class FileUploadError
    {
        public string FileName { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }

    /// <summary>
    /// File info response model
    /// </summary>
    public class FileInfoResponse
    {
        public Guid Id { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long Size { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public bool Exists { get; set; }
    }
}
