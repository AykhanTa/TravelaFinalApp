using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Data
{
    public class TravelaDbContext : IdentityDbContext<AppUser>
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
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageImage> PackageImages { get; set; }

        public TravelaDbContext(DbContextOptions<TravelaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Member",
                    NormalizedName = "MEMBER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            var hasher = new PasswordHasher<AppUser>();
            List<AppUser> users = new List<AppUser>
            {
                new AppUser
                {
                    FullName="Ulvi Majid",
                    UserName = "ulvim9",
                    Email = "admin@example.com",
                    NormalizedUserName = "ULVIM9",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Ulvi123!"),
                    EmailConfirmed = true,
                },
                new AppUser
                {
                    FullName="Aykhan Taghizada",
                    UserName = "aykhant1",
                    Email = "user@example.com",
                    NormalizedUserName = "AYKHANT1",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Ayxan123!"),
                    EmailConfirmed = true,
                }
            };
            modelBuilder.Entity<AppUser>().HasData(users);

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = roles.First(r => r.Name == "Admin").Id,
                    UserId = users.First(u => u.UserName == "ulvim9").Id
                },
                 new IdentityUserRole<string>
                {
                    RoleId = roles.First(r => r.Name == "Member").Id,
                    UserId = users.First(u => u.UserName == "aykhant1").Id
                },
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            base.OnModelCreating(modelBuilder);
        }
    }
}
