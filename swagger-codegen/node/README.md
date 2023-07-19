# Swagger
Config mock server with swagger.yaml file

## Generate mock server usgin swagger-codegen
```
// generate node-server
$swagger-codegen generate -i ../swagger.yaml -l nodejs-server -o ./mock-server
```

## Run mock server
```
// go to mock folder
$cd mock-server

// start mock server locally
$npm start
```

- Get user by id :: http://localhost:8080/users/1
- Swagger-ui :: http://localhost:8080/docs
