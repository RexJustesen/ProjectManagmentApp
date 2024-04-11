Welcome to the PmAPI repository! This is a project management application that provides a robust API for managing projects, tickets, and links. It's built with .NET Core and uses Entity Framework Core for data access, AutoMapper for object-object mapping, and SignalR for real-time communication. 

## 📁 Files Overview

### Program.cs 🚀

This is the main entry point for the PmAPI application. It sets up the application, configures services, sets up routing, CORS, and authorization, and runs the application. It also handles database migration and seeding. 

### ITicketService.cs 🎫

This file is an interface for the Ticket Service. It defines the methods that any class implementing this interface should have. These methods are related to the creation and retrieval of tickets in a project.

### IProjectRepository.cs 📚

This file is an interface that defines the contract for a Project Repository. It outlines the methods that any class implementing this interface should have. These methods are primarily used for retrieving project data from a database.

### LinkDto.cs 🔗

This file defines a Data Transfer Object (DTO) for a Link. It is used to transfer data between processes. It contains properties like id, type, source, target, and projectId. It also includes methods to convert a Link object to a LinkDto object and vice versa.

### TicketDto.cs 🎫

This file defines a Data Transfer Object (DTO) for a Ticket in the PmAPI project. It is used to transfer data between processes or layers within the application. It also includes methods to convert between the DTO and the Ticket model.

### ProjectDto.cs 📚

This file defines a Data Transfer Object (DTO) for a Project. It is used to transfer data between processes. In this case, it is used to transfer data related to a project, including its name, id, tickets, and links.

### ProjectController.cs 🎮

This file is a controller in a project management application. It handles HTTP requests related to projects, tickets, and links. It provides functionalities such as getting all projects, getting a project by name or id, deleting a project, getting tickets by project, creating a ticket, deleting a ticket, updating a ticket, getting links by project, creating a link, and deleting a link.

### BaseApiController.cs 🎮

This file serves as the base controller for the API. All other API controllers will inherit from this base controller.

### CreateProjectController.cs 🎮

This file is a controller in an ASP.NET Core application that handles the creation of new projects. It interacts with a database context to add new projects and uses SignalR to notify all clients when a new project is created.

### LinkController.cs 🔗

This file is a controller in the PmAPI project that handles HTTP requests related to the 'Link' entity. It provides functionalities to get all links, create a new link, and delete an existing link.

### WeatherForecastController.cs 🌦️

This file is a controller in an ASP.NET Core application that provides an API endpoint for getting weather forecasts.

### TicketController.cs 🎫

This file is a controller for managing tickets in a project management application. It provides methods for getting, creating, deleting, and updating tickets.

### ApplicationServiceExtensions.cs 🛠️

This file is part of the PmAPI project and is used to extend the IServiceCollection interface. It primarily sets up the application services, including the database context, CORS, repositories, AutoMapper, SignalR, and controllers.

### AutoMapperProfiles.cs 🗺️

The primary purpose of this file is to define the mapping between the Project model and the ProjectDto (Data Transfer Object). This is done using the AutoMapper library, which simplifies the process of transforming data from one object type to another.

### Link.cs 🔗

This file defines the Link model in the PmAPI application. A Link represents a connection between two entities (Source and Target) in a specific project. It also has a Type property to categorize the link.

### Ticket.cs 🎫

This file defines the Ticket class in the PmAPI.Models namespace. The Ticket class represents a ticket in a project management system, with properties for ID, text, start date, duration, progress, parent ID, type, and project ID.

### Project.cs 📚

This file defines the Project class in the PmAPI.Models namespace. The Project class represents a project in the system, with properties for the project's name, ID, tickets, and links.

### TicketService.cs 🎫

The TicketService.cs file is a service layer in the application that handles the business logic related to tickets. It provides methods for getting all tickets associated with a specific project and creating a new ticket for a project.

### TicketsHub.cs 📡

The TicketsHub.cs file is a SignalR Hub in the PmAPI namespace. It is primarily used for real-time communication, specifically for sending ticket and link updates to all connected clients.

### ProjectsHub.cs 📡

The primary purpose of this file is to handle real-time communication in a project management application. It uses SignalR to send project updates to all connected clients.

### Seed.cs 🌱

The Seed.cs file is used to seed the database with initial data. It contains a method that creates and adds new projects and tickets to the DataContext.

### DataContext.cs 🗃️

The primary purpose of this file is to set up the data context for the application. It defines the database context used by Entity Framework Core, including the entities (tables) and their relationships.

### ProjectRepository.cs 📚

This file is a repository class for managing project-related data operations. It provides methods for retrieving project data from a database context, including getting all projects, getting a project by its ID, and getting a project by its name.

## 🚀 Let's Get Started!

Now that you have a high-level overview of the files and their roles in the PmAPI project, feel free to explore the codebase. Happy coding! 🎉
