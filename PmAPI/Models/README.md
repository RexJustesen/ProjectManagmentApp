# 🚀 PmAPI Project Repository 🚀

## 📂 File: Link.cs

This file is the backbone of our link management in the project. It defines the `Link` class in the `PmAPI.Models` namespace. The `Link` class represents a link entity in our project management application, with properties for `Id`, `Type`, `Source`, `Target`, and `ProjectId`. 🖇️

### 📝 Properties:

- `Id`: Gets or sets the Id of the link.
- `Type`: Gets or sets the type of the link. It can be null.
- `Source`: Gets or sets the source of the link.
- `Target`: Gets or sets the target of the link.
- `ProjectId`: Gets or sets the ProjectId that the link is associated with.

### 📚 Dependencies:

This file relies on the `System.ComponentModel.DataAnnotations.Schema` library for the `Table` attribute.

### 📌 Notes:

The `Link` class is decorated with the `[Table("Links")]` attribute, indicating that instances of this class correspond to entries in the "Links" table in the database.

## 📂 File: Ticket.cs

The `Ticket.cs` file is the ticket to managing tasks in our project. It defines the `Ticket` class in the `PmAPI` project. The `Ticket` class represents a ticket in a project management system, with properties such as `Id`, `Text`, `StartDate`, `Duration`, `Progress`, `ParentId`, `Type`, and `ProjectId`. 🎟️

### 📝 Properties:

- `Id`: Represents the unique identifier of the ticket.
- `Text`: Represents the text or description of the ticket.
- `StartDate`: Represents the start date of the ticket.
- `Duration`: Represents the duration of the ticket.
- `Progress`: Represents the progress of the ticket.
- `ParentId`: Represents the identifier of the parent ticket, if any.
- `Type`: Represents the type of the ticket.
- `ProjectId`: Represents the identifier of the project that the ticket belongs to.

### 📚 Dependencies:

This file relies on the `System.ComponentModel.DataAnnotations.Schema` library for the `Table` attribute.

### 📌 Notes:

The `Ticket` class is decorated with the `Table` attribute, indicating that it corresponds to the "Tickets" table in the database. Some properties are nullable, indicated by the '?' symbol, meaning they may not always have a value.

## 📂 File: Project.cs

The `Project.cs` file is the heart of our application. It represents a `Project` entity with properties such as `Name`, `Id`, `Tickets`, and `Links`. 🏗️

### 📝 Properties:

- `Name`: Holds the name of the project. It is a nullable string.
- `Id`: Holds the unique identifier of the project. It is a nullable integer.
- `Tickets`: Holds a list of `Ticket` objects associated with the project. It is initialized as a new list of `Ticket` objects.
- `Links`: Holds a list of `Link` objects associated with the project. It is initialized as a new list of `Link` objects.

### 📚 Dependencies:

This file depends on the `PmAPI.DTO` namespace, which likely contains the `Ticket` and `Link` classes.

### 📌 Notes:

The properties `Name` and `Id` are nullable, which means they can hold a null value. The `Tickets` and `Links` properties are initialized as new lists, which means they will not be null but can be empty.

That's all folks! Feel free to explore and contribute to our project. Happy coding! 🚀👩‍💻👨‍💻🚀
