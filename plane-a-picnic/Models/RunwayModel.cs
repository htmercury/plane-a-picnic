using System;
using System.ComponentModel.DataAnnotations;

namespace plane_a_picnic.Models {
    public class RunwayModel {
        [Key]
        public int RunwayId { get; set; }

        public int AirportId { get; set; }
        public AirportModel Airport { get; set; }

        [Required]
        public double LengthFt { get; set; }

        [Required]
        public double WidthFt { get; set; }

        [Required]
        public string Surface { get; set; }

        [Required]
        public bool Lighted { get; set; }

        [Required]
        public bool Closed { get; set; }

        [Required]
        public string LeIdent { get; set; }

        public double? LeLatitudeDeg { get; set; }

        public double? LeLongitudeDeg { get; set; }

        public double? LeElevationFt { get; set; }

        public double? LeHeadingDegT { get; set; }

        public double? LeDisplacedThresholdFt { get; set; }

        public int HeIdent { get; set; }

        public double? HeLatitudeDeg { get; set; }

        public double? HeLongitudeDeg { get; set; }

        public double? HeElevationFt { get; set; }

        public double? HeHeadingDegT { get; set; }

        public double? HeDisplacedThresholdFt { get; set; }
    }
}