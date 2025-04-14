using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapPack {
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("no_diff_reduction")]
    public bool NoDiffReduction { get; set; }

    [JsonProperty("ruleset_id")]
    public int RulesetId { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    // optional attributes
    [JsonProperty("beatmapsets")]
    public List<OsuBeatmapset> Beatmapsets { get; set; }

    [JsonProperty("user_completion_data.beatmapset_ids")]
    public List<int> UserCompletionDataBeatmapsetIds { get; set; }

    [JsonProperty("user_completion_data.completed")]
    public bool UserCompletionDataCompleted { get; set; }
}