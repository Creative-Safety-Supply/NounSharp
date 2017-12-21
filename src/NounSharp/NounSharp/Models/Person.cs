using Newtonsoft.Json;

namespace NounSharp.Models
{
    public class Person
    {
        [JsonProperty("location")]
        public string Location { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("permalink")]
        public string Permalink { get; protected set; }

        [JsonProperty("username")]
        public string Username { get; protected set; }
    }
}
