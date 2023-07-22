# Swashbuckle

### Create app 
``` 
$dotnet new webapi -o swashbuckle-dotnet7 
```

### Install Swashbuckle cli
```
$dotnet new tool-manifest
$dotnet tool install Swashbuckle.AspNetCore.Cli
```

### Generated swagger doc
```
$dotnet swagger tofile --output swagger.json bin/Debug/net7.0/swashbuckle-dotnet7.dll v1
$dotnet swagger tofile --yaml --output swagger.yml bin/Debug/net7.0/swashbuckle-dotnet7.dll v1
```

# Reference
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Swashbuckle-Filters](https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters)
- [dotnet#7-swagger-doc](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio)