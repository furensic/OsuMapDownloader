using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapsetExtended : OsuBeatmapset {
    [JsonProperty("availability")]
    public OsuBeatmapsetAvailability Availability { get; set; }

    [JsonProperty("bpm")]
    public int Bpm { get; set; } // this is returned as int from API. maybe needs some casting or smth?

    [JsonProperty("can_be_hyped")]
    public bool CanBeHyped { get; set; }

    [JsonProperty("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [JsonProperty("discussion_enabled")]
    public bool DiscussionEnabled { get; set; } // deprecated

    [JsonProperty("discussion_locked")]
    public bool DiscussionLocked { get; set; }

    [JsonProperty("hype")]
    public object Hype { get; set; }

    [JsonProperty("is_scoreable")]
    public bool isScoreable { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonProperty("legacy_thread_url")]
    public string? LegacyThreadUrl { get; set; }

    [JsonProperty("nominations_summary")]
    public object NominationsSummary { get; set; }

    [JsonProperty("current_nominations", NullValueHandling = NullValueHandling.Ignore)]
    public List<object> CurrentNominations { get; set; }

    [JsonProperty("ranked")]
    public int Ranked { get; set; } // need enum

    [JsonProperty("ranked_date")]
    public DateTime? RankedDate { get; set; }

    [JsonProperty("rating")]
    public float Rating { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("storyboard")]
    public bool Storyboard { get; set; }

    [JsonProperty("submitted_date")]
    public DateTime? SubmittedDate { get; set; }

    [JsonProperty("tags")]
    public string Tags { get; set; }

    [JsonProperty("has_favourited", NullValueHandling = NullValueHandling.Ignore)]
    public object? HasFavourited { get; set; }

    [JsonProperty("related_tags", NullValueHandling = NullValueHandling.Ignore)]
    public List<object> RelatedTags { get; set; }
}