using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapScores {
    [JsonProperty("scores")]
    public List<object> Scores { get; set; } // for now
    //public List<OsuScore> Scores { get; set; }

    [JsonProperty("userScore")]
    public OsuBeatmapUserScore? UserScore { get; set; }
}