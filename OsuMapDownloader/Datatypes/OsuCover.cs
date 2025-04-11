using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuCover {
    [JsonProperty("custom_url")]
    public string CustomUrl { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
    
    [JsonProperty("id")]
    public string Id { get; set; }
}