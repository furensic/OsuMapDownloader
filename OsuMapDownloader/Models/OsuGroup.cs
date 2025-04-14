using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuGroup {
    [JsonProperty("colour")]
    public string Colour { get; set; }

    [JsonProperty("has_listing")]
    public bool HasListing { get; set; }

    [JsonProperty("has_playmodes")]
    public bool HasPlaymodes { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("identifier")]
    public string Identifier { get; set; }

    [JsonProperty("is_probationary\n")]
    public bool IsProbationary { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("playmodes")]
    public object Playmodes { get; set; } // idk what this is?
}