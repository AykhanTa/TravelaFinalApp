using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Data
{
    public class TravelaDbContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Guide> Guide { get; set; }
        public DbSet<GuideSocial> GuideSocials { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TourCategory> TourCategories { get; set; }

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
