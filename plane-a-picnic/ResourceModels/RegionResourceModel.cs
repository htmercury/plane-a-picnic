using System.Collections.Generic;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.ResourceModels
{
    public class RegionResourceModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string IsoCountry { get; set; }
        public int CountryId { get; set; }
        public CountryBasicResourceModel Country { get; set; }
        public string WikipediaLink { get; set; }
        public string Keywords { get; set; }
        public List<AirportBasicResourceModel> Airports { get; set; }
    }
}