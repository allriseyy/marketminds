# marketminds
This is a stock market /social media platform <br/>
Tutorial : https://www.youtube.com/watch?v=qBTe6uHJS_Y&list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc&index=2

# How to setup
1. install Visual Studio
2. install Microsoft SQL Server
3. install SQL Serer Management Studio 20
4. clone the repo
```bash
git clone https://github.com/allriseyy/marketminds.git
```
5. change the connection string in **appsettings.json**
```bash
"DefaultConnection": "Data Source={Your SQL Server Name};Initial Catalog={yourdatabasename};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
```
6. create a database called **marketmindsdb**
7. run the initial migration files to migrate the database changes
```bash
dotnet ef database update
```
4. build and run the solution
5. done! You are ready to go

# Debug
```bash
dotnet watch run
```

# Documentation
```bash
http://localhost:<port>/swagger/index.html
http://localhost:<port>/openapi/v1.json
```

# Dependencies
install using dotnet or NuGet Packages
```bash
dotnet add package name.of.the.package
```
![image](https://github.com/user-attachments/assets/c0c1e3f6-440e-4a3e-abec-adbfe23a7638)

# Useful commands and links
```bash
dotnet ef migrations add init     #initialize database
dotnet ef migrations remove     #remove migration
dotnet ef migrations add NameOfMigration     #add new migration
dotnet ef database update     #update database
```

# Notes
## how to create a new model
Models -> Data -> Dtos > Mappers -> Controllers <br/>
for example: <br/>
![image](https://github.com/user-attachments/assets/cdec8674-d0fe-4d13-b9c9-3572c1a8450e)

# The ingredients
## IDE
Visual Studio <br/>
SQL Server Management Studio 20

## Language
C# <br/>
SQL

## Framework
.NET 9.0

## OS
Windows

## Platform
Web API

## Database Management System
MySQL
