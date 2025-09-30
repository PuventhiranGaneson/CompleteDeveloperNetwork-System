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

### A. Add the key to GitHub (per-repo)
1. Open the repository on **GitHub**.  
2. Go to **Settings** → **Deploy keys**.  
3. Click **Add deploy key**.  
4. **Title:** `GitFront Deploy Key`  
5. **Key:** paste the deploy key (the entire `ssh-ed25519 ... puven@gitfront.io` line).  
6. **Leave** "Allow write access" **unchecked** (read-only).  
7. Click **Add key**.

### B. Add the key to GitLab (per-repo)
1. Open the repository on **GitLab**.  
2. Go to **Settings** → **Repository** → **Deploy Keys**.  
3. Click **New deploy key**.  
4. **Title:** `GitFront Deploy Key`  
5. **Key:** paste the deploy key.  
6. Make sure **Grant write permissions** is **not** selected.  
7. Click **Add key**.

### C. Add the key to Bitbucket (per-repo)
1. Open the repo on **Bitbucket**.  
2. Go to **Repository settings** → **Access keys** (or **SSH keys**).  
3. Click **Add key**.  
4. **Label:** `GitFront Deploy Key`  
5. **Key:** paste the deploy key.  
6. Save.

### D. Finish the import on GitFront
1. Go to **GitFront** and import the repo (or retry import).  
2. GitFront will use the deploy key to read your private repo.  
3. When import finishes, GitFront will provide a **clone URL** like:

GitFront Deploy Key:
ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAICG7OUbNip9xAwHgPNc1shedxaL4BtE5wsTA5gaK+uUV puven@gitfront.io
    
    Clone the repository:
    
    git clone https://github.com/your-repo/complete-developer-network.git

    Update the connection string in appsettings.json to point to your SQL Server.

Run migrations:

    dotnet ef database update

Launch the app:

   dotnet run

  Open in browser: http://localhost:5102
---

