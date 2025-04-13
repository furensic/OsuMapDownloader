using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuTournamentBanner {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("tournament_id")]
    public string TournamentId { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("image@2x")]
    public string Image2x { get; set; }
}