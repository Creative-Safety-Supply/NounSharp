using Newtonsoft.Json;
using System;

namespace NounSharp.Models
{
    public class Icon
    {
        [JsonProperty("attribution")]
        public string Attribution { get; protected set; }

        [JsonProperty("attribution_preview_url")]
        public Uri AttributionPreviewUrl { get; protected set; }

        [JsonProperty("date_uploaded")]
        public DateTime DateUploaded { get; protected set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; protected set; }

        [JsonProperty("id")]
        public int ID { get; protected set; }

        [JsonProperty("is_active")]
        [JsonConverter(typeof(Internal.IntToBoolConverter))]
        public bool IsActive { get; protected set; }

        [JsonProperty("license_description")]
        public string LicenseDescription { get; protected set; }

        [JsonProperty("permalink")]
        public string Permalink { get; protected set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; protected set; }

        [JsonProperty("preview_url_42")]
        public Uri PreviewUrl42 { get; protected set; }

        [JsonProperty("preview_url_84")]
        public Uri PreviewUrl84 { get; protected set; }

        // TODO: Handle empty objects
        [JsonProperty("sponsor")]
        public Person Sponsor { get; protected set; }

        [JsonProperty("sponsor_campaign_link")]
        public Uri SponsorCampaignLink { get; protected set; }

        [JsonProperty("sponsor_id")]
        public int? SponsorID { get; protected set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; protected set; }

        [JsonProperty("term")]
        public string Term { get; protected set; }

        [JsonProperty("term_id")]
        public int? TermID { get; protected set; }

        [JsonProperty("term_slug")]
        public string TermSlug { get; protected set; }

        // TODO: Handle empty objects
        [JsonProperty("uploader")]
        public Person Uploader { get; protected set; }

        [JsonProperty("uploader_id")]
        public int? UploaderID { get; protected set; }

        [JsonProperty("year")]
        public int Year { get; protected set; }
    }
}
