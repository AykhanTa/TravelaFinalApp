using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Data
{
    public class TravelaDbContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public TravelaDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
