using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class AirportTagModel
    {
        public int AirportId { get; set; }
        public AirportModel Airport { get; set; }

        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }

        
}