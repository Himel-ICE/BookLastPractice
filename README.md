# BookStore

A clean and modular ASP.NET Core Web App for managing books, built with Razor Pages and structured using N-Tier architecture. It incorporates the Repository pattern to ensure scalable, testable, and maintainable code for enterprise-level development.

## Features

- List, create, update, and delete books
- N-Tier architecture for logical separation of concerns
- Repository pattern for abstracted data operations
- Asynchronous operations using ADO.NET
- Bootstrap-powered responsive user interface
- Form validation and user input protection

## Technologies Used

- ASP.NET Core (.NET 8 or higher)
- Razor Pages
- C#
- ADO.NET
- SQL Server
- Bootstrap 5

## Architectural Overview

| Tier              | Description                                      |
|-------------------|--------------------------------------------------|
| **Presentation**  | View Pages for UI and user interaction          |
| **Business Logic**| Services for implementing core application logic |
| **Data Access**   | Repositories interfacing with SQL Server         |
| **Database**      | Lingq, using SQL Server and EntityFrameWork    |

## Folder Structure

- `Books/Views` – Razor Pages for displaying and managing book records  
- `Models` – Plain Old CLR Objects (POCOs) representing entities  
- `Repositories` – Interfaces and classes for database access  
- `Services` – Business logic layer interacting with repositories  
- `wwwroot` – Static files (CSS, JS, assets)

## Getting Started

1. **Clone the repository:**
   ```bash
   gh repo clone Himel-ICE/BookLastPractice
