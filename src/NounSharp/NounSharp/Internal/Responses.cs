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

    public class IconsRecentUploadsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }
        [JsonProperty("recent_uploads")]
        public Models.Icon[] RecentUploads { get; set; }
    }

    public class IconsUserUploadsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }
        public Models.Icon[] Uploads { get; set; }
    }

    public class IconResponse
    {
        public Models.Icon Icon { get; set; }
    }
}
