# Web API Controllers Documentation

This folder contains comprehensive examples of different Web API controller patterns and usage scenarios in ASP.NET Core. Each controller demonstrates specific concepts and best practices for building robust REST APIs.

## 📁 Controllers Overview

### 1. **UserController.cs** - Basic CRUD Operations
**Purpose**: Demonstrates fundamental REST API operations with proper HTTP methods and status codes.

**Key Features**:
- ✅ **Full CRUD Operations** (Create, Read, Update, Delete)
- ✅ **HTTP Method Mapping** (GET, POST, PUT, PATCH, DELETE)
- ✅ **Proper Status Codes** (200, 201, 204, 400, 404)
- ✅ **Model Validation** using Data Annotations
- ✅ **Pagination Support** with query parameters
- ✅ **Search Functionality** with filtering
- ✅ **Partial Updates** using PATCH method
- ✅ **Custom Response Headers** for metadata

**Endpoints**:
```
GET    /api/user           - Get all users (with pagination)
GET    /api/user/{id}      - Get user by ID
POST   /api/user           - Create new user
PUT    /api/user/{id}      - Update entire user
PATCH  /api/user/{id}      - Partial user update
DELETE /api/user/{id}      - Delete user
GET    /api/user/search    - Search users by name/email
```

**Learning Concepts**:
- RESTful API design principles
- Model binding from different sources ([FromBody], [FromQuery], [FromRoute])
- Data validation with attributes
- Proper error handling and status codes
- Response formatting with ActionResult<T>

---

### 2. **ProductController.cs** - Advanced API Features
**Purpose**: Showcases advanced Web API capabilities including content negotiation, bulk operations, and complex filtering.

**Key Features**:
- ✅ **Content Negotiation** (JSON/XML responses)
- ✅ **Complex Query Parameters** with filtering and sorting
- ✅ **Bulk Operations** with partial success handling
- ✅ **Custom Action Results** and response types
- ✅ **Business Logic Validation** (conditional operations)
- ✅ **Multi-Status Responses** (207 Multi-Status)
- ✅ **Custom Response Headers** for additional metadata
- ✅ **Model Binding from Multiple Sources**

**Endpoints**:
```
GET    /api/product                 - Get products (with filtering & sorting)
GET    /api/product/{id}            - Get product by ID
POST   /api/product                 - Create new product
PUT    /api/product/{id}/stock      - Update product stock
DELETE /api/product/{id}            - Delete product (with conditions)
GET    /api/product/categories      - Get category summaries
POST   /api/product/bulk            - Bulk create products
```

**Learning Concepts**:
- Advanced filtering and sorting techniques
- Content negotiation (Accept headers)
- Bulk operations with transaction-like behavior
- Complex validation scenarios
- Business rule enforcement
- Multi-status responses for partial operations

---

### 3. **FileController.cs** - File Operations
**Purpose**: Demonstrates file upload, download, and management operations with proper streaming and validation.

**Key Features**:
- ✅ **File Upload** with validation and size limits
- ✅ **Multiple File Upload** with batch processing
- ✅ **File Download** with different content dispositions
- ✅ **File Streaming** for large files
- ✅ **File Metadata Management** 
- ✅ **Request Size Limits** and file type validation
- ✅ **Proper Content-Type Handling**
- ✅ **Physical File Storage** with unique naming

**Endpoints**:
```
POST   /api/file/upload           - Upload single file
POST   /api/file/upload-multiple  - Upload multiple files
GET    /api/file/{id}             - Download file
GET    /api/file/{id}/stream      - Stream file (for large files)
GET    /api/file/{id}/info        - Get file metadata
GET    /api/file                  - List all files (paginated)
DELETE /api/file/{id}             - Delete file
```

**Learning Concepts**:
- File upload handling with IFormFile
- File validation (size, type, content)
- Streaming large files efficiently
- File metadata management
- Content disposition headers
- Request size limits and security considerations

---

### 4. **AnalyticsController.cs** - Advanced Async Operations
**Purpose**: Demonstrates complex async operations, cancellation tokens, data export, and health monitoring.

**Key Features**:
- ✅ **Async Operations** with proper cancellation token usage
- ✅ **Complex Data Filtering** with multiple parameters
- ✅ **Data Export** in multiple formats (JSON, CSV, XML)
- ✅ **Dashboard Metrics** with data aggregation
- ✅ **Health Check Endpoints** for monitoring
- ✅ **Bulk Delete Operations** with confirmation
- ✅ **Custom Response Formats** based on content type
- ✅ **Cache Control Headers** for performance optimization

**Endpoints**:
```
POST   /api/analytics/event        - Record analytics event
GET    /api/analytics/event/{id}   - Get specific event
GET    /api/analytics/events       - Query events (complex filtering)
GET    /api/analytics/dashboard    - Get dashboard metrics
GET    /api/analytics/export       - Export data (JSON/CSV/XML)
GET    /api/analytics/health       - Health check
DELETE /api/analytics/events       - Bulk delete events
```

