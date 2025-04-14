using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapUserScore {
    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("score")]
    public object Score { get; set; } // for now
    //public OsuScore Score { get;      set; }
}