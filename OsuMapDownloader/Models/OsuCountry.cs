using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuCountry {
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}