# 🏢 Central Supply Unit System

## 📌 Project Overview

A full-stack web application built to manage warehouses, items, and
supply documents.\
The system allows managers to create and manage warehouses, assign
items, and export warehouse data with items to Excel.

------------------------------------------------------------------------

## 🛠️ Tech Stack

### Backend:

-   ASP.NET Core Web API
-   C#
-   SQL Server
-   Stored Procedures

### Frontend:

-   Angular
-   TypeScript
-   HTML / CSS
-   Bootstrap

### Database:

-   Microsoft SQL Server (Local DB)
-   Stored Procedures for data operations

------------------------------------------------------------------------

## 📂 Project Structure

WarehouseSystem/ │ ├── Backend/ │ ├── Core/ │ ├── Infrastructure/ │ ├──
API/ │ ├── Frontend/ │ ├── Angular App │ ├── Database/ │ └──
DatabaseScript.sql │ └── README.md

------------------------------------------------------------------------

## ⚙️ Database Setup

1.  Open SQL Server Management Studio (SSMS)
2.  Create a new database: CentralSupplyUnit
3.  Open file: /Database/DatabaseScript.sql
4.  Execute the script to create:
    -   Tables
    -   Relationships
    -   Stored Procedures

------------------------------------------------------------------------

## 🚀 How to Run the Project

### Backend (ASP.NET Core)

1.  Open solution in Visual Studio
2.  Update connection string in appsettings.json
3.  Run the API: https://localhost:xxxx

------------------------------------------------------------------------

### Frontend (Angular)

1.  Open terminal in Frontend folder
2.  Install dependencies: npm install
3.  Run project: ng serve
4.  Open browser: http://localhost:4200

------------------------------------------------------------------------

## 🔗 Features

### Warehouse Module

-   Create warehouses (Manager only)
-   View all warehouses
-   View items inside each warehouse
-   Delete warehouse
-   Export warehouses with items to Excel

------------------------------------------------------------------------

### Item Management

-   Items belong to warehouses
-   Dynamic loading based on selected warehouse

------------------------------------------------------------------------

### Supply Document Module

-   Create supply documents
-   Link warehouse and item
-   Track status (Pending / Approved / Rejected)

------------------------------------------------------------------------

## 📥 Export Feature

-   Export warehouses with items to Excel
-   Implemented using ClosedXML in backend
-   Download triggered from frontend

------------------------------------------------------------------------

## 👤 Roles

-   Manager (Full access to Warehouse module)
-   Admin (View supply documents And add )


------------------------------------------------------------------------

## 👩‍💻 Developer

Raneem Obeidat

------------------------------------------------------------------------

## 📌 Notes

-   Local SQL Server database
-   Stored Procedures used for main logic
-   Separated frontend and backend architecture
