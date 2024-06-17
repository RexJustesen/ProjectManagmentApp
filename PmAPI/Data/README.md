# 🚀 Project Management API Repository 🚀

## 📁 File Overview 📁

### 🌱 Seed.cs 🌱

The `Seed.cs` file is our little gardener, planting the initial seeds in our database. It creates a set of projects and tickets with predefined values. 🌳

#### 🛠️ Functions/Methods 🛠️

- `SeedTickets(DataContext context)`: An asynchronous method that seeds the database with initial data. It checks if there are any projects in the database, and if not, it creates a new project and a set of tickets, and saves them to the database.

#### 🧩 Dependencies 🧩

- Microsoft.EntityFrameworkCore
- PmAPI.Models
- PmAPI.Data

#### 📚 Usage Examples 📚

The `SeedTickets` method is likely used during the initialization of the application to populate the database with initial data. It might be called in a method like this:

```csharp
public async Task InitializeDatabase()
{
    await Seed.SeedTickets(context);
}
```

### 📚 DataContext.cs 📚

The `DataContext.cs` file is the mastermind behind interacting with the database using Entity Framework Core. It defines the DbContext with DbSet for Project, Ticket, and Link entities and configures the relationships between these entities. 🧠

#### 🛠️ Functions/Methods 🛠️

- `DataContext(DbContextOptions<DataContext> options)`: The constructor of the DataContext class.
- `OnModelCreating(ModelBuilder modelBuilder)`: This method configures the relationships between the Project, Ticket, and Link entities.

#### 🧩 Dependencies 🧩

- Microsoft.EntityFrameworkCore
- PmAPI.Models

### 📂 ProjectRepository.cs 📂

The `ProjectRepository.cs` file is the repository class for managing data operations related to projects. It provides methods for retrieving projects from a database context. 🗂️

#### 🛠️ Functions/Methods 🛠️

- `ProjectRepository(DataContext context, IMapper mapper)`: The constructor of the class.
- `GetProjectsAsync()`: Retrieves all projects from the database and maps them to ProjectDto objects.
- `GetProjectByIdAsync(int id)`: Retrieves a project by its ID from the database.
- `GetProjectAsync(string name)`: Retrieves a project by its name from the database and maps it to a ProjectDto object.
- `GetProjectByNameAsync(string name)`: Retrieves a project by its name from the database, including its associated Tickets and Links.

#### 🧩 Dependencies 🧩

- AutoMapper
- Microsoft.EntityFrameworkCore
- PmAPI.DTO
- PmAPI.Interfaces
- PmAPI.Models
- Microsoft.AspNetCore.Http.HttpResults

## 📝 Notes 📝

- The `ProjectRepository` class implements the `IProjectRepository` interface.
- The `GetProjectByNameAsync` method includes related Tickets and Links when retrieving a project.
- The `GetProjectsAsync` and `GetProjectAsync` methods use AutoMapper to map the retrieved projects to ProjectDto objects.

That's all, folks! Enjoy exploring the repository and happy coding! 🎉👩‍💻👨‍💻🎉
