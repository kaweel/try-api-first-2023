# Swagger
Config mock server with swagger.yml file

## Generate mock server usgin swagger-codegen
```
// generate go-server
$swagger-codegen generate -i ./swagger.yml -l go-server -o ./mock-server
```

## Implement function UsersIdGet
```
type User struct {
	ID   int    `json:"id"`
	Name string `json:"name"`
}

func UsersIdGet(w http.ResponseWriter, r *http.Request) {
	// Extract the ID parameter from the request URL
	id := mux.Vars(r)["id"]

	// Check the value of the ID parameter
	if id == "1" {
		// User found with ID 1
		user := User{
			ID:   1,
			Name: "Mark Wahlberg",
		}

		// Set HTTP status code to 200 OK
		w.WriteHeader(http.StatusOK)

		// Set response header
		w.Header().Set("Content-Type", "application/json; charset=utf-8")

		// Manually write the response body
		responseBody, _ := json.Marshal(user)
		w.Write(responseBody)
	} else {
		// User not found
		// Set HTTP status code to 404 Not Found
		w.WriteHeader(http.StatusNotFound)
	}
}
```

## Docker run mock server
```
// build mock server version 1.0
$docker build mock-server:1.0 .

// run mocker server
$docker run -p 8080:8080 --rm mock-server:1.0
```

Get user by id :: http://localhost:8080/users/1

## Manual run mock server
```
// go to mock folder
$cd mock-server

// replace import package
$sed -i '' 's/.\/go/mock-server\/go/g' main.go

// initial module
$go mod init mock-server

// add missing and remove unused modules
$go mod tidy

// start mock server
$go run main.go
```