# Learning Notes

## REST

Representational State Transfer

- Style of architecture for building web services
- Set of principles

## DbContext Class

- Maintaining connection to Db
- Track changes
- Perform CRUD operations
- Bridge between domain models and the database
- [DbContext Example](https://github.com/Sola0404/AUWalksAPI/blob/main/AUWalksAPI/Data/AUWalksDbContext.cs)

## Dependency Injection

- Design pattern to increase maintainability, testability
- DI built into ASP.NET Core
- DI container is responsible for creating and managing instances

## Run Migrations and Update Db

- `dotnet ef migrations add InitialCreate`
- Run the Sql docker container and connecting to sql server in Azure Data Studio
- `dotnet ef database update`
- When there are more than 1 dbcontext, specify which one to update `dotnet ef migrations add CreateAuthDatabase --context AUWalksAuthDbContext`

## DTOs

Data Transfer Objects

- Used to transfer data between different layers
- Typically contain a subset of the properties in the domain model
- For example transferring data over a network
- Once we get data from db in domain model, it would be mapping to DTOs, and DTOs will be sent back to client
- Client would send DTOs and be mapped to domain models and sent to db
- [Example](https://github.com/Sola0404/AUWalksAPI/blob/main/AUWalksAPI/Controllers/RegionsController.cs)

## Repository Pattern

- Design pattern to separate the data access layer from the application
- Provides interface without exposing implementation
- Helps create abstraction
- Controllers should not have direct access to DbContext
- Repository will have access to DbContext and will be injected into controllers

## Navigation Properties

- Allow to navigate from one entity to another
- Walks domain model will have Region navigation property
