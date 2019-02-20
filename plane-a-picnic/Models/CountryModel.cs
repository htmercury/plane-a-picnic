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

        public List<string> Keywords { get; set; }
    }
}