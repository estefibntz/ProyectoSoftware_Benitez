using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;

namespace Infraestructura.Persistence
{
    public class AppDbContext: DbContext //Defino el contexto para gestionar las operaciones con la BD mediante EF
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        //Se utiliza inyeccion de dependencias para recibir config del contexto

        public DbSet<Event> Events { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Audit_log> Audit_Logs { get; set; }
        public DbSet<User> Users { get; set; } 
        //Defino un DbSet por cada entidad para poder consultarlas en la bd como tablas 
    }
}
