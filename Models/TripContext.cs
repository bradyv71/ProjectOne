using Microsoft.EntityFrameworkCore;

namespace ProjectOne.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}