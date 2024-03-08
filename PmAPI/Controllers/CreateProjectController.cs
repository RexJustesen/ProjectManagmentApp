using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;
using PmAPI.Hubs;
using PmAPI.Models;

namespace PmAPI.Controllers
{
    
    public class CreateProjectController : BaseApiController
    {
        private readonly DataContext _context;

        private readonly IHubContext<ProjectsHub> _hubContext;

        public CreateProjectController(DataContext context, IHubContext<ProjectsHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectDto projectDto)
        {
            Random rnd = new Random();
            

            if (await ProjectExists(projectDto.Name)) return BadRequest("Project Name is taken");

            var project = new Project
            {
                Name = projectDto.Name.ToLower(),
                Id = rnd.Next()
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveProjectUpdate", $"New project {project.Name} created");

            return new ProjectDto
            {
                Name = project.Name,
                Id = project.Id
            };
        }

        private async Task<bool> ProjectExists(string name)
        {
            return await _context.Projects.AnyAsync(x => x.Name == name.ToLower());

        }

    }
}