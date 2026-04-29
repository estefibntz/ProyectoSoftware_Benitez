using Dominio.Entities;
using Infraestructura.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoSoftware_Benitez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReservationsController (AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ReserveSeat(int seatId,int userId)
        {
            var seat = await _context.Seats.FindAsync(seatId);
            if (seat == null)
            {
                return NotFound("Butaca no encontrada");
            }
            if (seat.Status!= SeatStatus.Available)
            {
                return BadRequest("Butaca no disponible");
            }

            seat.Status = SeatStatus.Reserved;
            var reservation = new Reservation
            {
                SeatId = seatId,
                UserId = userId,
                Status = ReservationStatus.Confirmed,
                ReservedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddMinutes(5),
            };
            _context.Reservations.Add(reservation);

            var log = new Audit_log
            {
                UserId = userId,
                Action = "Reserva",
                EntityType = "Seat",
                EntityId = seatId.ToString(),
                Details = "Reserva creada",
                CreatedAt = DateTime.Now,
            };
            _context.Audit_Logs.Add(log);
            await _context.SaveChangesAsync();
            return Ok("Reserva Exitosa");
        }
    }
}
