using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;
using PmAPI.Hubs;
using PmAPI.Interfaces;
using PmAPI.Models;
using PmAPI.Services;

namespace PmAPI.Controllers
{
    public class ProjectController : BaseApiController
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        private readonly IHubContext<TicketsHub> _hubContext;
        private readonly DataContext _context;

        public ProjectController(DataContext context, IProjectRepository projectRepository, ITicketService ticketService, IMapper mapper, IHubContext<TicketsHub> hubContext)
        {
            _context = context;
            _projectRepository = projectRepository;
            _ticketService = ticketService;
            _mapper = mapper;
            _hubContext = hubContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _projectRepository.GetProjectsAsync();

            return Ok(projects);
        }

       [HttpGet("{name}")]
       public async Task<ActionResult<ProjectDto>> GetProject(string name)
       {
        return await _projectRepository.GetProjectAsync(name);
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Project>> GetProjectById(int id)
       {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);
       }

       [HttpDelete("{id}")]
       public async Task<ActionResult<Project>> DeleteProject(int id)
       {
         var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return Ok();
                

            } else {
                return StatusCode(StatusCodes.Status500InternalServerError, "Project does not exist");

            }
       }

       [HttpGet("{id}/tickets")]
       public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByProject(int id)
       {
        var tickets = await _context.Tickets
                .Where(t => t.ProjectId == id)
                .OrderBy(t => t.Id)
                .ToListAsync();

        return Ok(new { tickets });
       }

       [HttpPost("{id}/tickets")]
       public async Task<IActionResult> CreateTicket(int id, TicketDto ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            try
            {
                var payload = (Ticket)ticket;
        
                int maxId = await _context.Projects
                    .Where(p => p.Id == id)
                    .SelectMany(p => p.Tickets)
                    .MaxAsync(t => (int?)t.Id) ?? 0;
        
                // Increment the maximum ID by 1 to get the next available ID
                payload.Id = maxId + 1;
                payload.ProjectId = id;
        
                await _context.Tickets.AddAsync(payload);
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("ReceiveTicketUpdate", $"New ticket {ticket.Id} created");
        
                return CreatedAtAction( nameof(GetTicketsByProject), new { id = payload.Id }, payload);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{projectId}/tickets/{ticketId}")]
        public async Task<ActionResult> DeleteTicket(long ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket != null)
            {
            
                 _context.Tickets.Remove(ticket);
                 await _context.SaveChangesAsync();
                 await _hubContext.Clients.All.SendAsync("ReceiveTicketUpdate", $"Deleted ticket {ticket.Id} created");

                 return Ok();
            } 
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete ticket");
            }
        }

        [HttpPut("{id}/tickets/{ticketId}")]
        public async Task<IActionResult> Update(long ticketId, TicketDto ticket)
        {
            var payload = (Ticket)ticket;
            payload.Id = ticketId;

            var t = await _context.Tickets.FindAsync(ticketId);

            if (t != null)
            {
                t.Text = payload.Text;
                t.StartDate = payload.StartDate;
                t.Duration = payload.Duration;
                t.ParentId = payload.ParentId;
                t.Progress = payload.Progress;
                t.Type = payload.Type;

                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReceiveTicketUpdate", $"Updated ticket {ticket.Id} created");

                return Ok( new { t } );
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update ticket");
            }
        }

        [HttpGet("{id}/links")]
        public async Task<ActionResult> GetLinksByProject(int id)
        {
            var links = await _context.Links
                .Where(t => t.ProjectId == id)
                .OrderBy(t => t.Id)
                .ToListAsync();

            return Ok( new { links });
        }

        [HttpPost("{id}/links")]
        public async Task<IActionResult> Create(int id, LinkDto link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            try
            {
                var payload = (Link)link;

                 // Get the maximum ID currently in the database
                int maxId = await _context.Links.MaxAsync(t => (int?)t.Id) ?? 0;
        
                // Increment the maximum ID by 1 to get the next available ID
                payload.Id = maxId + 1;

                payload.ProjectId = id;
        
                await _context.Links.AddAsync(payload);
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("ReceiveLinkUpdate", $"Deleted link {link.id} created");

                return CreatedAtAction(nameof(GetLinksByProject), new { id = payload.Id }, payload);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}/links/{linkId}")]
        public async Task<IActionResult> Delete(int linkId)
        {
            var link = await _context.Links.FindAsync(linkId);

            if (link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
                //await _hubContext.Clients.All.SendAsync("ReceiveLinkUpdate", $"Deleted link {link.Id} created");

                return Ok();
            }
            else{
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete link");
            }
        }
    }
}