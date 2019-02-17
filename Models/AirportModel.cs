using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class AirportModel { 
        [Key]
        public int AirportId { get; set; }

        public string Ident { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public double LatitudeDeg { get; set; }

        public double LongitudeDeg { get; set; }

        public double ElevationFt { get; set; }

        public string Continent { get; set; }

        public string IsoCountry { get; set; }

        public int CountryId { get; set; }

        public CountryModel Country { get; set; }

        public string IsoRegion { get; set; }

        public int RegionId { get; set; }

        public RegionModel Region { get; set; }

        public string Municipality { get; set; }

        public bool ScheduledService { get; set; }

        public string GpsCode { get; set; }

        public string IataCode { get; set; }

        public string LocalCode { get; set; }

        public string HomeLink { get; set; }

        public string WikipediaLink { get; set; }

        public List<string> Keywords { get; set; }
    }
}