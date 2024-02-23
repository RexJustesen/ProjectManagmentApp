using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PmAPI.Data;
using PmAPI.DTO;

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
    }
}