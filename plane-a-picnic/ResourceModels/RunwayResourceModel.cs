using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.ResourceModels
{
    public class RunwayResourceModel
    {
        public int RunwayId { get; set; }
        public int AirportId { get; set; }
        public string AirportIdent { get; set; }
        public double? LengthFt { get; set; }
        public double? WidthFt { get; set; }
        public string Surface { get; set; }
        public bool Lighted { get; set; }
        public bool Closed { get; set; }
        public double? LeLatitudeDeg { get; set; }
        public double? LeLongitudeDeg { get; set; }
        public double? LeElevationFt { get; set; }
        public double? LeHeadingDegT { get; set; }
        public double? HeLatitudeDeg { get; set; }
        public double? HeLongitudeDeg { get; set; }
        public double? HeElevationFt { get; set; }
        public double? HeHeadingDegT { get; set; }
    }
}