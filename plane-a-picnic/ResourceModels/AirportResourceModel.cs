namespace plane_a_picnic.ResourceModels
{
    public class AirportResourceModel
    {
        public int AirportId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double LatitudeDeg { get; set; }
        public double LongitudeDeg { get; set; }
        public double? ElevationFt { get; set; }
        public string Continent { get; set; }

        public string IsoCountry { get; set; }

        public string IsoRegion { get; set; }
        public bool ScheduledService { get; set; }

        public string GpsCode { get; set; }

        public string IataCode { get; set; }

        public string WikipediaLink { get; set; }

        public string Keywords { get; set; }
    }
}