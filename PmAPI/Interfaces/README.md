# 🚀 Project Management API - README.md 🚀

Welcome to the Project Management API repository! This repository is home to a couple of key interfaces that are integral to the functioning of our project management application. Let's dive in and explore what each file does! 🕵️‍♀️

## 🎫 ITicketService.cs 🎫

This file is the blueprint for our Ticket Service. It outlines the methods that any class implementing this interface should have. These methods are all about managing tickets within a project. 🎟️

Here's a quick rundown of the methods:

1. **GetTicketsAsync(int projectId)**: Fetches all tickets associated with a specific project. 📑
2. **CreateTicketAsync(int projectId, Ticket ticket)**: Creates a new ticket for a specific project. 🆕
3. **DeleteTicketAsync(long id)**: This method is currently on a break (commented out), but when it's back, it'll be used to delete a specific ticket by its ID. 🗑️
4. **UpdateTicketAsync(long id, TicketDto ticket)**: Another method on a break, but when it's back, it'll be used to update a specific ticket by its ID. 🔄

This file is powered by the following external libraries or models:

1. System
2. System.Collections.Generic
3. System.Linq
4. System.Threading.Tasks
5. PmAPI.DTO
6. PmAPI.Models

## 📚 IProjectRepository.cs 📚

This file is the contract for our Project Repository. It outlines the methods that any class implementing this interface should have. These methods are all about retrieving project data from a database or data source. 🗃️

Here's a quick rundown of the methods:

1. **GetProjectsAsync()**: Retrieves all projects asynchronously. 📑
2. **GetProjectByIdAsync(int id)**: Retrieves a specific project by its ID asynchronously. 🔍
3. **GetProjectAsync(string name)**: Retrieves a specific project by its name asynchronously. 🔍
4. **GetProjectByNameAsync(string name)**: Retrieves a specific project by its name asynchronously. 🔍

This file is powered by the following external libraries or namespaces:

1. System
2. System.Collections.Generic
3. System.Linq
4. System.Threading.Tasks
5. PmAPI.DTO
6. PmAPI.Models

That's all for now, folks! Stay tuned for more updates and feel free to contribute. Happy coding! 🎉👩‍💻👨‍💻🎉
