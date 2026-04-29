using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistence
{
    public  class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Events.Any())
                return;

            var Evento = new Event
            {
                Name = "Concierto de Rock",
                EventTime = DateTime.Now.AddDays(10),
                Status = EventStatus.Scheduled,
                Venue = "Estadio"
            };

            context.Events.Add(Evento);
            context.SaveChanges();

            var SectorA = new Sector
            {
                EventId = Evento.Id,
                Name = "VIP",
                Price = 100000,
                Capacity = 50
            };

            var SectorB = new Sector
            {
                EventId = Evento.Id,
                Name = "General",
                Price = 50000,
                Capacity = 50,
            };

            context.Sectors.Add(SectorA);
            context.Sectors.Add(SectorB);
            context.SaveChanges();


            char rowvip = 'A';
            char rowgeneral = 'F';
            for(int i = 1; i <= 50; i++)
            {
                context.Seats.Add(new Seat
                {
                    SectorId = SectorA.Id,
                    SeatNumber = ((i-1)%10)+1,
                    RowIdentifier = rowvip.ToString(),
                    Status = SeatStatus.Available,
                });
                if (i % 10 == 0)
                {
                    rowvip++;
                }

                context.Seats.Add(new Seat
                {
                    SectorId = SectorB.Id,
                    SeatNumber = ((i-1)%10)+1,
                    RowIdentifier=rowgeneral.ToString(),
                    Status = SeatStatus.Available,
                });
                if (i % 10 == 0)
                {
                    rowgeneral++;
                }
            }
            context.SaveChanges();
        }
    }
}
