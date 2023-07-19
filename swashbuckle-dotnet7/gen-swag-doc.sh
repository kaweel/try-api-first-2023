#!/bin/bash
if [ -d "$(pwd)/docs" ]; 
then
    rm -f ./docs/swagger.*
else
    mkdir ./docs
fi

dotnet tool run swagger tofile --output ./docs/swagger.json ./bin/Debug/net7.0/swashbuckle-dotnet7.dll v1
dotnet tool run swagger tofile --yaml --output ./docs/swagger.yaml ./bin/Debug/net7.0/swashbuckle-dotnet7.dll v1