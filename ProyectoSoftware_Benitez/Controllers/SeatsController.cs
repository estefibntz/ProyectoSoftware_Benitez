using Infraestructura.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSoftware_Benitez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SeatsController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {
            var seats = await _context.Seats
                .OrderBy(s=>s.RowIdentifier)
                .ThenBy(s=>s.SeatNumber)
                .Select(s => new
                {
                    s.Id,
                    s.SeatNumber,
                    s.RowIdentifier,
                    Status= s.Status.ToString(),
                    s.SectorId
                })
         

                .ToListAsync();
            return Ok(seats);
        }
    }
}
