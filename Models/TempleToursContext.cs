using System;
using Microsoft.EntityFrameworkCore;

namespace TempleTours.Models
{
    public class TempleToursContext: DbContext
    {
        public TempleToursContext()
        {
        }
        public TempleToursContext(DbContextOptions<TempleToursContext> options)
            : base(options)
        {
        }
        //Name the data table
        public DbSet<Appointment> Appointments { get; set; }
        

    }
}
