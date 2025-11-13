# 📚 BookStore Clean Architecture API

A modular and scalable **.NET 8 Web API** built with **Clean Architecture** and **Domain-Driven Design (DDD)** principles.  
This project demonstrates how to build a maintainable, testable, and production-ready backend for real-world applications.

---

## 🧭 Overview

The **BookStore API** allows users to:
- Manage books and authors  
- Create, read, update, and delete records  
- Authenticate with JWT tokens  
- Apply business rules through a layered architecture  

The goal of this project is to showcase clean code, architectural best practices, and a professional approach to backend development in .NET.

---

## 🏗️ Architecture

This solution follows **Clean Architecture**, with the following layers:

```
BookStore.API           → Presentation (Controllers, Dependency Injection)
BookStore.Application   → Application logic (Use Cases, DTOs, Validators)
BookStore.Domain        → Core business rules (Entities, Interfaces)
BookStore.Infrastructure → Data access, EF Core, Repository implementation
```

Each layer is **independent**, promoting separation of concerns and easy testability.

---

## 🧰 Tech Stack

| Category | Technology |
|-----------|-------------|
| Language | C# (.NET 8) |
| Architecture | Clean Architecture + DDD |
| ORM | Entity Framework Core |
| Database | PostgreSQL |
| Validation | FluentValidation |
| Mapping | AutoMapper |
| Authentication | JWT (JSON Web Token) |
| Testing | xUnit, Moq, FluentAssertions |
| Documentation | Swagger / OpenAPI |
| Logging | Serilog |
| CI/CD | GitHub Actions (build + test pipeline) |

---

## 🚀 Getting Started

### 1️⃣ Prerequisites
Make sure you have installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/)
- [Docker](https://www.docker.com/) (optional)
- [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio 2022

---

### 2️⃣ Clone the Repository

```bash
git clone https://github.com/brunorondon/bookstore-clean-architecture-api.git
cd bookstore-clean-architecture-api
```

---

### 3️⃣ Configure the Database

Edit your connection string in `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=BookStoreDb;Username=postgres;Password=yourpassword"
}
```

You can also run PostgreSQL using Docker:

```bash
docker run --name bookstore-db -e POSTGRES_PASSWORD=yourpassword -p 5432:5432 -d postgres
```

---

### 4️⃣ Run the API

```bash
dotnet ef database update
dotnet run --project src/BookStore.API
```

Once running, open Swagger UI at:
👉 [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 🧪 Running Tests

```bash
dotnet test
```

All unit and integration tests are located in the `tests/` folder.

---

## 🧱 Project Structure

```
📂 src
 ┣ 📂 BookStore.API
 ┣ 📂 BookStore.Application
 ┣ 📂 BookStore.Domain
 ┗ 📂 BookStore.Infrastructure

📂 tests
 ┗ 📂 BookStore.Tests
```

---

## 🔒 Authentication (JWT)

The API uses **JWT Bearer Authentication**.  
To test secured endpoints:
1. Register a new user (`/api/auth/register`)
2. Log in (`/api/auth/login`)
3. Copy the returned token
4. Click **Authorize** in Swagger and paste the token

---

## 🧩 Roadmap

- [x] Clean Architecture setup  
- [x] Book and Author CRUD endpoints  
- [x] JWT Authentication  
- [ ] Unit + Integration Tests  
- [ ] CI/CD pipeline with GitHub Actions  
- [ ] Docker support  
- [ ] Deployment to Render or Azure  

---

## 🧠 Key Learning Points

- Applying **SOLID principles** in a real-world project  
- Structuring a solution for **scalability and testability**  
- Using **Entity Framework Core** with repositories and migrations  
- Implementing **validation, mapping, and error handling** in a clean way  

---

## 🧑‍💻 Author

**Bruno Rondon da Silva**  
*Full Stack .NET Developer*  

🌐 [LinkedIn](https://www.linkedin.com/in/brunorondon)  
📂 [GitHub](https://github.com/brunorondon)

---

## 🏁 License

This project is licensed under the MIT License.  
Feel free to use it for learning or personal projects.

---

> _“Code is like humor. When you have to explain it, it’s bad.”_  
> — Cory House
