using Newtonsoft.Json;
using System;

namespace NounSharp.Models
{
    public class Collection
    {
        // TODO: Handle empty objects
        [JsonProperty("author")]
        public Person Author { get; protected set; }

        [JsonProperty("author_id")]
        public int AuthorID { get; protected set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; protected set; }

        [JsonProperty("date_updated")]
        public DateTime DateUpdated { get; protected set; }

        [JsonProperty("description")]
        public string Description { get; protected set; }

        [JsonProperty("icon_count")]
        public int IconCount { get; protected set; }

        [JsonProperty("id")]
        public int ID { get; protected set; }

        [JsonProperty("is_collaborative")]
        [JsonConverter(typeof(Internal.IntToBoolConverter))]
        public bool? IsCollaborative { get; protected set; }

        [JsonProperty("is_featured")]
        [JsonConverter(typeof(Internal.IntToBoolConverter))]
        public bool IsFeatured { get; protected set; }

        [JsonProperty("is_published")]
        [JsonConverter(typeof(Internal.IntToBoolConverter))]
        public bool IsPublished { get; protected set; }

        [JsonProperty("is_store_item")]
        [JsonConverter(typeof(Internal.IntToBoolConverter))]
        public bool IsStoreItem { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("permalink")]
        public string Permalink { get; protected set; }

        [JsonProperty("slug")]
        public string Slug { get; protected set; }

        // TODO: Handle empty objects
        [JsonProperty("sponsor")]
        public Person Sponsor { get; protected set; }

        [JsonProperty("sponsor_campaign_link")]
        public Uri SponsorCampaignLink { get; protected set; }

        [JsonProperty("sponsor_id")]
        public int? SponsorID { get; protected set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; protected set; }

        [JsonProperty("template")]
        public string Template { get; protected set; }
    }
}
