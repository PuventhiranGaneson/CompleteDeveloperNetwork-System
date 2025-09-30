# Complete Developer Network System

A web-based system for managing developer profiles, skills, and hobbies.  
Built with **ASP.NET Core Razor Pages**, **CQRS pattern**, **Entity Framework Core with Microsoft SQL Server**, and a **clean architecture approach**.

---

## ✨ Features
- Developer directory with **Create, Read, Update, Delete (CRUD)** operations.
- **CQRS + Validation** for clean separation of commands and queries.
- **Pagination** for efficient browsing.
- **Client-side form validation** with Bootstrap and JavaScript.
- RESTful **Web API integration** for frontend updates.
- Unit tests included for service, command, and query layers.

---

## 🗄️ Database Design

Entity-Relationship Diagram (ERD):

<img width="481" height="331" alt="Database Diagram for CDN drawio" src="https://github.com/user-attachments/assets/3fac9219-d21c-4285-9dd7-2920a5fe3241" />

erDiagram
- A **Developer** can have multiple **Skillsets**.  
- A **Developer** can also have multiple **Hobbies**.  
- Each **Skillset** and **Hobby** belongs to exactly one **Developer**.

    Developer {
        int Id PK
        string Username
        string Email
        string PhoneNumber
        bool IsActive
    }

    Skillset {
        int Id PK
        string Name
        string description
        int DeveloperId FK
    }

    Hobby {
        int Id PK
        string Name
        string description
        int DeveloperId FK
    }

🚀 Tech Stack

    Frontend: Razor Pages, Bootstrap 5, FontAwesome

    Backend: ASP.NET Core 9, CQRS, MediatR

    Database: Microsoft SQL Server + Entity Framework Core

    Testing: xUnit / NUnit (5 unit test projects included)

📦 Getting Started

    Clone the repository:

    git clone https://github.com/your-repo/complete-developer-network.git

    Update the connection string in appsettings.json to point to your SQL Server.

Run migrations:

    dotnet ef database update

Launch the app:

   dotnet run

  Open in browser: http://localhost:5102



---

