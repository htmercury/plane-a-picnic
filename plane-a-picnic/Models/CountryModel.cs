using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string WikipediaLink { get; set; }

        public List<CountryTagModel> Tags { get; set; }

        public List<RegionModel> Regions { get; set; }

        public CountryModel()
        {
            Tags = new List<CountryTagModel>();
            Regions = new List<RegionModel>();
        }
    }
}