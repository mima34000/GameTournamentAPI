# GameTournamentAPI

A RESTful Web API built with ASP.NET Core and Entity Framework Core for managing game tournaments.

## Tech Stack

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- SQL Server
- C#

## Project Structure

- Controllers - handles HTTP requests
- Services - contains business logic
- Dtos - data transfer objects
- Models - database entities
- Data - database context

## Endpoints

- GET /api/tournaments - get all tournaments
- GET /api/tournaments?search= - search tournaments by title
- GET /api/tournaments/{id} - get tournament by id
- POST /api/tournaments - create a new tournament
- PUT /api/tournaments/{id} - update a tournament
- DELETE /api/tournaments/{id} - delete a tournament

## Features

- CRUD operations for tournaments
- Search functionality by title
- Input validation with DataAnnotations
- Async/await throughout
- Dependency Injection with Scoped lifetime
- Code First database with EF Core Migrations

- ## API Documentation

- Scalar UI: https://localhost:7226/scalar/v1
- OpenAPI JSON: https://localhost:7226/openapi/v1.json
