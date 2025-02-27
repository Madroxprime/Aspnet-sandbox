using Microsoft.EntityFrameworkCore;
using ServiceRequestTracker.Models;

namespace ServiceRequestTracker.Data
{
    /*
     * Really wanted to name this ServiceContext, but any one else trying to work on this is going to get
     * tripped up when they read any reference documentation, since AppDbContext is almost universal. 
    */
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequest> Requests { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Asset> Assets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Primarykeys
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<ServiceRequest>()
                .HasKey(sr =>  sr.ServiceRequestId);
            modelBuilder.Entity<Location>()
                .HasKey(l => l.LocationId);
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            // Define Relationships

            modelBuilder.Entity<User>()
                .HasMany(u => u.Locations)
                .WithMany(l => l.Users);
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRequests)
                .WithOne(sr => sr.Requester);
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(r => r.Requester)
                .WithMany(u => u.UserRequests);
            modelBuilder.Entity<Location>()
                .HasMany(l => l.LocationRequests)
                .WithOne(sr => sr.RequestLocation);
            modelBuilder.Entity<ServiceRequest>()
                .HasDiscriminator<Discriminator>("RequestType")
                .HasValue<ITServiceRequest>(Discriminator.IT)
                .HasValue<HRServiceRequest>(Discriminator.HR)
                .HasValue<MaintanceRequest>(Discriminator.Maintanance);
            modelBuilder.Entity<ITServiceRequest>()
                .HasOne(it => it.Asset)
                .WithMany(a => a.ServiceHistory);

        }
        public AppDBContext(DbContextOptions<AppDBContext> Options)
            : base(Options)
        {

        }
    }
}
