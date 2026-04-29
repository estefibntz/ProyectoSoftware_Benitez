using Infraestructura.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSoftware_Benitez.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents(int page = 1, int pageSize = 10)
        {
            var events = await _context.Events
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.EventTime,
                    Status=e.Status.ToString(),
                    e.Venue
                })
                .ToListAsync();
            return Ok(events);
        }


    }
}
