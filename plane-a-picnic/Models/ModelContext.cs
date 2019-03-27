using Microsoft.EntityFrameworkCore;

namespace plane_a_picnic.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        public DbSet<AirportModel> Airports { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
        public DbSet<RunwayModel> Runways { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>()
                .HasMany(c => c.Airports)
                .WithOne(a => a.Country);
            modelBuilder.Entity<RegionModel>()
                .HasMany(c => c.Airports)
                .WithOne(a => a.Region);
            modelBuilder.Entity<AirportModel>()
                .HasMany(a => a.Runways)
                .WithOne(r => r.Airport);

            base.OnModelCreating(modelBuilder);
        }
    }
}