# Clean Architecture DDD Template

Full Modular Monolith .NET application with Domain-Driven Design approach.

## Technologies

* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 8 - Database first](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [FluentValidation](https://fluentvalidation.net/)

## Getting Started

Launch the app:
```bash
cd src/Api
dotnet run
```

## Database

The template is configured to use SQL Server by default.

```bash
 cd infrastructure
 ef.bat
```

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### Api

This layer is a web api application based on ASP.NET 6.0.x. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

### Logs

Logging into Elasticsearch using Serilog and viewing logs in Kibana.

### Interface info Application

1
1.1 IQueryHandler<TQuery> 
1.2 ICommandHandler<TCommand>

```bash
{
    "IsSuccess": true,
    "IsFailure": false,
    "Error": {
        "Code": "",
        "Message": ""
    }
}