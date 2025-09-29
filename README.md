# Complete Developer Network System

This project is a comprehensive developer networking platform that demonstrates advanced .NET practices, including CQRS architecture, validation, unit testing, Microsoft SQL Server integration, pagination, and client-side development.

---

## Table of Contents

- [Project Overview](#project-overview)  
- [Technologies Used](#technologies-used)  
- [Architecture](#architecture)  
- [Key Features](#key-features)  
- [Database](#database)  
- [Validation](#validation)  
- [Unit Testing](#unit-testing)  
- [Bonus / Impressive Parts](#bonus--impressive-parts)  
- [Setup & Installation](#setup--installation)  
- [Usage](#usage)  

---

## Project Overview

Complete Developer Network System is designed to connect developers, showcase projects, and provide a platform for collaboration. The system follows modern software engineering practices, including CQRS for separation of concerns, input validation, client-side interactivity, and automated testing.

---

## Technologies Used

- **Backend:** C#, .NET 9  
- **Database:** Microsoft SQL Server  
- **ORM:** Entity Framework Core (for some queries)  
- **Testing:** xUnit  
- **Frontend / Client-side:** Razor Pages  
- **Other Libraries:** AutoMapper, FluentValidation  

---

## Architecture

The project follows a layered architecture and CQRS pattern:

- **Command Layer:** Handles all write operations (create, update, delete) using CQRS commands.  
- **Query Layer:** Handles read operations with optimized queries, supporting pagination.  
- **Domain Layer:** Business entities and logic.  
- **Validation Layer:** Uses FluentValidation to enforce rules for requests.  
- **Data Layer:** Microsoft SQL Server as persistent storage.  
- **Client-side Layer:** Provides interactive UI using Razor Pages / Blazor for better user experience.  

---

## Key Features

- User registration, authentication, and profile management  
- Project creation, editing, and collaboration  
- Role-based access control  
- CQRS-based command and query separation for clean architecture  
- Input validation for all user inputs using FluentValidation  
- Pagination for query results (e.g., project lists, user lists)  
- Client-side interactivity using Razor Pages / Blazor  
- Unit tests covering multiple projects:  
  - Command tests  
  - Query tests  
  - Validation tests  
- Database-first or code-first integration with Microsoft SQL Server  
- Automated mapping between DTOs and entities using AutoMapper  

---

## Database

The system uses Microsoft SQL Server for storing all application data. Key considerations:

- Tables for Users, Projects, Roles, and Permissions  
- Support for relational mapping and efficient querying  
- Seed data for initial roles and admin user  
- Stored procedures for some optimized read queries (optional)  

---

## Validation

All user input is validated using **FluentValidation**. Examples include:

- Required fields  
- Email format  
- Password strength  
- Custom rules for project title and description lengths  

---

## Unit Testing

There are **2–3 separate unit test projects** covering:

- Command handlers (CQRS)  
- Query handlers (CQRS)  
- Validation logic  
- Repository/database layer mocks  
- Integration tests can be added if needed for SQL Server  

---

## Bonus / Impressive Parts

- Full implementation of CQRS with clear separation of read and write models  
- Multiple unit test projects ensuring maintainability and reliability  
- Use of AutoMapper to simplify mapping between DTOs and database entities  
- Clean architecture, making it easy to extend and maintain  
- Integration with Microsoft SQL Server for a production-ready backend  
- Client-side interactivity and pagination improving user experience  

---

## Setup & Installation

1. Clone the repository  
2. Open the solution in Visual Studio 2022+  
3. Restore NuGet packages  
4. Update `appsettings.json` with your SQL Server connection string  
5. Run database migrations to create tables  
6. Build and run the project  

---

## Usage

- Register a new user or log in with seeded admin credentials  
- Create and manage developer profiles and projects  
- Access commands and queries via web UI or API endpoints  
- Pagination ensures large datasets are displayed efficiently  
- Run unit tests using Test Explorer in Visual Studio  
