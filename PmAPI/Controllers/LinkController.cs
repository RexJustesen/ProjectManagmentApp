/* using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;
using PmAPI.Models;

namespace PmAPI.Controllers
{

    public class LinkController : BaseApiController
    {
        private readonly DataContext _context;

        public LinkController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var link = await _context.Links
                                .Select(l => (LinkDto)l)
                                .ToListAsync();

            return Ok( new { link });
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinkDto link)
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
        
                await _context.Links.AddAsync(payload);
                await _context.SaveChangesAsync();
        
                return CreatedAtAction(nameof(Get), new { id = payload.Id }, payload);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create ticket");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var link = await _context.Links.FindAsync(id);

            if (link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else{
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete link");
            }
        }

    }
} */