using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plane_a_picnic.Models
{
    public class RunwayModel
    {
        [Key]
        public int RunwayId { get; set; }

        [Required]
        [ForeignKey("AirportId")]
        public AirportModel Airport { get; set; }

        public double? LengthFt { get; set; }

        public double? WidthFt { get; set; }

        public string Surface { get; set; }

        [Required]
        public bool Lighted { get; set; }

        [Required]
        public bool Closed { get; set; }

        public string LeIdent { get; set; }

        public double? LeLatitudeDeg { get; set; }

        public double? LeLongitudeDeg { get; set; }

        public double? LeElevationFt { get; set; }

        public double? LeHeadingDegT { get; set; }

        public double? LeDisplacedThresholdFt { get; set; }

        public string HeIdent { get; set; }

        public double? HeLatitudeDeg { get; set; }

        public double? HeLongitudeDeg { get; set; }

        public double? HeElevationFt { get; set; }

        public double? HeHeadingDegT { get; set; }

        public double? HeDisplacedThresholdFt { get; set; }
    }
}