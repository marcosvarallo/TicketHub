using Microsoft.EntityFrameworkCore;
using TicketHub.Api.Models;

namespace TicketHub.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
