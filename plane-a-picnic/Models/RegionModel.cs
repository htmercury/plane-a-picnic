using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plane_a_picnic.Models
{
    public class RegionModel
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string LocalCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string IsoCountry { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public CountryModel Country { get; set; }

        [Required]
        public string WikipediaLink { get; set; }

        public List<RegionTagModel> Tags { get; set; }

        public List<AirportModel> Airports { get; set; }

        public RegionModel()
        {
            Tags = new List<RegionTagModel>();
            Airports = new List<AirportModel>();            
        }
    }
}