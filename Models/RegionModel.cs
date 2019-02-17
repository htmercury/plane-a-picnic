using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class RegionModel { 
        [Key]
        public int RegionId { get; set; }

        public String Code { get; set; }

        public string LocalCode { get; set; }

        public string Name { get; set; }

        public string Continent { get; set; }

        public string IsoCountry { get; set; }

        public string WikipediaLink { get; set; }

        public List<string> Keywords { get; set; }
    }
}