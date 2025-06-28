http://localhost:5008/api/user/json  
¡ú default launch endpoint, tests JsonResult

http://localhost:5008/api/user/check?id=1  
¡ú id >= 0 ¡ú returns success with data

http://localhost:5008/api/user/check?id=-5  
¡ú id < 0 ¡ú returns BadRequest