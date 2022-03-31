using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArcGIS_ServiceCallingWrapper.Model
{
    public class PolygonFeature : Feature
    {
        public PolygonGeometry Geometry { get; set; }
    }

    public class PolygonGeometry
    {
        [JsonProperty("rings")]
        public List<List<List<double>>> Rings { get; set; }
    }

}
