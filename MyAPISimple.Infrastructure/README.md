# MyApi.Infrastructure (Infrastructure Layer)

This project handles data access and infrastructure concerns.

### Required Packages
- `Microsoft.EntityFrameworkCore` ~8.0.1~
- `Microsoft.EntityFrameworkCore.SqlServer` ~8.0.1~
- `Microsoft.EntityFrameworkCore.Tools` ~8.0.1~
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` ~8.0.1~

### Responsibilities
- DbContext
- Repositories
- Fluent API Configurations
- Unit of Work
- Identity Stores

### Key Features
- Manages database interactions
- Implements Identity with EF Core
- Configures database schema using Fluent API