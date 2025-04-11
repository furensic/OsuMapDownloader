using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuBadge {
    [JsonProperty("awarded_at")]
    public string AwardedAt { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("image@2x_url")]
    public string Image2xUrl { get; set; }

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}