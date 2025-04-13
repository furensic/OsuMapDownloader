﻿using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuBeatmapsetExtended : OsuBeatmapset {
    [JsonProperty("availability.download_disabled")]
    public bool AvailabilityDownloadDisabled { get; set; }

    [JsonProperty("availability.more_information")]
    public string? AvailabilityMoreInformation { get; set; }

    [JsonProperty("bpm")]
    public float Bpm { get; set; }

    [JsonProperty("can_be_hyped")]
    public bool CanBeHyped { get; set; }

    [JsonProperty("deleted_at")]
    public DateTime DeletedAt { get; set; }

    [JsonProperty("discussion_enabled")]
    public bool DiscussionEnabled { get; set; } // deprecated

    [JsonProperty("discussion_locked")]
    public bool DiscussionLocked { get; set; }

    [JsonProperty("hype.current")]
    public int HypeCurrent { get; set; }

    [JsonProperty("hype.required")]
    public int HypeRequired { get; set; }

    [JsonProperty("is_scorable")]
    public bool isScorable { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonProperty("legacy_thread_url")]
    public string? LegacyThreadUrl { get; set; }

    [JsonProperty("nominations_summary.current")]
    public int NominationsSummaryCurrent { get; set; }

    [JsonProperty("nominations_summary.required")]
    public int NominationsSummaryRequired { get; set; }

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

    [JsonProperty("has_favourited")]
    public object HasFavourited { get; set; }
}