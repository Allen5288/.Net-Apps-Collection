using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _01___WebApiMooc1.Controllers
{
    /// <summary>
    /// Product Controller - Demonstrates advanced Web API features
    /// - Content negotiation (JSON/XML)
    /// - Custom action results
    /// - Action filters
    /// - Model binding from different sources
    /// Route: /api/product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")] // Support both JSON and XML
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics", Stock = 50 },
            new Product { Id = 2, Name = "Mouse", Price = 29.99m, Category = "Electronics", Stock = 100 },
            new Product { Id = 3, Name = "Book", Price = 19.99m, Category = "Education", Stock = 25 },
            new Product { Id = 4, Name = "Headphones", Price = 79.99m, Category = "Electronics", Stock = 75 }
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET: api/product
        /// Demonstrates content negotiation - can return JSON or XML based on Accept header
        /// Example: Accept: application/xml
        /// </summary>
        /// <param name="category">Filter by category</param>
        /// <param name="minPrice">Minimum price filter</param>
        /// <param name="maxPrice">Maximum price filter</param>
        /// <param name="sortBy">Sort field (name, price, stock)</param>
        /// <param name="sortDesc">Sort descending</param>
        /// <returns>Filtered and sorted products</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> GetProducts(
            [FromQuery] string? category = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] string sortBy = "name",
            [FromQuery] bool sortDesc = false)
        {
            _logger.LogInformation("Getting products - Category: {category}, MinPrice: {minPrice}, MaxPrice: {maxPrice}", 
                category, minPrice, maxPrice);

            var query = _products.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            // Apply sorting
            query = sortBy.ToLower() switch
            {
                "price" => sortDesc ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                "stock" => sortDesc ? query.OrderByDescending(p => p.Stock) : query.OrderBy(p => p.Stock),
                "category" => sortDesc ? query.OrderByDescending(p => p.Category) : query.OrderBy(p => p.Category),
                _ => sortDesc ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name)
            };

            var result = query.ToList();
            
            // Add custom response headers
            Response.Headers.Add("X-Total-Products", result.Count.ToString());
            Response.Headers.Add("X-Filter-Applied", (!string.IsNullOrEmpty(category) || minPrice.HasValue || maxPrice.HasValue).ToString());

            return Ok(result);
        }

        /// <summary>
        /// GET: api/product/{id}
        /// Demonstrates custom response types and error handling
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product details or appropriate error</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<Product> GetProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Product ID must be greater than 0");
            }

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            // Add custom header with product category
            Response.Headers.Add("X-Product-Category", product.Category);
            
            return Ok(product);
        }

        /// <summary>
        /// POST: api/product
        /// Demonstrates model binding and validation
        /// </summary>
        /// <param name="product">Product data from request body</param>
        /// <returns>Created product</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<Product> CreateProduct([FromBody] CreateProductRequest product)
        {
            // Model validation is automatic with [ApiController] attribute
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check for duplicate product names
            if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("Name", "Product name already exists");
                return BadRequest(ModelState);
            }

            var newProduct = new Product
            {
                Id = _products.Max(p => p.Id) + 1,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock
            };

            _products.Add(newProduct);

            _logger.LogInformation("Created product: {productName} with ID: {productId}", newProduct.Name, newProduct.Id);

            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        /// <summary>
        /// PUT: api/product/{id}/stock
        /// Demonstrates binding from multiple sources (route, body, query)
        /// </summary>
        /// <param name="id">Product ID from route</param>
        /// <param name="stockUpdate">Stock update info from body</param>
        /// <param name="reason">Update reason from query</param>
        /// <returns>Updated product</returns>
        [HttpPut("{id:int}/stock")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> UpdateStock(
            [FromRoute] int id,                    // From URL path
            [FromBody] StockUpdateRequest stockUpdate,  // From request body
            [FromQuery] string? reason = null)     // From query string
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            if (stockUpdate.NewStock < 0)
            {
                return BadRequest("Stock cannot be negative");
            }

            var oldStock = product.Stock;
            product.Stock = stockUpdate.NewStock;

            _logger.LogInformation("Updated stock for product {productId} from {oldStock} to {newStock}. Reason: {reason}",
                id, oldStock, stockUpdate.NewStock, reason ?? "Not specified");

            // Add audit information to response header
            Response.Headers.Add("X-Stock-Change", (stockUpdate.NewStock - oldStock).ToString());
            Response.Headers.Add("X-Update-Reason", reason ?? "Not specified");

            return Ok(product);
        }

        /// <summary>
        /// DELETE: api/product/{id}
        /// Demonstrates conditional deletion with custom headers
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="force">Force deletion even if stock > 0</param>
        /// <returns>No content or error</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult DeleteProduct(int id, [FromQuery] bool force = false)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            // Business rule: Don't delete products with stock unless forced
            if (product.Stock > 0 && !force)
            {
                return Conflict(new
                {
                    message = "Cannot delete product with stock > 0",
                    currentStock = product.Stock,
                    hint = "Use ?force=true to override this restriction"
                });
            }

            _products.Remove(product);

            _logger.LogWarning("Deleted product: {productName} (ID: {productId}), Stock was: {stock}, Forced: {forced}",
                product.Name, product.Id, product.Stock, force);

            // Add custom header indicating what was deleted
            Response.Headers.Add("X-Deleted-Product", product.Name);
            
            return NoContent();
        }

        /// <summary>
        /// GET: api/product/categories
        /// Demonstrates returning custom data structures
        /// </summary>
        /// <returns>Product categories with counts</returns>
        [HttpGet("categories")]
        [ProducesResponseType(typeof(IEnumerable<CategorySummary>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CategorySummary>> GetCategories()
        {
            var categories = _products
                .GroupBy(p => p.Category)
                .Select(g => new CategorySummary
                {
                    Name = g.Key,
                    ProductCount = g.Count(),
                    TotalValue = g.Sum(p => p.Price * p.Stock),
                    AveragePrice = g.Average(p => p.Price)
                })
                .OrderBy(c => c.Name)
                .ToList();

            return Ok(categories);
        }

        /// <summary>
        /// POST: api/product/bulk
        /// Demonstrates bulk operations with transaction-like behavior
        /// </summary>
        /// <param name="products">List of products to create</param>
        /// <returns>Created products or error details</returns>
        [HttpPost("bulk")]
        [ProducesResponseType(typeof(BulkCreateResult), StatusCodes.Status207MultiStatus)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BulkCreateResult> BulkCreateProducts([FromBody] List<CreateProductRequest> products)
        {
            if (products == null || !products.Any())
            {
                return BadRequest("No products provided");
            }

            var result = new BulkCreateResult();
            var nextId = _products.Max(p => p.Id) + 1;

            foreach (var productRequest in products)
            {
                try
                {
                    // Validate each product
                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(productRequest);
                    
                    if (!Validator.TryValidateObject(productRequest, validationContext, validationResults, true))
                    {
                        result.Errors.Add(new BulkError
                        {
                            ProductName = productRequest.Name,
                            Errors = validationResults.Select(v => v.ErrorMessage ?? "Validation error").ToList()
                        });
                        continue;
                    }

                    // Check for duplicate names
                    if (_products.Any(p => p.Name.Equals(productRequest.Name, StringComparison.OrdinalIgnoreCase)) ||
                        result.CreatedProducts.Any(p => p.Name.Equals(productRequest.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        result.Errors.Add(new BulkError
                        {
                            ProductName = productRequest.Name,
                            Errors = new List<string> { "Product name already exists" }
                        });
                        continue;
                    }

                    var newProduct = new Product
                    {
                        Id = nextId++,
                        Name = productRequest.Name,
                        Price = productRequest.Price,
                        Category = productRequest.Category,
                        Stock = productRequest.Stock
                    };

                    _products.Add(newProduct);
                    result.CreatedProducts.Add(newProduct);
                }
                catch (Exception ex)
                {
                    result.Errors.Add(new BulkError
                    {
                        ProductName = productRequest.Name,
                        Errors = new List<string> { ex.Message }
                    });
                }
            }

            _logger.LogInformation("Bulk create completed: {created} created, {errors} errors",
                result.CreatedProducts.Count, result.Errors.Count);

            // Return 207 Multi-Status for partial success scenarios
            return StatusCode(StatusCodes.Status207MultiStatus, result);
        }
    }

    /// <summary>
    /// Product model for responses
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Stock { get; set; }
    }

    /// <summary>
    /// Request model for creating products
    /// </summary>
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category must not exceed 50 characters")]
        public string Category { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")]
        public int Stock { get; set; }
    }

    /// <summary>
    /// Request model for stock updates
    /// </summary>
    public class StockUpdateRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")]
        public int NewStock { get; set; }
    }

    /// <summary>
    /// Category summary model
    /// </summary>
    public class CategorySummary
    {
        public string Name { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public decimal TotalValue { get; set; }
        public decimal AveragePrice { get; set; }
    }

    /// <summary>
    /// Bulk operation result model
    /// </summary>
    public class BulkCreateResult
    {
        public List<Product> CreatedProducts { get; set; } = new List<Product>();
        public List<BulkError> Errors { get; set; } = new List<BulkError>();
    }

    /// <summary>
    /// Bulk operation error model
    /// </summary>
    public class BulkError
    {
        public string ProductName { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