**Learning Concepts**:
- Async/await patterns in Web API
- Cancellation token usage for responsive APIs
- Complex query parameter handling
- Data aggregation and reporting
- Multiple export formats
- Health monitoring patterns
- Bulk operations with safety confirmations

---

### 5. **WeatherForecastController.cs** - Default Template
**Purpose**: Standard ASP.NET Core Web API template controller for reference.

**Key Features**:
- ✅ **Basic GET Operation**
- ✅ **Dependency Injection** (ILogger)
- ✅ **Simple Data Generation**
- ✅ **Standard Response Format**

---

## 🧪 Testing Examples

### **API_Testing_Examples.http**
Comprehensive HTTP test file with examples for all endpoints:

- **CRUD Operations**: Basic create, read, update, delete scenarios
- **Error Handling**: Invalid data, missing resources, validation errors
- **Advanced Features**: Filtering, sorting, pagination, bulk operations
- **File Operations**: Upload, download, streaming examples
- **Content Negotiation**: JSON/XML responses
- **Performance Testing**: Concurrent requests, large data queries

## 📋 Common Patterns Demonstrated

### 1. **HTTP Status Codes**
```csharp
// Success responses
return Ok(data);                           // 200 OK
return Created(location, data);            // 201 Created
return NoContent();                        // 204 No Content
return StatusCode(207, multiStatusData);   // 207 Multi-Status

// Error responses
return BadRequest(message);                // 400 Bad Request
return NotFound(message);                  // 404 Not Found
return Conflict(message);                  // 409 Conflict
return StatusCode(500, message);           // 500 Internal Server Error
```

### 2. **Model Binding Sources**
```csharp
public ActionResult Method(
    [FromRoute] int id,              // From URL path
    [FromQuery] string filter,       // From query string
    [FromBody] MyModel model,        // From request body
    [FromHeader] string auth,        // From request headers
    [FromForm] IFormFile file)       // From form data
```

### 3. **Content Negotiation**
```csharp
[Produces("application/json", "application/xml")]
public ActionResult<MyModel> GetData()
{
    // Returns JSON or XML based on Accept header
    return Ok(data);
}
```

### 4. **Async Operations**
```csharp
public async Task<ActionResult<T>> GetDataAsync(
    CancellationToken cancellationToken = default)
{
    try
    {
        var data = await _service.GetDataAsync(cancellationToken);
        return Ok(data);
    }
    catch (OperationCanceledException)
    {
        return StatusCode(408, "Request was cancelled");
    }
}
```

### 5. **Validation Patterns**
```csharp
public class CreateUserRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Range(1, 150)]
    public int Age { get; set; }
}
```

### 6. **Custom Headers**
```csharp
// Add custom response headers
Response.Headers.Add("X-Total-Count", count.ToString());
Response.Headers.Add("X-Processing-Time", processingTime.ToString());
```

## 🔧 Best Practices Demonstrated

### **Error Handling**
- Proper HTTP status codes for different scenarios
- Detailed error messages with validation details
- Consistent error response formats
- Graceful handling of cancellation tokens

### **Performance Optimization**
- Async/await for I/O operations
- Pagination for large datasets
- Streaming for large files
- Cache control headers where appropriate

### **Security Considerations**
- Input validation and sanitization
- File upload restrictions (size, type)
- Confirmation codes for destructive operations
- Proper error messages (no sensitive data exposure)

### **API Documentation**
- Comprehensive XML documentation comments
- ProducesResponseType attributes for OpenAPI
- Clear parameter descriptions
- Example usage scenarios

### **Testing & Maintainability**
- Separation of concerns
- Dependency injection usage
- Structured logging
- Consistent naming conventions

## 🚀 How to Use

1. **Run the Application**:
   ```bash
   dotnet run
   ```

2. **Test the APIs**:
   - Use the provided `.http` file with VS Code REST Client
   - Or use tools like Postman, curl, or browser
   - Check Swagger UI at `https://localhost:7155/swagger`

3. **Explore Each Controller**:
   - Start with `UserController` for basic CRUD
   - Move to `ProductController` for advanced features
   - Try `FileController` for file operations
   - Experiment with `AnalyticsController` for complex scenarios

4. **Modify and Extend**:
   - Add new endpoints to existing controllers
   - Create new controllers following the patterns
   - Implement additional features like authentication, caching, etc.

## 📚 Additional Learning Resources

### **Topics to Explore Further**:
- Authentication & Authorization (JWT, OAuth)
- API Versioning strategies
- Rate limiting and throttling
- Caching strategies (in-memory, distributed)
- Database integration with Entity Framework
- API documentation with Swagger/OpenAPI
- Testing strategies (unit, integration)
- Logging and monitoring
- Deployment considerations

### **Recommended Next Steps**:
1. Add Entity Framework Core for database operations
2. Implement authentication with JWT tokens
3. Add API versioning support
4. Create comprehensive unit tests
5. Implement caching strategies
6. Add monitoring and health checks
7. Set up CI/CD pipeline for deployment

---

*This documentation covers the essential patterns and practices for building robust Web APIs in ASP.NET Core. Each controller builds upon the previous concepts, providing a comprehensive learning path for Web API development.*
