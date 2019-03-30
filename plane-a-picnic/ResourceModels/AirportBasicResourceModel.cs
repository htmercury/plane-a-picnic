using System.Collections.Generic;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.ResourceModels
{
    public class AirportBasicResourceModel
    {
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string IsoCountry { get; set; }
        public string IsoRegion { get; set; }
        public bool ScheduledService { get; set; }
        public string WikipediaLink { get; set; }
        public string Keywords { get; set; }
    }
}