# TaskManagement
Side Project For Task Management
## Project Example: Task Management API

### Functional Requirements:

This API project allows users to:

- Perform Create, Read, Update, and Delete (CRUD) operations on tasks.
- Each task includes: title, description, priority, due date, and completion status.
- Users can filter tasks based on status, priority, and due date.
- Users can register and log in to the system (authentication and authorization).
- Core Technology Stack:

### ASP.NET Core 6 (API framework)
- Entity Framework Core (Database ORM)
- SQLite (as a lightweight database)
- JWT Authentication (for security)
- Serilog (for logging)
- Swagger/OpenAPI (API documentation)

## Initial Sqlite Database (EF Code First)
1. Input Bash to migrations 
   `dotnet ef migrations add InitialCreate`
2. Input Bash to Creat Database
   `dotnet ef database update`
   
## Project Example: Task Management MVC

This project is an ASP.NET Core MVC application that integrates with a separate Task Management API using a Swagger-generated client for performing CRUD operations. The API is based on a RESTful design and is documented using Swagger/OpenAPI.

### Project Overview

This project consists of two main components:

1. **Task API**: A RESTful web API that manages tasks with standard CRUD (Create, Read, Update, Delete) operations.
2. **Task MVC Client**: An ASP.NET Core MVC application that interacts with the Task API using a Swagger-generated client for managing tasks.

### Features
- Full CRUD functionality for tasks (create, read, update, delete).
- Swagger Client integration to easily communicate with the Task API.
- Uses dependency injection for managing the Swagger client.
- Simple UI in MVC views for task management.

## Getting Started

### Prerequisites

Ensure you have the following tools installed:
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or another IDE that supports .NET 6
- [NSwag](https://github.com/RicoSuter/NSwag) for Swagger client code generation:
  ```bash
  dotnet tool install --global NSwag.ConsoleCore
  nswag openapi2csclient /input:https://localhost:7256/swagger/v1/swagger.json /output:SwaggerClient.cs /namespace:TaskManagementMVC.Services
