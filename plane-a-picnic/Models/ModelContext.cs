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

            modelBuilder.Entity<CountryTagModel>()
                .HasKey(ct => new { ct.CountryId, ct.TagId });
            modelBuilder.Entity<CountryTagModel>()
                .HasOne(ct => ct.Country)
                .WithMany(c => c.Tags)
                .HasForeignKey(ct => ct.CountryId);
            modelBuilder.Entity<CountryTagModel>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.Countries)
                .HasForeignKey(ct => ct.TagId);

            modelBuilder.Entity<RegionTagModel>()
                .HasKey(rt => new { rt.RegionId, rt.TagId });
            modelBuilder.Entity<RegionTagModel>()
                .HasOne(rt => rt.Region)
                .WithMany(r => r.Tags)
                .HasForeignKey(rt => rt.RegionId);
            modelBuilder.Entity<RegionTagModel>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.Regions)
                .HasForeignKey(rt => rt.TagId);

            modelBuilder.Entity<AirportTagModel>()
                .HasKey(at => new { at.AirportId, at.TagId });
            modelBuilder.Entity<AirportTagModel>()
                .HasOne(at => at.Airport)
                .WithMany(a => a.Tags)
                .HasForeignKey(at => at.AirportId);
            modelBuilder.Entity<AirportTagModel>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.Airports)
                .HasForeignKey(at => at.TagId);

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