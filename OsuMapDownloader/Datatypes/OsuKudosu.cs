using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuKudosu {
    [JsonProperty("available")]
    public int Available { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }
}