# Phonebook App

A Windows Forms phonebook application with two roles: Admin and Guest. 
The app allows managing contacts and users securely, using a two-layer architecture.

## Features
- Add, edit, delete, and search for contacts
- Add new users with roles
- Two roles: Admin and Guest
- Password hashing for security
- PeopleViewModel and UserViewModel to avoid exposing database info directly
- Two-layer architecture: Presentation layer (WinForms) + Data layer

## Architecture & Tech
- Two-layer architecture: Presentation layer + Data layer
- Database: SQL Server (you need to set it up manually)
- Entity Framework Core 8
- .NET 8
- C# Windows Forms

## Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Phonebook.git
2. Open the solution in Visual Studio 2022

3. Make sure SQL Server is installed locally

4. Configure the connection string in MyDbContext to point to your local database

5. Build and run the project