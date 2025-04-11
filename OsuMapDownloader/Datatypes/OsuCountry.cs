using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuCountry {
    [JsonProperty("code")]
    public string code { get; set; }

    [JsonProperty("name")]
    public string name { get; set; }
}