using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuUserExtended : OsuUser {
    // optional attributes
    [JsonProperty("cover_url")]
    public string? CoverUrl { get; set; } // maybe change to Uri type

    [JsonProperty("discord")]
    public string? Discord { get; set; } // maybe change to Uri type

    [JsonProperty("has_supported")]
    public bool HasSupported { get; set; }

    [JsonProperty("interests")]
    public string? Interests { get; set; }

    [JsonProperty("join_date")]
    public string? JoinDate { get; set; } // convert to/from ISO 8061 format, rfc3339

    [JsonProperty("location")]
    public string? Location { get; set; }

    [JsonProperty("max_blocks")]
    public int MaxBlocks { get; set; }

    [JsonProperty("max_friends")]
    public int MaxFriends { get; set; }

    [JsonProperty("occupation")]
    public string? Occupation { get; set; }

    [JsonProperty("playmode")]
    public string? Playmode { get; set; } // change to enum Ruleset

    // playstyle example:
    /*  [
     *  "mouse",
     *  "keyboard",
     *  "tablet"
     *  ]
     */
    [JsonProperty("playstyle")]
    public List<string>? Playstyle { get; set; }

    [JsonProperty("post_count")]
    public int PostCount { get; set; }

    [JsonProperty("profile_hue")]
    public int ProfileHue { get; set; }

    // profile_order example:
    /*[
      "me",
      "recent_activity",
      "historical",
      "top_ranks",
      "medals",
      "beatmaps",
      "kudosu"
      ]
    */
    [JsonProperty("profile_order")]
    public List<string>? ProfileOrder { get; set; } // change to ProfilePage[] later

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("title_url")]
    public string? TitleUrl { get; set; } // maybe change to Uri type

    [JsonProperty("twitter")]
    public string? Twitter { get; set; } // maybe change to Uri type

    [JsonProperty("website")]
    public string? Website { get; set; } // maybe change to Uri type

    [JsonProperty("country")]
    public OsuCountry? Country { get; set; }

    [JsonProperty("cover")]
    public OsuCover? Cover { get; set; }

    [JsonProperty("kudosu")]
    public OsuKudosu? Kudosu { get; set; }

    [JsonProperty("account_history")]
    public List<object>? AccountHistory { get; set; } // list of unknown type, maybe bans or smth?

    [JsonProperty("active_tournament_banner")]
    public OsuTournamentBanner? ActiveTournamentBanner { get; set; } // object type is unknown

    [JsonProperty("active_tournament_banners")]
    public List<OsuTournamentBanner>? ActiveTournamentBanners { get; set; } // list of unknown type

    [JsonProperty("badges")]
    public List<OsuBadge>? Badges { get; set; } // list of unknown type

    [JsonProperty("beatmap_playcounts_count")]
    public int BeatmapPlaycountsCount { get; set; } // not sure what this is

    [JsonProperty("comments_count")]
    public int CommentsCount { get; set; }

    [JsonProperty("current_season_stats")]
    public object? CurrentSeasonStats { get; set; } // not sure what this is

    [JsonProperty("daily_challenge_user_stats")]
    public OsuDailyChallengeUserStats? DailyChallengeUserStats { get; set; }

    [JsonProperty("favourite_beatmapset_count")]
    public int FavouriteBeatmapsetCount { get; set; }

    [JsonProperty("follower_count")]
    public int FollowerCount { get; set; }

    [JsonProperty("graveyard_beatmapset_count")]
    public int GraveyardBeatmapsetCount { get; set; }

    [JsonProperty("groups")]
    public List<OsuGroup>? Groups { get; set; }

    [JsonProperty("guest_beatmapset_count")]
    public int GuestBeatmapsetCount { get; set; }

    [JsonProperty("loved_beatmapset_count")]
    public int LovedBeatmapsetCount { get; set; }

    [JsonProperty("mapping_follower_count")]
    public int MappingFollowerCount { get; set; }

    [JsonProperty("monthly_playcounts")]
    public List<OsuMonthlyPlaycount>? MonthlyPlaycounts { get; set; }

    [JsonProperty("nominated_beatmapset_count")]
    public int NominatedBeatmapsetCount { get; set; }

    [JsonProperty("page")]
    public OsuPage? Page { get; set; }

    [JsonProperty("pending_beatmapset_count")]
    public int PendingBeatmapsetCount { get; set; }

    [JsonProperty("previous_usernames")]
    public List<string>? PreviousUsernames { get; set; }

    [JsonProperty("rank_highest")]
    public OsuRankHighest? RankHighest { get; set; }

    [JsonProperty("ranked_beatmapset_count")]
    public int RankedBeatmapsetCount { get; set; }

    [JsonProperty("replays_watched_counts")]
    public List<OsuReplaysWatchedCount>? ReplaysWatchedCounts { get; set; }

    [JsonProperty("scores_best_count")]
    public int ScoresBestCount { get; set; }

    [JsonProperty("scores_first_count")]
    public int ScoresFirstCount { get; set; }

    [JsonProperty("scores_pinned_count")]
    public int ScoresPinnedCount { get; set; }

    [JsonProperty("scores_recent_count")]
    public int ScoresRecentCount { get; set; }

    [JsonProperty("statistics")]
    public OsuUserStatistics? Statistics { get; set; }

    [JsonProperty("support_level")]
    public int SupportLevel { get; set; }

    [JsonProperty("team")]
    public OsuTeam? Team { get; set; }

    [JsonProperty("user_achievements")]
    public List<OsuUserAchievement>?
            UserAchievements { get; set; } // todo implement a lookup table for achievment_ids to name and description

    [JsonProperty("rank_history")]
    public OsuRankHistory? RankHistory { get; set; }

    [JsonProperty("rankHistory")]
    public OsuRankHistory? RankHistory_ { get; set; } // somehow this is identical to rank_history

    [JsonProperty("ranked_and_approved_beatmapset_count")]
    public int RankedAndApprovedBeatmapsetCount { get; set; }

    [JsonProperty("unranked_beatmapset_count")]
    public int UnrankedBeatmapsetCount { get; set; }
}