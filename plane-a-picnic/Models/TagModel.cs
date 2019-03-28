using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class TagModel
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public string Keyword { get; set; }

        public List<CountryTagModel> Countries { get; set; }

        public List<RegionTagModel> Regions { get; set; }

        public List<AirportTagModel> Airports { get; set; }

        public TagModel()
        {
            Countries = new List<CountryTagModel>();
            Regions = new List<RegionTagModel>();
            Airports = new List<AirportTagModel>();
        }
    }
}