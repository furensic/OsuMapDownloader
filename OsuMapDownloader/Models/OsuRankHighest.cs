using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuRankHighest {
    [JsonProperty("rank")]
    public int Rank { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }
}