using Newtonsoft.Json;

namespace NounSharp.Models
{
    public class Tag
    {
        [JsonProperty("id")]
        public int ID { get; protected set; }

        [JsonProperty("slug")]
        public string Slug { get; protected set; }
    }
}
