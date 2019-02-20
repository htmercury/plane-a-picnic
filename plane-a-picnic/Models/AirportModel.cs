using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class AirportModel
    {
        [Key]
        public int AirportId { get; set; }

        [Required]
        public string Ident { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double LatitudeDeg { get; set; }

        [Required]
        public double LongitudeDeg { get; set; }

        [Required]
        public double ElevationFt { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string IsoCountry { get; set; }

        public int CountryId { get; set; }

        public CountryModel Country { get; set; }

        [Required]
        public string IsoRegion { get; set; }

        public int RegionId { get; set; }

        public RegionModel Region { get; set; }

        [Required]
        public string Municipality { get; set; }

        [Required]
        public bool ScheduledService { get; set; }

        public string GpsCode { get; set; }

        public string IataCode { get; set; }

        public string LocalCode { get; set; }

        public string HomeLink { get; set; }

        public string WikipediaLink { get; set; }

        public List<string> Keywords { get; set; }
    }
}