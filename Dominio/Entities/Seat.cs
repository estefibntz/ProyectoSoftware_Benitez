using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus Status { get; set; }
        public Sector Sector { get; set; }//relacion


    }
    public enum SeatStatus
    {
        Available,
        Reserved,
        Sold
    }
}
