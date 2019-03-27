using Newtonsoft.Json;


namespace EarthquakesApp.Models
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

}
