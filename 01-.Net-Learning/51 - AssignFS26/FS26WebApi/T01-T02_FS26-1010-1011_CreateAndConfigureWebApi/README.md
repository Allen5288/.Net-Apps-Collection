## Endpoints

- http://localhost:5155/api/status 每 Home
- http://localhost:5155/api/user/info 每 UserController
- http://localhost:5155/api/user/fail 每 UserController, used to test exceptions and middleware
- http://localhost:5155/error 每 In production mode, errors will redirect to this page

## Notes

- Custom middleware logs the timestamp, HTTP method, and request path to the console