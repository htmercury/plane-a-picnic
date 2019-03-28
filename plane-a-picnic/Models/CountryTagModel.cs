using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class CountryTagModel
    {
        public int CountryId { get; set; }
        public CountryModel Country { get; set; }

        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }

        
}