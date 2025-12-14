# AutoCareHub

AutoCareHub is a web application for discovering car services and repair shops across different cities. The platform allows registered users to create and manage service listings, book appointments, leave comments and reviews, while administrators moderate and manage the system.

## Features
- **Service Listings**
  - Create a service (requires admin approval)
  - View all services and detailed service pages
  - Edit services you own
  - Delete services (owner or administrator)
- **Service Filtering**
  - Filter by category, city, and ownership (my services / others)
- **Appointments**
  - Book an appointment for a service
  - View your own appointments
  - Service owners can view appointments for their services
  - Delete appointments based on permissions
- **Comments and Likes**
  - Add comments to services
  - Delete your own comments or comments on your services
  - Like comments
- **Categories**
  - Main categories and subcategories
  - Managed by administrators
- **Admin Panel**
  - Approve or reject new service requests
  - Manage services, appointments, categories, and users

## Roles
- **Administrator** – The first real registered user becomes an administrator.
- **User** – Standard registered users.

## Architecture
The project follows a **three-layer architecture** (Data, Business Logic, Presentation) and is implemented as an **ASP.NET Core MVC** application.

## Technologies
- C# / ASP.NET Core MVC
- Microsoft SQL Server
- Entity Framework (Code First)
- JavaScript, HTML, CSS, Bootstrap
- Cloudinary (image storage)

## Getting Started
1. Install:
   - .NET SDK
   - Microsoft SQL Server (optionally SSMS)
2. Configure the database connection string in `appsettings.json`.
3. Add Cloudinary credentials if image upload is enabled.
4. Run the project via Visual Studio or `dotnet run`.
