## Test Endpoints

1. **GET by Route Parameter**  
   `GET http://localhost:5109/api/user/getuserbyid/123`  
   ¡ú Binds `id` from route segment.

2. **GET by Query Parameter**  
   `GET http://localhost:5109/api/user/getuserbyname?name=Tom&age=30`  
   ¡ú Binds `name` and `age` from query string.

3. **POST by Body Parameter**  
   `POST http://localhost:5109/api/user/create`  
   ¡ú Body: `{ "name": "Lucy", "age": 25 }`  
   ¡ú Binds to `User` object from JSON body.
