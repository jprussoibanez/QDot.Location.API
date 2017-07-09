# QDot API

Exercise to write a C# WebApi solution that host one end point that:
1. Accepts multiple US Zip codes
2. Looks each code up on "http://www.zippopotam.us/"
3. Return a list of  "place name", "long/lat" and "zip" which will be grouped by state.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

The following tools may help on developing and running the application

* [Visual Studio 2017](https://www.visualstudio.com) or [Visual Studio Code](https://code.visualstudio.com/) - Recommended IDEs
* [Docker for windows](https://docs.docker.com/docker-for-windows/) - Docker tools

### Installing

1) Clone repository.
2) Make sure that you have [docker for windows](https://docs.docker.com/docker-for-windows/) correctly install on your machine and running.
3) Build the solution on visual studio.

#### Using docker toolbox

If using legacy [docker toolbox](https://www.docker.com/products/docker-toolbox) please be sure to run visual studio within the correct environment setup. 

```
docker-machine env default
```

## Running the tests

The unit test project [QDot.UnitTest]() can be runned within the IDE or using:

```
dotnet test
```

## Documentation

The documentation is automatically generated with [swagger](http://swagger.io/) and can be found in:

```
http://[server]/swagger
```

![Swagger sample](/images/Swagger.jpg?raw=true "Swagger sample")

### Request Example

```
http://[server]/api/us/location?zipCodes=10000&zipCodes=90210&zipCodes=94131
```

### Response Example

```
[
  {
    "state": "New York",
    "places": [
      {
        "name": "New York City",
        "latitude": 40.7069,
        "longitude": -73.6731,
        "zipCode": "10000"
      }
    ]
  },
  {
    "state": "California",
    "places": [
      {
        "name": "Beverly Hills",
        "latitude": 34.0901,
        "longitude": -118.4065,
        "zipCode": "90210"
      },
      {
        "name": "San Francisco",
        "latitude": 37.745,
        "longitude": -122.4383,
        "zipCode": "94131"
      }
    ]
  }
]
```

## Built With

* [.NET Core](https://www.microsoft.com/net/core) - ASP.NET core
* [Docker](https://www.docker.com/) - Docker containers
* [xUnit](https://xunit.github.io/) - Testing framework
* [Moq](https://github.com/moq/moq4) - Mocking framework
* [Fluent Assertions](http://fluentassertions.com/) - Fluent assertions for testing
* [Swagger](http://swagger.io/) - API documentation
* [Json.NET](http://www.newtonsoft.com/json) - JSON framework for .NET
