# 🎓 Student Management System API (.NET Core)

## 📌 Project Description

A RESTful Student Management System built using ASP.NET Core Web API.
It follows a clean layered architecture and provides secure JWT-based authentication,
centralized exception handling, and structured logging using Serilog

---

## 🛠️ Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Serilog Logging
* Swagger (OpenAPI)

---

## 🏗️ Architecture

This project follows a layered architecture:

* Controller Layer (Handles API requests)
* Service Layer (Business logic)
* Repository Layer (Database operations)
* DTOs (Data Transfer Objects)

---

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/vishapril15/StudentManagementSystem
```

### 2. Open in Visual Studio

### 3. Configure Database

Update the connection string in `appsettings.json`

### 4. Run Migration

```bash
Update-Database
```

### 5. Run the Project

### 6. Open Swagger

```
https://localhost:<port>/swagger
```

---

## 🔐 JWT Authentication

1. Call `/api/auth/login` API with:
   **Default credentials (for testing purposes only):**

   * Username: `admin`
   * Password: `123`

2. Copy the JWT token

3. Click **Authorize 🔒** in Swagger

4. Enter:

```
Bearer <your-token>
```

5. Access protected APIs

---

## 📡 API Endpoints

| Method | Endpoint              | Description               |
| ------ | --------------------- | ------------------------- |
| POST   | /api/auth/login       | Generate JWT token        |
| GET    | /api/student          | Get all students (Auth)   |
| GET    | /api/student/{id}     | Get student by id (Auth)  |
| POST   | /api/student          | Create student (Auth)     |
| PUT    | /api/student          | Update student (Auth)     |
| DELETE | /api/student/{id}     | Delete student (Auth)     |

---

## 📊 Features

*  CRUD Operations
* 🔐 JWT Authentication
* ⚠️ Global Exception Handling (Middleware)
* 📊 Logging using Serilog
* 🎯 Standard API Response Format
* 🧱 Clean Layered Architecture

---

## 📸 Screenshots

### Swagger UI

![Swagger](images/swagger.png)
![Swagger Auth](images/Without-jwt.png)
### JWT Authorization
![login popup](images/popup.png)
![login req](images/login.png)

---

## 👨‍💻 Author

Vishal Bamniya
