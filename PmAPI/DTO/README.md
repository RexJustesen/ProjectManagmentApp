# 🚀 PmAPI Repository README.md 🚀

Welcome to the PmAPI repository! This is where we manage our Data Transfer Objects (DTOs) for our project management system. We have three main DTOs: `LinkDto`, `TicketDto`, and `ProjectDto`. Let's dive in! 🏊‍♂️

## 📎 LinkDto.cs 📎

Our `LinkDto` is a crucial part of our data transfer process. It's like the postman 📬 of our application, carrying data about links between processes. It includes properties like `id`, `type`, `source`, `target`, and `projectId`. 

But that's not all! It also includes methods to convert a `Link` object to a `LinkDto` object and vice versa. Here's how you can use it:

```csharp
Link link = new Link();
LinkDto linkDto = (LinkDto)link;
```
And to convert it back:

```csharp
LinkDto linkDto = new LinkDto();
Link link = (Link)linkDto;
```
Remember, this file depends on the `PmAPI.Models` namespace, specifically the `Link` model.

## 🎫 TicketDto.cs 🎫

Next up, we have the `TicketDto`. This is the ticket master 🎟️ of our project management system, transferring data about tickets between processes or layers in the application. 

Just like `LinkDto`, it also includes methods for converting between the DTO and the `Ticket` model. Here's how you can use it:

```csharp
Ticket ticket = new Ticket();
TicketDto ticketDto = (TicketDto)ticket;
```
And to convert it back:

```csharp
TicketDto ticketDto = new TicketDto();
Ticket ticket = (Ticket)ticketDto;
```
This file depends on the `System.Text.Encodings.Web` library for HTML encoding, and the `PmAPI.Models` namespace for the `Ticket` model.

## 📁 ProjectDto.cs 📁

Last but not least, we have the `ProjectDto`. This is the project manager 📋 of our application, transferring data about projects between processes. It includes properties for the project's `name`, `id`, `tickets`, and `links`.

Just like its siblings, it also includes methods to convert between a `Project` and a `ProjectDto`. Here's how you can use it:

```csharp
Project project = new Project { Name = "Project1", Id = 1 };
ProjectDto projectDto = (ProjectDto)project;
```
And to convert it back:

```csharp
ProjectDto projectDto = new ProjectDto { Name = "Project1", Id = 1 };
Project project = (Project)projectDto;
```
This file depends on the `PmAPI.Models` namespace, which includes the `Project`, `Ticket`, and `Link` classes.

## 📚 Final Notes 📚

Remember, all these DTOs are part of the `PmAPI.DTO` namespace. They include nullable properties, which means they can be left empty when creating a new object. 

So, that's it! You're now ready to dive into the world of data transfer with our DTOs. Happy coding! 🎉👩‍💻👨‍💻🎉
