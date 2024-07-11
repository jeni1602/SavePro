
using Microsoft.EntityFrameworkCore;
using SavePro.Models;

namespace SavePro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Video> Videos { get; set; }
    }
}
