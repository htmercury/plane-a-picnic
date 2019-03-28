using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models
{
    public class RegionTagModel
    {
        public int RegionId { get; set; }
        public RegionModel Region { get; set; }

        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }

        
}