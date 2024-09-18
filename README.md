# Riwi Link-up-ms - Backend API

[![.Net](https://neosmart.net/blog/wp-content/uploads/2019/06/dot-NET-Standard-Logo-Rectangle.png)](https://dotnet.microsoft.com/apps/aspnet/apis)

[![build](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/yourusername/Riwi-Link-up/actions)
[![run](https://img.shields.io/badge/run-passing-brightgreen.svg)](https://your-deployment-url.com)
[![version](https://img.shields.io/badge/version-1.0.0-brightgreen.svg)](https://github.com/yourusername/Riwi-Link-up/releases/tag/v1.0.0)
[![version](https://img.shields.io/badge/version-2.0.0-brightgreen.svg)](https://github.com/yourusername/Riwi-Link-up/releases/tag/v2.0.0)
[![version](https://img.shields.io/badge/version-3.0.0-brightgreen.svg)](https://github.com/yourusername/Riwi-Link-up/releases/tag/v3.0.0)


Riwi Link-up-ms is a robust WebAPI developed in C# using ASP.NET Core, designed to power and connect with database the Riwi LinKUp platform. This comprehensive backend solution facilitates efficient matching between Riwi clients with coders, emphasizing in their personal information and projects.

> [!IMPORTANT]
> This API forms the foundation of Riwi LinKUp platform, enabling seamless connections between frontend and backend.

## Key Features

- **User and Coder Profile Management**: Comprehensive CRUD operations for managing user and coder profiles.
- **Advanced Filtering**: Sophisticated system for filtering coder profiles based on various criteria.
- **Authentication and Authorization**: Secure JWT-based authentication and role-based access control.
- **Admin Interface**: Dedicated endpoints for administrative tasks and bulk updates.
- **Analytics Dashboard**: Endpoints providing valuable insights on coder demographics and platform usage.

## Data Transfer Objects (DTOs)

The API utilizes a variety of DTOs to ensure efficient and secure data transfer between the client and server:

- **UserDto**: For basic user information transfer
- **RegisterUserDto**: Specifically for user registration processes- **RegisterUserDto**: Specifically for user registration processes
- **LoginUserDto**: Handles login credentials
- **CoderDtoV1** and **CoderDtoV2**: Different versions for coder data representation
- **CoderCreationDto**: Used when creating new coder profiles
- **CoderUpdateDto**: For updating existing coder information
- **CoderResponseDto**: Comprehensive DTO for detailed coder information responses

> [!TIP]
> The use of DTOs helps in maintaining a clear separation between the internal data model and the data exposed via the API, enhancing security and flexibility.

> [!NOTE]
> The API is designed with scalability in mind, utilizing PostgreSQL for data storage and incorporating performance optimizations like caching and asynchronous programming.

# Technical Overview

## API Architecture
- Implemented using ASP.NET Core Web API
- Follows RESTful principles for endpoint design
- Utilizes Entity Framework Core for ORM capabilities

## Core Functionalities

### Account Management
- Endpoints:
  - `POST /api/v1/account/register`
  - `POST /api/v1/account/login`

> [!NOTE]
> The Account Controller handles user registration and authentication.

### Coder Profile Management
- CRUD operations for coder profiles
- Endpoints: 
  - `GET /api/v1/coders`
  - `GET /api/v1/coders/{id}`
  - `GET /api/v2/coders`
  - `GET /api/v2/coders/{id}`
  - `POST /api/v2/coders`
  - `PUT /api/v2/coders/{id}`
  - `PATCH /api/v2/coders/{id}`
  - `DELETE /api/v2/coders/{id}`
    
> [!CAUTION]
> Be careful when using the DELETE endpoint as it permanently removes a user from the system.> Be careful when using the DELETE endpoint as it permanently removes a user from the system.> Be careful when using the DELETE endpoint as it permanently removes a user from the system.

> [!TIP]
> The v2 endpoints provide more detailed and flexible operations for coder profiles.


### User Management
- Endpoints:
  - `GET /api/v1/user`
  - `GET /api/v1/user/email/{email}`
  - `PATCH /api/v1/user/{email}`
  - `DELETE /api/v1/user/{email}`

> [!CAUTION]
> Be careful when using the DELETE endpoint as it permanently removes a user from the system.> Be careful when using the DELETE endpoint as it permanently removes a user from the system.> Be careful when using the DELETE endpoint as it permanently removes a user from the system.

### Dashboard
- Endpoints:
  - `GET /api/dashboard/coders-in-training`
  - `GET /api/dashboard/frontend-coders`
  - `GET /api/dashboard/backend-coders`
  - `GET /api/dashboard/companies-by-month`

> [!TIP]
> These endpoints provide valuable insights for administrative purposes.

## Data Models
- **Coder:** Encapsulates coder information including technical skills, language proficiency, and soft skills
- **User:** Represents Riwi LinKUp users with specific project requirements
- **Project:** Defines project structures and coder assignments

## Authentication and Authorization
- Implements JWT (JSON Web Tokens) for secure API access
- Role-based access control (RBAC) for user and admin functionalities

> [!WARNING]
> Always keep your JWT secret key secure and never expose it in client-side code.

## Database Design
- Utilizes SQL Server for relational data storage
- Includes tables for Coders, Users, Projects, Skills, and relational mapping tables

## API Features
- Pagination support for large data sets
- Sorting and filtering capabilities on relevant endpoints
- Data validation and error handling middleware

## Integration Points
- Endpoints designed for seamless integration with the frontend application
- Supports both JSON and XML response formats for flexibility

## Performance Optimization
- Implements caching mechanisms for frequently accessed data
- Asynchronous programming model for improved scalability

> [!TIP]
> Consider implementing caching for endpoints that return data that doesn't change frequently.

## Monitoring and Logging
- Integrated logging system for tracking API usage and errors
- Endpoints for health checks and system status: `GET /api/health`

## Deployment and Scalability
- Containerized using Docker for easy deployment
- Designed for horizontal scalability in cloud environments

> [!NOTE]
> The system's architecture ensures that administrators can easily update and manage coder information, keeping the talent pool aligned with market demands and project objectives.


## System Requirements

- .NET 8.0 
- SQL Server 2019 or later
- Redis (for caching)
- Docker (optional, for containerization)

## Installation

To install this project, follow these steps:

```bash
git clone https://github.com/Riwi-Tech/Riwi-Link-up-Backend.git
cd Riwi-Link-up-Backend
dotnet restore
```

## Configuration

1. Rename `appsettings.example.json` to `appsettings.json`
2. Update the connection strings in `appsettings.json` for your database and Redis instance
3. Set the following environment variables:
   - `RIWI_API_KEY`: Your API key for external services
   - `RIWI_ENVIRONMENT`: Set to `Development`, `Staging`, or `Production`

## Running the Project

To run the project in development mode:

```bash
dotnet run
```

To run in production mode:

```bash
dotnet run --configuration Release
```

## Project Structure

```
/src
  /Controllers     # API endpoints
  /Models          # Data models and DTOs
  /Services        # Business logic
  /Data            # Database context and migrations
  /Middleware      # Custom middleware
/tests
  /UnitTests       # Unit tests for individual components
  /IntegrationTests # End-to-end API tests
/docs              # API documentation
```

## Main Endpoints

- `GET /api/users`: Retrieve a list of users
- `POST /api/connections`: Create a new connection between users
- `GET /api/messages`: Retrieve user messages
- `PUT /api/profile`: Update user profile information

## Testing

To run the unit tests:

```bash
dotnet test
```

## Deployment

1. Build the Docker image: `docker build -t riwi-link-up-api .`
2. Push to your container registry: `docker push your-registry/riwi-link-up-api:latest`
3. Deploy to your Kubernetes cluster: `kubectl apply -f k8s/deployment.yaml`

## Contributions

Contributions are welcome. Please open an issue or submit a pull request with your changes. Make sure to follow our [contribution guidelines](CONTRIBUTING.md).

>[!NOTE]
>This project is actively maintained and updated regularly.

>[!TIP]
>Check out our [documentation](https://docs.example.com) for detailed usage instructions.

>[!IMPORTANT]
>Ensure you have the version .NET 8.0 SDK installed before setting up the project.

>[!WARNING]
>Breaking changes may occur in major version updates. Always review the changelog before upgrading.

>[!CAUTION]
>Use caution when deploying to production environments. Always test thoroughly in a staging environment first.
