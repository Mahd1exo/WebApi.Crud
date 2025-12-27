# WebApi.Crud

A simple ASP.NET Core Web API that demonstrates CRUD operations for a `Customer` entity using Entity Framework Core with SQL Server.

## Features

- CRUD endpoints for customers
- Entity Framework Core data access
- Swagger/OpenAPI in development

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core (SQL Server provider)

## Getting Started

### Prerequisites

- .NET SDK (compatible with the project’s target framework)
- SQL Server (local or remote)

### Configuration

Update the connection string in `WebApi.Crud/appsettings.json`:

```json
"ConnectionStrings": {
  "ApiDatabase": "Server=YOUR_SERVER;Database=WebApi;Trusted_Connection=True"
}
```

If you use SQL authentication, provide `User Id` and `Password` in the connection string.

### Database Setup

If you want to use the included migrations:

```bash
dotnet tool install --global dotnet-ef

dotnet ef database update --project WebApi.Crud/WebApi.Crud.csproj
```

### Run the API

```bash
dotnet run --project WebApi.Crud/WebApi.Crud.csproj
```

In development, Swagger UI is available at:

```
https://localhost:{PORT}/swagger
```

## API Endpoints

Base route: `/Customer`

| Method | Route              | Description                  |
|--------|--------------------|------------------------------|
| GET    | `/Customer`         | List all customers           |
| GET    | `/Customer/{id}`    | Get a customer by id         |
| POST   | `/Customer`         | Create a new customer        |
| PUT    | `/Customer`         | Update fields on a customer  |
| PATCH  | `/Customer`         | Replace a customer           |
| DELETE | `/Customer/{id}`    | Delete a customer by id      |

### Example Payload

```json
{
  "id": 1,
  "name": "Jane",
  "surname": "Doe",
  "code": 1001
}
```

## Project Structure

```
WebApi.Crud/
  Controllers/CustomerController.cs
  Models/
    Contexts/DataBaseContext.cs
    Entities/Customer.cs
    Services/CustomerRepository.cs
  Program.cs
  Startup.cs
```

## Notes

- `CustomerRepository.Edit` performs partial updates for `name`, `surname`, and `code`.
- `CustomerRepository.EditAll` replaces the entity by updating the entire record.

## Contributing

Feel free to open issues or submit pull requests for improvements.
