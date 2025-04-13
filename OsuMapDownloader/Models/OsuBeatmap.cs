using Newtonsoft.Json;
using OsuMapDownloader.Datatypes;

namespace OsuMapDownloader.Definitions;

public class OsuBeatmap {
    [JsonProperty("beatmapset_id")]
    public int BeatmapsetId { get; set; }

    [JsonProperty("difficulty_rating")]
    public float DifficultyRating { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("mode")]
    public string Mode { get; set; } // i wanna change this later, so it uses OsuRuleset type with the description

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("total_length")]
    public int TotalLength { get; set; }

    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("beatmapset")]
    public OsuBeatmapset
            Beatmapset {
        get;
        set;
    } // this Beatmapset seems different than the one returned from its own endpoint. probably needs an interface so
    // that i can create a Beatmapset class for both the Beatmapset endpoint and one for the info that is returned here

    [JsonProperty("checksum")]
    public string? Checksum { get; set; }

    [JsonProperty("current_user_playcount")]
    public int CurrentUserPlayCount { get; set; }

    [JsonProperty("failtimes")]
    public OsuFailtime Failtimes { get; set; } // missing

    [JsonProperty("max_combo")]
    public int MaxCombo { get; set; }

    [JsonProperty("owners")]
    public List<OsuUser>
            Users {
        get;
        set;
    } // this should use its own type, only needs id and username. OsuUser has too many properties
}