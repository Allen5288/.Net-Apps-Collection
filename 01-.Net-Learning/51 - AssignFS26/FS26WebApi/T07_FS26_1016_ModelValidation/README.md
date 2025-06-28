## Q & A
**Q1: What does automatic validation do behind the scenes?**
**A1:**
Automatic validation is triggered by the `[ApiController]` attribute. Before the controller method runs, the framework checks the model¡¯s data annotations (like `[Required]`, `[EmailAddress]`, etc). If any rule is violated, it immediately returns a 400 Bad Request with detailed error info.

------

**Q2: Why or when might we need manual validation?**
**A2:**
Manual validation is needed when we want full control over the error handling logic ¡ª such as customising error messages, returning a unified response format, or validating conditions that data annotations cannot express (like cross-field checks).

------

**Q3: Why do we use a unified return format (e.g., for front-end consistency or API contracts)?**
**A3:**
A unified return format ensures that all API responses follow a consistent structure, making it easier for frontend developers to handle success and error cases. It also simplifies integration, improves maintainability, and aligns with API contract documentation.

## Test Endpoints
1. Automatic Validation
`POST http://localhost:5212/api/user/auto`
2. Manual Validation
`POST http://localhost:5212/api/user/manual`

**Valid JSON**
```json
{
  "id": 1,
  "userName": "JackZhao",
  "email": "jack@example.com",
  "address": "123 King William St, Adelaide",
  "gender": 0,
  "password": "secure123",
  "phone": "0412345678"
}
```
**Invalid JSON**
```json
{
  "id": 2,
  "email": "bademail.com",
  "password": "123"
}
```