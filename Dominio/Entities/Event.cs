using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventTime { get; set; }
        public EventStatus Status { get; set; }
        public string Venue { get; set; }
        public List<Sector> Sectors { get; set; } = new();//Relacion
    }
    public enum EventStatus
    {
        Scheduled,
        Ongoing,
        Finished,
        Cancelled
    }
}
