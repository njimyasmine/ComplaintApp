# ComplaintApp

## Overview
ComplaintApp is a .NET application designed to manage and track customer complaints. This README provides instructions on how to set up and run the API, explains the design decisions and technologies used, and documents the API endpoints.
## Table of Contents
1. [Overview](#overview)
2. [Prerequisites](#prerequisites)
3. [Getting Started](#getting-started)
4. [Design Decisions and Used Technologies](#design-decisions-and-used-technologies)
5. [API Documentation](#api-documentation)
6. [Project Structure](#project-structure)
7. [Swagger Documentation](#swagger-documentation)
8. [Libraries Used](#Libraries-Used)


## Prerequisites
Ensure you have the following installed before proceeding:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [SQLite](https://www.sqlite.org/download.html) (or another database system)

## Getting Started
Follow these steps to set up and run the application:

1. [Clone the Repository](#1-clone-the-repository)
2. [Install Dependencies](#2-install-dependencies)
3. [Set Up the Database](#3-set-up-the-database)
4. [Run the Application](#5-run-the-application)
5. [Testing the API](#6-testing-the-api)

### 1. Clone the Repository
First, clone the repository to your local machine using git:
```sh
git clone https://github.com/yourusername/complaintApp.git

cd complaintApp
```

### 2. Install Dependencies
Navigate to the project directory and restore the necessary packages:

```sh
dotnet restore
```
### 3. Set Up the Database

Ensure that the Entity Framework Core tools are installed:
```sh
dotnet tool install --global dotnet-ef
```
Apply the database migrations to set up your database schema. Run the following command:
```sh
dotnet ef database update --project complaintApp.csproj --startup-project complaintApp.csproj --context complaintApp.Data.AppDbContext
```
### 4. Run the Application
To run the application, use the following command:
``` sh
dotnet run
```
The API will start and typically be available at https://localhost:5001 or http://localhost:5000.

### 5. Testing the API
You can test the API using tools like Postman or curl. Make sure to check the endpoints and their respective request types in the ComplaintsController.cs file.

## Design Decisions and Used Technologies

### Technologies Used
- **.NET 8.0:** Chosen for its robustness, performance, and extensive support for web development.
- **Entity Framework Core:** An ORM that simplifies data access by allowing developers to work with a database using .NET objects, making the code more maintainable.
- **SQLite:** A lightweight, self-contained database engine, chosen for its simplicity and ease of setup in a development environment.

### Design Decisions
- **Separation of Concerns:** The project is structured into folders like Controllers, Data, Enums, Models, and ViewModels to separate different parts of the application logically.
- **Entity Framework Migrations:** Used for managing database schema changes over time, providing a history of changes and the ability to roll back if necessary.
- **View Models:** Used to shape data specifically for the views, ensuring the API responses are tailored to the needs of the client applications.

## API Documentation

### Base URL
The base URL for the API is `http://localhost:5022`.

### Endpoints
The following are the available endpoints for the Complaints API:

#### 1. Get All Complaints
- **Method:** `GET`
- **URL:** `/api/Complaints`
- **Description:** Retrieves a list of all complaints.
- **Parameters:** None
- **Example Request:**
  ```http
  GET /api/Complaints HTTP/1.1
  Host: localhost:5022
Example Response:
``` sh
[
  {
    "id": 1,
    "productId": 0,
    "customer": {
      "id": 1,
      "name": "yasmine",
      "email": "yasmine@gmail.com"
    },
    "date": "2024-06-02T23:26:55.847",
    "description": "this is a claim",
    "status": 0
  }
]
```
- Response Code: 200 (Success)
- Media Type: application/json

#### 1. Get All Complaints
- **Method:** `GET`
- **URL:** `/api/Complaints`
- **Description:** Retrieves a list of all complaints.
- **Parameters:** None
- **Example Request:**
  ```http
  GET /api/Complaints HTTP/1.1
  Host: localhost:5022
Example Response:
``` sh
[
  {
    "id": 1,
    "productId": 0,
    "customer": {
      "id": 1,
      "name": "yasmine",
      "email": "yasmine@gmail.com"
    },
    "date": "2024-06-02T23:26:55.847",
    "description": "this is a claim",
    "status": 0
  }
]
```
- Response Code: 200 (Success)
- Media Type: application/json

#### 2. Create a New Complaint
- **Method:** `POST`
- **URL:** `/api/Complaints`
- **Description:** Creates a new complaint.
- **Request Body:**
  ```json
  {
    "productId": 3,
    "customer": {
      "name": "ela",
      "email": "ela@gmail.com"
    },
    "date": "2024-06-02T23:26:55.847Z",
    "description": "this is a claim",
    "status": 0
  }

- Response Code: 200 (Success)
- Media Type: Success

#### 3. Get Complaint by ID
- **Method:** `GET`
- **URL:** `/api/Complaints/{id}`
- **Description:** Retrieves a specific complaint by its ID.
- Response Code: 200 (Success)
- Media Type: application/json

#### 4. Update a Complaint
- **Method:** `PUT`
- **URL:** `/api/Complaints/{id}`
- **Description:** Updates an existing complaint.
- Request Body:
  ```json
  {
  "id": 1,
  "productId": 0,
  "customer": {
    "name": "maria",
    "email": "maria@example.com"
  },
  "date": "2024-06-02T23:36:51.361Z",
  "description": "claim description",
  "status": 4
  }

- Response Code: 200 (Success)
- Media Type: Success


#### 5. Delete a Complaint
- **Method:** `DELETE`
- **URL:** `/api/Complaints/{id}`
- **Description:** Deletes a complaint by its ID.
- Response Code: 200 (Success)
- Media Type: Success


#### 6. Get Searched Complaints
- **Method:** `GET`
- **URL:** `/api/Complaints/GetSearchedComplaints`
- **Description:** Retrieves complaints based on search criteria.
- Parameters:
  * productId: (integer) The ID of the product associated with the complaint.
  * customerName: (string) The name of the customer associated with the complaint.
  * status: (integer) The status of the complaint.
- Response Code: 200 (Success)
- Media Type: application/json


## Project Structure

Here's a brief overview of the project's folder structure:

``` sh
complaintApp/
│
├── Controllers/
│ └── ComplaintsController.cs
├── Data/
│ └── AppDbContext.cs
├── Enums/
│ └── Status.cs
├── Models/
│ ├── Complaint.cs
│ └── Customer.cs
├── ViewModels/
│ ├── ComplaintViewModel.cs
│ └── CustomerViewModel.cs
├── Migrations/
│ ├── 20240529212842_InitialCreate.cs
│ ├── 20240529216558_SecondMigration.cs
│ └── AppDbContextModelSnapshot.cs
├── appsettings.json
├── appsettings.Development.json
├── complaintApp.http
├── Program.cs
├── READNE.md
├── .gitignore
└── other project files
``` 

## Swagger Documentation

The API is documented using Swagger (OpenAPI). You can access the Swagger UI to explore the API endpoints, request parameters, and responses.

- [Swagger UI](http://localhost:5022/swagger/index.html)


## Libraries Used

The following libraries/packages were used in this project:

- **Microsoft.AspNetCore.OpenApi (version 8.0.5)**: Integrated to provide Swagger documentation for the API endpoints.
- **Microsoft.EntityFrameworkCore.Design (version 9.0.0-preview.4.24267.1)**: Used for Entity Framework Core design-time commands.
- **Microsoft.EntityFrameworkCore.Sqlite (version 9.0.0-preview.4.24267.1)**: SQLite database provider for Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Tools (version 9.0.0-preview.4.24267.1)**: Provides additional tools for Entity Framework Core.
- **Swashbuckle.AspNetCore (version 6.4.0)**: Used for generating Swagger/OpenAPI documentation for the API endpoints.

These libraries were chosen for their specific functionalities, compatibility with the project requirements, and community support.
