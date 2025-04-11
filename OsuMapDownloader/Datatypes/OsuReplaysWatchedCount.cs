using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuReplaysWatchedCount {
    [JsonProperty("start_date")]
    public string StartDate { get; set; }
    
    [JsonProperty("count")]
    public int Count { get; set; }
}