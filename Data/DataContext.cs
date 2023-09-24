using AppointmentschedularService.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentschedularService.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<User>users { get; set; }
        public DbSet<Appointment> appointments { get; set; }


    }
}
