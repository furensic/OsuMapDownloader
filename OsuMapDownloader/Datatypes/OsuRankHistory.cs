using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuRankHistory {
    [JsonProperty("mode")]
    public string Mode { get; set; }

    [JsonProperty("data")]
    public List<int> Data { get; set; }
}