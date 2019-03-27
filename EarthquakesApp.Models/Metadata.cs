using Newtonsoft.Json;


namespace EarthquakesApp.Models
{
    public class Metadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}
