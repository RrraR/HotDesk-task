
# HotDesk-task

This project implements a service created to manage workplace reservation in the real office.


## Configuration

This project uses MSSQL and MSSQL managment studio 18
1. Change database settings in appsettings.json

```csharp
  "ConnectionStrings": {"Default": "Server=localhost\\SQLEXPRESS;Database=WWTBAM-task;Trusted_Connection=True;TrustServerCertificate=True"}
```
2. Run Database.sql file to create database. It will also populate all the tables except for Reservations table which can be populated from the applicaion itself. Database.sql file also contains a stored procedure DeleteOnExpirationDate that will delete all reservations which expiration dates have already passed. 




## Database structure

![App Screenshot](HotDeskDB.png?raw=true "Database Structure")


## How to use

1. Populte database with your data or use existing data

2. Create new reservations using interface


## Features

- ASP.Net MVC
- Entity Framework Core
- Microsoft SQL Server
- Repository-Service Pattern

