# MovieShopAPI

MovieShopAPI is a RESTful Web API built with ASP.NET Core for managing a movie shopping platform. The project provides backend functionality for working with movies, genres, casts, users, purchases, accounts, reports, and administrative operations.

The application follows a layered architecture that separates the core domain models and contracts, infrastructure and data-access logic, and API endpoints. This structure helps keep the project organized, maintainable, and easier to extend.

## Features

- Movie management
- Genre management
- Cast information
- User and account management
- Movie purchase functionality
- Administrative operations
- Reporting functionality
- RESTful API endpoints
- SQL Server database integration
- Entity Framework Core for data access
- Repository and service patterns
- Dependency injection
- Swagger/OpenAPI documentation
- Docker support

## Technology Stack

| Technology | Purpose |
| --- | --- |
| C# | Primary programming language |
| .NET 10 | Application framework |
| ASP.NET Core Web API | REST API development |
| Entity Framework Core | Object-relational mapping and data access |
| SQL Server | Relational database |
| Swagger / OpenAPI | API documentation and testing |
| Docker | Containerization |
| Git / GitHub | Version control and source-code management |

## Project Architecture

MovieShopAPI is organized into three main projects:

```text
MovieShopAPI
│
├── ApplicationCore
│   ├── Entities
│   ├── Models
│   ├── RepositoryInterfaces
│   └── ServiceInterfaces
│
├── Infrastructure
│   ├── Data
│   ├── Repositories
│   └── Services
│
└── MovieAPI
    ├── Controllers
    ├── Program.cs
    ├── appsettings.json
    └── Properties
```

### ApplicationCore

Contains the core application definitions, including domain entities, models, repository contracts, and service contracts.

Keeping these definitions separate from the infrastructure layer helps reduce coupling between the application's business logic and its data-access implementation.

### Infrastructure

Contains implementations for database access and application services.

This layer communicates with SQL Server through Entity Framework Core and implements the repository and service contracts defined by `ApplicationCore`.

### MovieAPI

The presentation/API layer of the application.

It contains the API controllers and application startup configuration. `Program.cs` configures dependency injection and connects the API layer with the required repositories and services.

## Application Flow

A typical request follows this flow:

```text
Client
   │
   ▼
API Controller
   │
   ▼
Service
   │
   ▼
Repository
   │
   ▼
Entity Framework Core
   │
   ▼
SQL Server
```

This separation keeps HTTP handling, business logic, and database operations in their appropriate layers.

## Getting Started

### Prerequisites

Before running the application locally, make sure you have:

- .NET 10 SDK
- SQL Server or SQL Server Express/LocalDB
- Git
- Visual Studio, Visual Studio Code, or another compatible IDE
- Docker Desktop (optional, if running the project with Docker)

## Clone the Repository

```bash
git clone https://github.com/Yashaswini944/MovieShopAPI.git
cd MovieShopAPI
```

## Restore Dependencies

Restore the required NuGet packages:

```bash
dotnet restore
```

## Database Configuration

Configure the SQL Server connection string in the appropriate `appsettings.json` file.

Example:

```json
{
  "ConnectionStrings": {
    "MovieShopDbConnection": "Server=YOUR_SERVER;Database=MovieShop;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Replace the server and database information with the configuration for your local SQL Server environment.

Do not commit database passwords, API keys, or other sensitive credentials to GitHub.

## Database Setup

If the project uses Entity Framework Core migrations, update the local database using the migrations included with the project.

For example:

```bash
dotnet ef database update
```

Run the command from the appropriate project or specify the required project/startup project if necessary.

## Build the Project

```bash
dotnet build
```

## Run the API

Navigate to the API project:

```bash
cd MovieAPI
```

Then start the application:

```bash
dotnet run
```

The terminal will display the local HTTP/HTTPS addresses assigned to the application.

## Swagger / OpenAPI

The project includes Swagger/OpenAPI support for exploring and testing the API during local development.

After starting the API, open the Swagger URL displayed/configured for your local application, typically using the `/swagger` route.

Swagger provides an interactive interface where you can:

- View available API endpoints
- Review request parameters
- Inspect request and response models
- Execute API requests
- Review HTTP response codes

## Main API Areas

The application contains functionality related to several areas of the movie shopping system, including:

### Movies

Provides operations related to movie information and the movie catalog.

### Genres

Provides access to movie genre information.

### Cast

Handles information associated with movie cast members.

### Users and Accounts

Contains functionality associated with application users and account-related operations.

### Purchases

Handles movie purchase-related operations.

### Reports

Provides reporting-related functionality for the application.

### Admin

Contains operations intended for administrative functionality.

The exact routes, HTTP methods, parameters, and request/response models can be viewed through Swagger after running the project locally.

## Dependency Injection

MovieShopAPI uses ASP.NET Core's built-in dependency injection system.

Repository and service implementations are registered during application startup and injected where required. This keeps components loosely coupled and makes the application easier to maintain and test.

Conceptually:

```text
Controller
    ↓
Service Interface
    ↓
Service Implementation
    ↓
Repository Interface
    ↓
Repository Implementation
    ↓
Database
```

## Repository Pattern

Database operations are separated from API controllers through repository interfaces and implementations.

This provides several benefits:

- Separates data-access logic from API logic
- Reduces duplication
- Improves maintainability
- Makes components easier to replace or test
- Keeps controllers focused on handling HTTP requests and responses

## Docker

The project includes Docker support, allowing the API to be containerized for a consistent development environment.

Build the Docker image from the appropriate project directory using the Docker configuration included in the repository.

Docker is optional for local development; the API can also be run directly with the .NET CLI or from Visual Studio.

## Development

A typical local development workflow is:

```bash
git clone https://github.com/Yashaswini944/MovieShopAPI.git

cd MovieShopAPI

dotnet restore

dotnet build

cd MovieAPI

dotnet run
```

Then use Swagger or another API client to test the available endpoints.

## Project Goals

MovieShopAPI demonstrates backend development concepts including:

- RESTful API design
- Layered application architecture
- Separation of concerns
- Dependency injection
- Repository and service patterns
- Relational database integration
- Entity Framework Core
- SQL Server
- API documentation
- Containerization

## Future Improvements

Possible future improvements include:

- Expanded automated unit and integration testing
- Improved validation and centralized exception handling
- Enhanced API documentation
- Logging and monitoring improvements
- Additional search, filtering, sorting, and pagination capabilities
- CI/CD automation

## Repository

The source code for this project is maintained on GitHub under the `MovieShopAPI` repository.

## Author

**Yashaswini**

GitHub: Yashaswini944
