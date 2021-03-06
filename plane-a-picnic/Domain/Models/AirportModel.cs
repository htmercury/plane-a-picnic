using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plane_a_picnic.Domain.Models
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

        public double? ElevationFt { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string IsoCountry { get; set; }

        [Required]
        public string IsoRegion { get; set; }

        [Required]
        public int RegionId { get; set; }
        [Required]
        public RegionModel Region { get; set; }

        public string Municipality { get; set; }

        [Required]
        public bool ScheduledService { get; set; }

        public string GpsCode { get; set; }

        public string IataCode { get; set; }

        public string LocalCode { get; set; }

        public string HomeLink { get; set; }

        public string WikipediaLink { get; set; }

        public string Keywords { get; set; }

        public List<RunwayModel> Runways { get; set; }

        public AirportModel()
        {
            Keywords = "";
            Runways = new List<RunwayModel>();
        }
    }
}