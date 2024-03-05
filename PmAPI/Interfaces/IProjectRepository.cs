using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PmAPI.DTO;
using PmAPI.Models;

namespace PmAPI.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectDto>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<ProjectDto> GetProjectAsync(string name);
        Task<Project> GetProjectByNameAsync(string name);

    }
}