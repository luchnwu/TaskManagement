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
