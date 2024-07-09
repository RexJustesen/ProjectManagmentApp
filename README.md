Welcome to the PmAPI repository! This is a project management application that provides a robust API for managing projects, tickets, and links. It's built with .NET Core and uses Entity Framework Core for data access, AutoMapper for object-object mapping, and SignalR for real-time communication. 

## Environment setup

1. To run this application succesfully in a development server you will need C# and .Net 7. You can use the following links to get a tutorial on how to install both of these onto your machine and OS of choice. 

https://www.w3schools.com/cs/cs_getstarted.php

https://learn.microsoft.com/en-us/dotnet/core/install/windows

2. Clone the repository

Clone the repository by copying and pasting the following command in your terminal:

```bash
git clone https://github.com/RexJustesen/ProjectManagmentApp.git
```

3. Navigate to the project directory 

Change your current directory to the root of the project directory 

```bash
cd <repository-directory>
```
4. Restore dependencies 
Use the .NET CLI to restore the dependencies specified in the project file (e.g., .csproj or .fsproj). Run:
```bash
dotnet restore
```
5. Build the project 
Build the project to ensure all dependencies are correctly installed and the project compiles without errors:
```bash
dotnet build
```
6. Run the application 
Run the application using the .NET CLI.
```bash
dotnet run
```

# TODO

1. Refactor the controllers to correctly use interfaces and services to decouple dependencies. 
2. Clean up and comment code effectively. 
