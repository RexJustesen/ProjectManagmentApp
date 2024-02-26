using PmAPI.Models;

namespace PmAPI.DTO
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
        public List<Link> Links { get; set; } = new();


            public static explicit operator ProjectDto(Project project)
        {
            return new ProjectDto
            {
                Name = project.Name,
                Id = project.Id
            };
        }
            public static explicit operator Project(ProjectDto project)
        {
            return new Project
            {
                Name = project.Name,
                Id = project.Id
            };
        }
    }

    
}