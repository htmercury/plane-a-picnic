using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class CountryModel { 
        [Key]
        public int CountryId { get; set; }
        
        public string Code { get; set; }

        public string Name { get; set; }

        public string Continent { get; set; }

        public string WikipediaLink { get; set; }

        public List<string> Keywords { get; set; }
    }
}