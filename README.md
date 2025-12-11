# Dev Blog Web App📝

## Features✨

- **ASP.NET Core MVC**: scalable web application.
- **Entity Framework Core (EF Core)**: Perform CRUD operations with SQL Server using a Code-First approach.
- **Repository Pattern & Domain-Driven Design (DDD)**: Organize code for maintainability and scalability.
- **Authentication & Authorization**: Implement role-based login and registration using **Microsoft Identity**.
- **Model Validation**: Ensure data integrity with ASP.NET Core validation.
- **Bootstrap 5**: Responsive UI with user-friendly notifications.
- **ViewData & TempData**: Pass data effectively between controllers and views.
- **Image Upload**: Upload images to popular 3rd-party hosting providers via SDK.
- **WYSIWYG Editor**: Rich text editor integrated with image upload.
- **Dependency Injection**: Apply DI for better code modularity and testability.
- **Advanced ASP.NET Core Concepts**: Applied best practices in modern web development.

---

## Technologies Used💻

- C#  
- .NET 8  
- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- Bootstrap 5  
- Microsoft Identity  

---

## Getting Started🏁

1. **Clone the repository**  
```bash
https://github.com/Hizbucodes/DevBloggie-ASP.NET-Core-MVC.git
```

2. **Open the project** in Visual Studio 2022 or later.

3. **Update database connection string** in \`appsettings.json\`.

4. **Apply migrations** to set up the database:  
```bash
  Add-Migration <MigrationName> -Context <YourDbContextName>
```
5. **Update Database** to see the changes:
```bash
  Update-Database -Context <YourDbContextName>
```


6. **Open your browser and navigate to** \https://localhost:5001\🌐

---

## Project Structure📂

```
/Controllers      - Handles HTTP requests and actions
/Models           - Domain models and EF Core entities
/Views            - Razor pages for UI
/Data             - Database context and migrations
/Repositories     - Implements repository pattern
/Services         - Business logic and services
/wwwroot          - Static files (CSS, JS, images)
```
