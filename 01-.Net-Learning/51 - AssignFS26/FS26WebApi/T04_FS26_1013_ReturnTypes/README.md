http://localhost:5008/api/user/json  
�� default launch endpoint, tests JsonResult

http://localhost:5008/api/user/check?id=1  
�� id >= 0 �� returns success with data

http://localhost:5008/api/user/check?id=-5  
�� id < 0 �� returns BadRequest