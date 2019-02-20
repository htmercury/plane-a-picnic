using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int CountryId { get; set; }

        public CountryModel Country { get; set; }

        [Required]
        public string WikipediaLink { get; set; }

        public List<string> Keywords { get; set; }
    }
}