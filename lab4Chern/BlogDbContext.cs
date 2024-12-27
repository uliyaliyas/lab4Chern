using lab4Chern.Models;
using Microsoft.EntityFrameworkCore;

namespace lab4Chern
{
    public class BlogDbContext:DbContext 
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
