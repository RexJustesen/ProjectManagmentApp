# 🚀 Project Management API 🚀

Welcome to the Project Management API repository! This API is designed to help you manage your projects, tickets, and links with ease. Let's dive into the details! 🏊‍♂️

## 📁 Files and their Roles 📁

### 1️⃣ ProjectController.cs

This is the heart of our project management application. It provides endpoints for creating, reading, updating, and deleting projects, tickets, and links associated with a project. It's like the conductor of an orchestra, making sure everything is in harmony. 🎵

### 2️⃣ BaseApiController.cs

This is the foundation upon which all our controllers are built. It sets the basic route and API controller attributes for all controllers that inherit from it. Think of it as the base camp for our API expedition. 🏕️

### 3️⃣ CreateProjectController.cs

This controller is the birthplace of new projects. It interacts with a database context to add new projects and uses SignalR to notify all clients when a new project is created. It's like the stork delivering a new baby project. 🍼

### 4️⃣ LinkController.cs

This controller manages operations related to 'Link' objects. It provides endpoints for getting all links, creating a new link, and deleting a link. It's like the postman of our application, handling all the links. 💌

### 5️⃣ TicketController.cs

This controller is for managing tickets in our project management application. It provides methods for getting, creating, deleting, and updating tickets. It's like the ticket booth at a carnival, managing all the tickets. 🎟️

## 📚 Dependencies 📚

Our API relies on several libraries and packages, including AutoMapper, Microsoft.AspNetCore.Mvc, Microsoft.AspNetCore.SignalR, Microsoft.EntityFrameworkCore, and more. These are like the ingredients in our API recipe. 🍲

## 🎮 Usage Examples 🎮

Here are some examples of how you can use our API:

- To get a list of all projects: `GetProjects()`
- To get a specific project by its name: `GetProject("ProjectName")`
- To delete a specific project by its ID: `DeleteProject(1)`
- To get a list of tickets associated with a specific project: `GetTicketsByProject(1)`
- To create a new ticket associated with a specific project: `CreateTicket(1, new TicketDto { /* ticket data */ })`

## 📝 Notes 📝

- Our controllers use dependency injection to get instances of DataContext, IProjectRepository, ITicketService, IMapper, and IHubContext.
- We use HTTP status codes to indicate the success or failure of an operation.
- We use SignalR to send real-time updates to all connected clients when a ticket or link is created, updated, or deleted.

That's it! We hope you find our API useful and easy to use. Happy coding! 🎉
