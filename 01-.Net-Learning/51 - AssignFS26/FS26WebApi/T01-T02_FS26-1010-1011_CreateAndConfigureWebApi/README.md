## Endpoints

- http://localhost:5155/api/status �C Home
- http://localhost:5155/api/user/info �C UserController
- http://localhost:5155/api/user/fail �C UserController, used to test exceptions and middleware
- http://localhost:5155/error �C In production mode, errors will redirect to this page

## Notes

- Custom middleware logs the timestamp, HTTP method, and request path to the console