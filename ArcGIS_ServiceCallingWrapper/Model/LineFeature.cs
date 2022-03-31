using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArcGIS_ServiceCallingWrapper.Model
{
    public class LineFeature : Feature
    {
        public LineGeometry Geometry { get; set; }
    }

    public class LineGeometry
    {
        [JsonProperty("paths")]
        public List<List<List<double>>> Paths { get; set; }
    }

}
