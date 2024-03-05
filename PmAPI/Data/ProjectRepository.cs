using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PmAPI.DTO;
using PmAPI.Interfaces;
using PmAPI.Models;

namespace PmAPI.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            return await _context.Projects
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                        .FindAsync(id);
        }


        public async Task<ProjectDto> GetProjectAsync(string name)
        {
            return await _context.Projects
                .Where(x => x.Name == name)
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

        }
        
        public async Task<Project> GetProjectByNameAsync(string name)
        {
            return await _context.Projects
                .Include(p => p.Tickets)
                .Include(p => p.Links)
                .SingleOrDefaultAsync(p => p.Name == name);
        }

    
    }
}