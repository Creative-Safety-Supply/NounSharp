using Newtonsoft.Json;
using System;

namespace NounSharp.Internal
{
    public class CollectionsResponse
    {
        public Models.Collection[] Collections { get; set; }
    }

    public class CollectionResponse
    {
        public Models.Collection Collection { get; set; }
    }

    public class IconsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }
        public Models.Icon[] Icons { get; set; }
    }
}
