using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;
using PmAPI.Interfaces;
using PmAPI.Models;

namespace PmAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TicketService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int projectId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.ProjectId == projectId)
                .OrderBy(t => t.Id)
                .ToListAsync();

            return _mapper.Map<IEnumerable<Ticket>>(tickets);
        }

        public async Task<Ticket> CreateTicketAsync(int projectId, Ticket ticket)
        {
            int maxId = await _context.Projects
                    .Where(p => p.Id == projectId)
                    .SelectMany(p => p.Tickets)
                    .MaxAsync(t => (int?)t.Id) ?? 0;
        
            // Increment the maximum ID by 1 to get the next available ID
           ticket.Id = maxId + 1;
           ticket.ProjectId = projectId;

            return ticket;
        }
    }
}