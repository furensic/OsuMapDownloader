using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapPlaycount {
    [JsonProperty("beatmap_id")]
    public int BeatmapId { get; set; }

    [JsonProperty("beatmap")]
    public OsuBeatmap? Beatmap { get; set; }

    [JsonProperty("beatmapset")]
    public OsuBeatmapset? Beatmapset { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
}