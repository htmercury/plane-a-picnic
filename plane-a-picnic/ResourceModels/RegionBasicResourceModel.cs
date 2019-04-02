using System.Collections.Generic;

namespace plane_a_picnic.ResourceModels
{
    public class RegionBasicResourceModel
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string IsoCountry { get; set; }
        public string WikipediaLink { get; set; }
        public string Keywords { get; set; }
    }
}