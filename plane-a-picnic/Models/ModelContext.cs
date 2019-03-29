using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
                .HasMany(c => c.Regions)
                .WithOne(r => r.Country);
            modelBuilder.Entity<RegionModel>()
                .HasMany(c => c.Airports)
                .WithOne(a => a.Region);
            modelBuilder.Entity<AirportModel>()
                .HasMany(a => a.Runways)
                .WithOne(r => r.Airport);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ModelContextFactory : IDesignTimeDbContextFactory<ModelContext>
    {
        ModelContext IDesignTimeDbContextFactory<ModelContext>.CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../plane-a-picnic"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer<ModelContext>(connectionString);

            return new ModelContext(optionsBuilder.Options);
        }
    }
}