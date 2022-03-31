using Newtonsoft.Json;

namespace ArcGIS_ServiceCallingWrapper.Model
{
    public abstract class Feature
    {
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
    }
}
