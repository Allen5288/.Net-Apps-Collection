using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Diagnostics;

namespace _01___WebApiMooc1.Controllers
{
    /// <summary>
    /// Analytics Controller - Demonstrates advanced API patterns
    /// - Async operations with cancellation tokens
    /// - Custom middleware integration
    /// - Complex query parameters
    /// - Custom response formats
    /// - Health check endpoints
    /// Route: /api/analytics
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILogger<AnalyticsController> _logger;
        private static readonly List<AnalyticsEvent> _events = new List<AnalyticsEvent>();

        public AnalyticsController(ILogger<AnalyticsController> logger)
        {
            _logger = logger;
            
            // Seed some sample data
            if (!_events.Any())
            {
                SeedSampleData();
            }
        }

        /// <summary>
        /// POST: api/analytics/event
        /// Records an analytics event
        /// Demonstrates async operations and custom validation
        /// </summary>
        /// <param name="eventData">Event data to record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Event recording result</returns>
        [HttpPost("event")]
        [ProducesResponseType(typeof(EventRecordResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EventRecordResult>> RecordEvent(
            [FromBody] AnalyticsEventRequest eventData,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Simulate async processing
                await Task.Delay(100, cancellationToken);

                // Validate event data
                if (string.IsNullOrWhiteSpace(eventData.EventType))
                {
                    return BadRequest("EventType is required");
                }

                if (string.IsNullOrWhiteSpace(eventData.UserId))
                {
                    return BadRequest("UserId is required");
                }

                // Create analytics event
                var analyticsEvent = new AnalyticsEvent
                {
                    Id = Guid.NewGuid(),
                    EventType = eventData.EventType,
                    UserId = eventData.UserId,
                    SessionId = eventData.SessionId ?? Guid.NewGuid().ToString(),
                    Properties = eventData.Properties ?? new Dictionary<string, object>(),
                    Timestamp = DateTime.UtcNow,
                    IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    UserAgent = Request.Headers["User-Agent"].ToString()
                };

                // Simulate async database save
                await Task.Delay(50, cancellationToken);
                _events.Add(analyticsEvent);

                _logger.LogInformation("Analytics event recorded: {eventType} for user {userId}", 
                    analyticsEvent.EventType, analyticsEvent.UserId);

                var result = new EventRecordResult
                {
                    EventId = analyticsEvent.Id,
                    Timestamp = analyticsEvent.Timestamp,
                    Status = "recorded"
                };

                return CreatedAtAction(nameof(GetEvent), new { id = analyticsEvent.Id }, result);
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Event recording cancelled");
                return StatusCode(StatusCodes.Status408RequestTimeout, "Request was cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording analytics event");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recording event");
            }
        }

        /// <summary>
        /// GET: api/analytics/event/{id}
        /// Retrieves a specific analytics event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>Event details</returns>
        [HttpGet("event/{id:guid}")]
        [ProducesResponseType(typeof(AnalyticsEvent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AnalyticsEvent> GetEvent(Guid id)
        {
            var analyticsEvent = _events.FirstOrDefault(e => e.Id == id);
            if (analyticsEvent == null)
            {
                return NotFound($"Event with ID {id} not found");
            }

            return Ok(analyticsEvent);
        }

        /// <summary>
        /// GET: api/analytics/events
        /// Retrieves analytics events with complex filtering
        /// Demonstrates complex query parameter handling
        /// </summary>
        /// <param name="filter">Event filter parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Filtered events</returns>
        [HttpGet("events")]
        [ProducesResponseType(typeof(EventQueryResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<EventQueryResult>> GetEvents(
            [FromQuery] EventFilter filter,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Simulate async data processing
                await Task.Delay(200, cancellationToken);

                var query = _events.AsQueryable();

                // Apply filters
                if (!string.IsNullOrEmpty(filter.UserId))
                {
                    query = query.Where(e => e.UserId == filter.UserId);
                }

                if (!string.IsNullOrEmpty(filter.EventType))
                {
                    query = query.Where(e => e.EventType.Contains(filter.EventType, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(filter.SessionId))
                {
                    query = query.Where(e => e.SessionId == filter.SessionId);
                }

                if (filter.StartDate.HasValue)
                {
                    query = query.Where(e => e.Timestamp >= filter.StartDate.Value);
                }

                if (filter.EndDate.HasValue)
                {
                    query = query.Where(e => e.Timestamp <= filter.EndDate.Value);
                }

                // Apply sorting
                query = filter.SortBy?.ToLower() switch
                {
                    "eventtype" => filter.SortDesc ? query.OrderByDescending(e => e.EventType) : query.OrderBy(e => e.EventType),
                    "userid" => filter.SortDesc ? query.OrderByDescending(e => e.UserId) : query.OrderBy(e => e.UserId),
                    "timestamp" => filter.SortDesc ? query.OrderByDescending(e => e.Timestamp) : query.OrderBy(e => e.Timestamp),
                    _ => query.OrderByDescending(e => e.Timestamp)
                };

                var totalCount = query.Count();
                var events = query
                    .Skip((filter.Page - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                var result = new EventQueryResult
                {
                    Events = events,
                    TotalCount = totalCount,
                    Page = filter.Page,
                    PageSize = filter.PageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / filter.PageSize)
                };

                // Add response headers
                Response.Headers.Add("X-Total-Count", totalCount.ToString());
                Response.Headers.Add("X-Filter-Applied", HasActiveFilters(filter).ToString());

                return Ok(result);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "Request was cancelled");
            }
        }

        /// <summary>
        /// GET: api/analytics/dashboard
        /// Provides dashboard metrics
        /// Demonstrates complex data aggregation
        /// </summary>
        /// <param name="timeframe">Time frame for metrics (last24h, last7d, last30d)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Dashboard metrics</returns>
        [HttpGet("dashboard")]
        [ProducesResponseType(typeof(DashboardMetrics), StatusCodes.Status200OK)]
        public async Task<ActionResult<DashboardMetrics>> GetDashboardMetrics(
            [FromQuery] string timeframe = "last24h",
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Simulate async processing
                await Task.Delay(300, cancellationToken);

                var cutoffDate = timeframe.ToLower() switch
                {
                    "last24h" => DateTime.UtcNow.AddDays(-1),
                    "last7d" => DateTime.UtcNow.AddDays(-7),
                    "last30d" => DateTime.UtcNow.AddDays(-30),
                    _ => DateTime.UtcNow.AddDays(-1)
                };

                var filteredEvents = _events.Where(e => e.Timestamp >= cutoffDate).ToList();

                var metrics = new DashboardMetrics
                {
                    Timeframe = timeframe,
                    TotalEvents = filteredEvents.Count,
                    UniqueUsers = filteredEvents.Select(e => e.UserId).Distinct().Count(),
                    UniqueSessions = filteredEvents.Select(e => e.SessionId).Distinct().Count(),
                    EventTypeBreakdown = filteredEvents
                        .GroupBy(e => e.EventType)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    EventsPerHour = filteredEvents
                        .GroupBy(e => e.Timestamp.Hour)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    TopUsers = filteredEvents
                        .GroupBy(e => e.UserId)
                        .OrderByDescending(g => g.Count())
                        .Take(10)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    GeneratedAt = DateTime.UtcNow
                };

                _logger.LogInformation("Dashboard metrics generated for timeframe: {timeframe}", timeframe);
                
                // Cache control headers
                Response.Headers.Add("Cache-Control", "public, max-age=300"); // 5 minutes
                Response.Headers.Add("X-Generated-At", metrics.GeneratedAt.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                return Ok(metrics);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "Request was cancelled");
            }
        }

        /// <summary>
        /// GET: api/analytics/export
        /// Exports analytics data in various formats
        /// Demonstrates content negotiation and custom response formats
        /// </summary>
        /// <param name="format">Export format (json, csv, xml)</param>
        /// <param name="filter">Filter parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Exported data</returns>
        [HttpGet("export")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ExportData(
            [FromQuery] string format = "json",
            [FromQuery] EventFilter filter = null!,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Get filtered events
                var eventsResult = await GetEvents(filter ?? new EventFilter(), cancellationToken);
                if (eventsResult.Result is not OkObjectResult okResult)
                {
                    return BadRequest("Failed to retrieve events");
                }

                var eventQueryResult = (EventQueryResult)okResult.Value!;
                var events = eventQueryResult.Events;

                // Export in requested format
                return format.ToLower() switch
                {
                    "json" => await ExportAsJson(events, cancellationToken),
                    "csv" => await ExportAsCsv(events, cancellationToken),
                    "xml" => await ExportAsXml(events, cancellationToken),
                    _ => BadRequest($"Unsupported format: {format}. Supported formats: json, csv, xml")
                };
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "Export was cancelled");
            }
        }

        /// <summary>
        /// GET: api/analytics/health
        /// Health check endpoint
        /// Demonstrates health monitoring patterns
        /// </summary>
        /// <returns>Health status</returns>
        [HttpGet("health")]
        [ProducesResponseType(typeof(HealthStatus), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HealthStatus), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<HealthStatus> GetHealth()
        {
            var health = new HealthStatus
            {
                Status = "healthy",
                Timestamp = DateTime.UtcNow,
                Version = "1.0.0",
                Checks = new Dictionary<string, object>
                {
                    ["database"] = "connected",
                    ["memory"] = $"{GC.GetTotalMemory(false) / 1024 / 1024} MB",
                    ["events_count"] = _events.Count,
                    ["uptime"] = DateTime.UtcNow.Subtract(Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss")
                }
            };

            // Simulate health check logic
            if (_events.Count > 10000) // Example threshold
            {
                health.Status = "degraded";
                health.Checks["events_count"] = $"{_events.Count} (high)";
            }

            var statusCode = health.Status == "healthy" ? StatusCodes.Status200OK : StatusCodes.Status503ServiceUnavailable;
            return StatusCode(statusCode, health);
        }

        /// <summary>
        /// DELETE: api/analytics/events
        /// Bulk delete analytics events
        /// Demonstrates bulk operations with confirmation
        /// </summary>
        /// <param name="deleteRequest">Delete request parameters</param>
        /// <returns>Delete result</returns>
        [HttpDelete("events")]
        [ProducesResponseType(typeof(BulkDeleteResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BulkDeleteResult> BulkDeleteEvents([FromBody] BulkDeleteRequest deleteRequest)
        {
            if (deleteRequest.ConfirmationCode != "DELETE_EVENTS")
            {
                return BadRequest("Invalid confirmation code. Use 'DELETE_EVENTS' to confirm bulk deletion.");
            }

            var deletedCount = 0;
            var originalCount = _events.Count;

            if (deleteRequest.DeleteAll)
            {
                deletedCount = _events.Count;
                _events.Clear();
            }
            else
            {
                if (deleteRequest.OlderThan.HasValue)
                {
                    var toDelete = _events.Where(e => e.Timestamp < deleteRequest.OlderThan.Value).ToList();
                    deletedCount = toDelete.Count;
                    foreach (var evt in toDelete)
                    {
                        _events.Remove(evt);
                    }
                }

                if (!string.IsNullOrEmpty(deleteRequest.UserId))
                {
                    var toDelete = _events.Where(e => e.UserId == deleteRequest.UserId).ToList();
                    deletedCount += toDelete.Count;
                    foreach (var evt in toDelete)
                    {
                        _events.Remove(evt);
                    }
                }
            }

            _logger.LogWarning("Bulk delete performed: {deleted} events deleted out of {original}", 
                deletedCount, originalCount);

            var result = new BulkDeleteResult
            {
                DeletedCount = deletedCount,
                RemainingCount = _events.Count,
                OriginalCount = originalCount,
                DeletedAt = DateTime.UtcNow
            };

            return Ok(result);
        }

        #region Private Methods

        private static void SeedSampleData()
        {
            var random = new Random();
            var eventTypes = new[] { "page_view", "button_click", "form_submit", "user_login", "user_logout", "purchase", "search" };
            var userIds = new[] { "user1", "user2", "user3", "user4", "user5" };

            for (int i = 0; i < 100; i++)
            {
                _events.Add(new AnalyticsEvent
                {
                    Id = Guid.NewGuid(),
                    EventType = eventTypes[random.Next(eventTypes.Length)],
                    UserId = userIds[random.Next(userIds.Length)],
                    SessionId = Guid.NewGuid().ToString(),
                    Properties = new Dictionary<string, object>
                    {
                        ["page"] = $"/page{random.Next(1, 10)}",
                        ["browser"] = "Chrome",
                        ["os"] = "Windows"
                    },
                    Timestamp = DateTime.UtcNow.AddDays(-random.Next(0, 30)).AddHours(-random.Next(0, 24)),
                    IpAddress = $"192.168.1.{random.Next(1, 255)}",
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36"
                });
            }
        }

        private bool HasActiveFilters(EventFilter filter)
        {
            return !string.IsNullOrEmpty(filter.UserId) ||
                   !string.IsNullOrEmpty(filter.EventType) ||
                   !string.IsNullOrEmpty(filter.SessionId) ||
                   filter.StartDate.HasValue ||
                   filter.EndDate.HasValue;
        }

        private async Task<ActionResult> ExportAsJson(List<AnalyticsEvent> events, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true });
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"analytics_export.json\"");
            return File(bytes, "application/json", "analytics_export.json");
        }

        private async Task<ActionResult> ExportAsCsv(List<AnalyticsEvent> events, CancellationToken cancellationToken)
        {
            var csv = new System.Text.StringBuilder();
            csv.AppendLine("Id,EventType,UserId,SessionId,Timestamp,IpAddress");
            
            foreach (var evt in events)
            {
                csv.AppendLine($"{evt.Id},{evt.EventType},{evt.UserId},{evt.SessionId},{evt.Timestamp:yyyy-MM-dd HH:mm:ss},{evt.IpAddress}");
            }
            
            var bytes = System.Text.Encoding.UTF8.GetBytes(csv.ToString());
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"analytics_export.csv\"");
            return File(bytes, "text/csv", "analytics_export.csv");
        }

        private async Task<ActionResult> ExportAsXml(List<AnalyticsEvent> events, CancellationToken cancellationToken)
        {
            var xml = new System.Text.StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.AppendLine("<AnalyticsEvents>");
            
            foreach (var evt in events)
            {
                xml.AppendLine($"  <Event>");
                xml.AppendLine($"    <Id>{evt.Id}</Id>");
                xml.AppendLine($"    <EventType>{evt.EventType}</EventType>");
                xml.AppendLine($"    <UserId>{evt.UserId}</UserId>");
                xml.AppendLine($"    <SessionId>{evt.SessionId}</SessionId>");
                xml.AppendLine($"    <Timestamp>{evt.Timestamp:yyyy-MM-dd HH:mm:ss}</Timestamp>");
                xml.AppendLine($"    <IpAddress>{evt.IpAddress}</IpAddress>");
                xml.AppendLine($"  </Event>");
            }
            
            xml.AppendLine("</AnalyticsEvents>");
            
            var bytes = System.Text.Encoding.UTF8.GetBytes(xml.ToString());
            Response.Headers.Add("Content-Disposition", "attachment; filename=\"analytics_export.xml\"");
            return File(bytes, "application/xml", "analytics_export.xml");
        }

        #endregion
    }

    #region Models

    public class AnalyticsEvent
    {
        public Guid Id { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        public DateTime Timestamp { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }

    public class AnalyticsEventRequest
    {
        public string EventType { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string? SessionId { get; set; }
        public Dictionary<string, object>? Properties { get; set; }
    }

    public class EventRecordResult
    {
        public Guid EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class EventFilter
    {
        public string? UserId { get; set; }
        public string? EventType { get; set; }
        public string? SessionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = "timestamp";
        public bool SortDesc { get; set; } = true;
    }

    public class EventQueryResult
    {
        public List<AnalyticsEvent> Events { get; set; } = new List<AnalyticsEvent>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }

    public class DashboardMetrics
    {
        public string Timeframe { get; set; } = string.Empty;
        public int TotalEvents { get; set; }
        public int UniqueUsers { get; set; }
        public int UniqueSessions { get; set; }
        public Dictionary<string, int> EventTypeBreakdown { get; set; } = new Dictionary<string, int>();
        public Dictionary<int, int> EventsPerHour { get; set; } = new Dictionary<int, int>();
        public Dictionary<string, int> TopUsers { get; set; } = new Dictionary<string, int>();
        public DateTime GeneratedAt { get; set; }
    }

    public class HealthStatus
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Version { get; set; } = string.Empty;
        public Dictionary<string, object> Checks { get; set; } = new Dictionary<string, object>();
    }

    public class BulkDeleteRequest
    {
        public string ConfirmationCode { get; set; } = string.Empty;
        public bool DeleteAll { get; set; }
        public DateTime? OlderThan { get; set; }
        public string? UserId { get; set; }
    }

    public class BulkDeleteResult
    {
        public int DeletedCount { get; set; }
        public int RemainingCount { get; set; }
        public int OriginalCount { get; set; }
        public DateTime DeletedAt { get; set; }
    }

    #endregion
}
