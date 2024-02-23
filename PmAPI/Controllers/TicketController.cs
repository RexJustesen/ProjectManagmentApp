using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;
using PmAPI.Models;

namespace PmAPI.Controllers
{
    public class TicketController : BaseApiController
    {
        private readonly DataContext _context;

        public TicketController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Tickets
                                .OrderBy(t => t.Id)
                                .Select(t => (TicketDto)t)
                                .ToListAsync();

            return Ok(new { data });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketDto ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            try
            {
                var payload = (Ticket)ticket;
        
                // Get the maximum ID currently in the database
                int maxId = await _context.Tickets.MaxAsync(t => (int?)t.Id) ?? 0;
        
                // Increment the maximum ID by 1 to get the next available ID
                payload.Id = maxId + 1;
        
                await _context.Tickets.AddAsync(payload);
                await _context.SaveChangesAsync();
        
                return CreatedAtAction(nameof(Get), new { id = payload.Id }, payload);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create ticket");
            }
        }

    }
}