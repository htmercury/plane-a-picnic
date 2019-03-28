﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using plane_a_picnic.Models;

namespace planeapicnic.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("plane_a_picnic.Models.AirportModel", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Continent")
                        .IsRequired();

                    b.Property<double>("ElevationFt");

                    b.Property<string>("GpsCode");

                    b.Property<string>("HomeLink");

                    b.Property<string>("IataCode");

                    b.Property<string>("Ident")
                        .IsRequired();

                    b.Property<string>("IsoCountry")
                        .IsRequired();

                    b.Property<string>("IsoRegion")
                        .IsRequired();

                    b.Property<double>("LatitudeDeg");

                    b.Property<string>("LocalCode");

                    b.Property<double>("LongitudeDeg");

                    b.Property<string>("Municipality")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("RegionId")
                        .IsRequired();

                    b.Property<bool>("ScheduledService");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("WikipediaLink");

                    b.HasKey("AirportId");

                    b.HasIndex("RegionId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("plane_a_picnic.Models.AirportTagModel", b =>
                {
                    b.Property<int>("AirportId");

                    b.Property<int>("TagId");

                    b.HasKey("AirportId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AirportTagModel");
                });

            modelBuilder.Entity("plane_a_picnic.Models.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Continent")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("WikipediaLink")
                        .IsRequired();

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("plane_a_picnic.Models.CountryTagModel", b =>
                {
                    b.Property<int>("CountryId");

                    b.Property<int>("TagId");

                    b.HasKey("CountryId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CountryTagModel");
                });

            modelBuilder.Entity("plane_a_picnic.Models.RegionModel", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Continent")
                        .IsRequired();

                    b.Property<int?>("CountryId")
                        .IsRequired();

                    b.Property<string>("IsoCountry")
                        .IsRequired();

                    b.Property<string>("LocalCode")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("WikipediaLink")
                        .IsRequired();

                    b.HasKey("RegionId");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("plane_a_picnic.Models.RegionTagModel", b =>
                {
                    b.Property<int>("RegionId");

                    b.Property<int>("TagId");

                    b.HasKey("RegionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RegionTagModel");
                });

            modelBuilder.Entity("plane_a_picnic.Models.RunwayModel", b =>
                {
                    b.Property<int>("RunwayId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirportId")
                        .IsRequired();

                    b.Property<bool>("Closed");

                    b.Property<double?>("HeDisplacedThresholdFt");

                    b.Property<double?>("HeElevationFt");

                    b.Property<double?>("HeHeadingDegT");

                    b.Property<int>("HeIdent");

                    b.Property<double?>("HeLatitudeDeg");

                    b.Property<double?>("HeLongitudeDeg");

                    b.Property<double?>("LeDisplacedThresholdFt");

                    b.Property<double?>("LeElevationFt");

                    b.Property<double?>("LeHeadingDegT");

                    b.Property<string>("LeIdent")
                        .IsRequired();

                    b.Property<double?>("LeLatitudeDeg");

                    b.Property<double?>("LeLongitudeDeg");

                    b.Property<double>("LengthFt");

                    b.Property<bool>("Lighted");

                    b.Property<string>("Surface")
                        .IsRequired();

                    b.Property<double>("WidthFt");

                    b.HasKey("RunwayId");

                    b.HasIndex("AirportId");

                    b.ToTable("Runways");
                });

            modelBuilder.Entity("plane_a_picnic.Models.TagModel", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Keyword")
                        .IsRequired();

                    b.HasKey("TagId");

                    b.ToTable("TagModel");
                });

            modelBuilder.Entity("plane_a_picnic.Models.AirportModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.RegionModel", "Region")
                        .WithMany("Airports")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("plane_a_picnic.Models.AirportTagModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.AirportModel", "Airport")
                        .WithMany("Tags")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plane_a_picnic.Models.TagModel", "Tag")
                        .WithMany("Airports")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("plane_a_picnic.Models.CountryTagModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.CountryModel", "Country")
                        .WithMany("Tags")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plane_a_picnic.Models.TagModel", "Tag")
                        .WithMany("Countries")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("plane_a_picnic.Models.RegionModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.CountryModel", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("plane_a_picnic.Models.RegionTagModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.RegionModel", "Region")
                        .WithMany("Tags")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plane_a_picnic.Models.TagModel", "Tag")
                        .WithMany("Regions")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("plane_a_picnic.Models.RunwayModel", b =>
                {
                    b.HasOne("plane_a_picnic.Models.AirportModel", "Airport")
                        .WithMany("Runways")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
