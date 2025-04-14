using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuTeam {
    [JsonProperty("flag_url")]
    public string FlagUrl { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }
}