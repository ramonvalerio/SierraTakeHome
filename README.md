# Order Management System

This repository contains a simplified order management system developed using C#, .NET, Microsoft SQL Server, Entity Framework, T-SQL, and stored procedures. The system has REST API endpoints to create and read data for two entities: products and orders. Created by Ramon Valerio da Silva.

## Requirements

1. Install the last version of [Docker Desktop](https://www.docker.com/products/docker-desktop).
2. Install a tool to open SQL Server database like SQL Management Studio or Azure Studio.
3. Install [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) from the official Microsoft website.
4. Install [Postman](https://www.postman.com/downloads/) or something similar to test the application when the environment is ready.

## Installation and Setup

### 1. Build and Start the Docker Containers
   In the solution directory, execute:
   ```bash
   docker compose build
   docker compose up
   ```

### 2. Configure SQL Server Connection
```bash
Server: localhost,1433
Authentication type: SQL Login
User name: sa
Password: Test@123
Database: SierraTakeHome_DB
```

### 3. Access the Application
Copy the localhost URL from the Docker container to run in the browser:
```bash
http://localhost:3500/swagger
```

### 4. Register a User
In the Auth section, open POST/Register and input in the Request body:
```bash
{
  "userName": "YourUserName",
  "password": "YourPassword"
}
```

### 5. Login
In the Auth section, open POST/Login and input:
```bash
{
  "userName": "YourUserName",
  "password": "YourPassword"
}
```
>Note: If your username and password were found in the database, you would receive a Token.

#### 6. Use Token
Copy this token to use on a tool to create an HttpPost Request using the token on 'Postman' or something similar.

### License
This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

### Contact
Ramon Valerio da Silva - ramonvalerios@gmail.com
