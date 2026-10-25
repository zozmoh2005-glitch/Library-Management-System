# Library Management System

A console-based Library Management System built with **C#**, **.NET**, **Entity Framework Core**, and **SQL Server**.

This project was developed to practice database operations, entity relationships, LINQ queries, and transaction handling using Entity Framework Core.

## Features

- Manage students, authors, books, and categories.
- Manage book borrowing and returning.
- Track available book copies.
- Validate borrowing requests and requested quantities.
- Prevent duplicate books within a single borrowing request.
- Prevent returning the same loan more than once.
- Use database transactions to maintain data consistency.
- Configure entity relationships using Entity Framework Core.
- Use LINQ to query and filter data.
- Configure lazy loading with EF Core proxies.
- Apply database schema changes using EF Core migrations.

## Technologies Used

- C#
- .NET
- Entity Framework Core
- SQL Server
- LINQ
- Git and GitHub

## Database Entities

The project includes the following entities:

- **Student** — Stores student information.
- **Author** — Stores author information.
- **Category** — Organizes books into categories.
- **Book** — Stores book information and available copy counts.
- **Loan** — Represents a borrowing operation.
- **LoanDetails** — Stores the books and quantities associated with each loan.

## Database Relationships

- A student can have multiple loans.
- A loan can contain multiple loan details.
- A book can appear in multiple loan details.
- An author can have multiple books.
- A category can contain multiple books.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- Visual Studio
- A compatible .NET SDK
- SQL Server
- Entity Framework Core packages compatible with the project

### Setup

1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Configure the SQL Server connection string in your local environment.
4. Create or update the database using the project's EF Core migrations.
5. Build and run the application.

> **Note:** Database configuration and migration commands may need to be adjusted according to your local setup.

## Learning Objectives

This project helped me practice:

- Object-relational mapping (ORM) using Entity Framework Core.
- Configuring relationships between entities.
- Writing LINQ queries.
- Implementing borrowing and returning business logic.
- Handling database transactions.
- Validating user input and business rules.
- Managing database schema changes through migrations.

## Future Improvements

- Build a RESTful API using ASP.NET Core Web API.
- Add DTOs and request validation.
- Introduce a service layer and dependency injection.
- Add authentication and authorization.
- Improve error handling and logging.
- Add automated tests.

## Author

Developed as a learning project to strengthen my C# and .NET backend development skills.