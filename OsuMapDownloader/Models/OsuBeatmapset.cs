using Newtonsoft.Json;
using OsuMapDownloader.Definitions;

namespace OsuMapDownloader.Datatypes;
//[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]

public class OsuBeatmapset {
    [JsonProperty("artist")]
    public string Artist { get; set; }

    [JsonProperty("artist_unicode")]
    public string ArtistsUnicode { get; set; }

    [JsonProperty("covers")]
    public OsuBeatmapCovers Covers { get; set; } // needs enum or smth

    [JsonProperty("creator")]
    public string Creator { get; set; }

    [JsonProperty("favourite_count")]
    public int FavouriteCount { get; set; }

    [JsonProperty("hype")]
    public object Hype { get; set; } // check this later

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("nsfw")]
    public bool Nsfw { get; set; }

    [JsonProperty("offset")]
    public int Offset { get; set; }

    [JsonProperty("play_count")]
    public int PlayCount { get; set; }

    [JsonProperty("preview_url")]
    public string PreviewUrl { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; } // enum Status int to string

    [JsonProperty("spotlight")]
    public bool Spotlight { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("title_unicode")]
    public string TitleUnicode { get; set; }

    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("video")]
    public bool Video { get; set; }

    // optional Beatmap properties. Most unknown type.
    // so i thought id put a ? behind every variable because in the docu they're only "optional", so maybe prevents null variables
    [JsonProperty("beatmaps", NullValueHandling=NullValueHandling.Ignore)]
    public object? Beatmaps { get; set; }

    [JsonProperty("converts", NullValueHandling=NullValueHandling.Ignore)]
    public object? Converts { get; set; }

    [JsonProperty("current_nominations", NullValueHandling=NullValueHandling.Ignore)]
    public List<object>? CurrentNominations { get; set; }
    
    [JsonProperty("current_user_attributes", NullValueHandling=NullValueHandling.Ignore)]
    public object? CurrentUserAttribute { get; set; }

    [JsonProperty("description", NullValueHandling=NullValueHandling.Ignore)]
    public object? Description { get; set; }

    [JsonProperty("discussions", NullValueHandling=NullValueHandling.Ignore)]
    public object? Discussions { get; set; }

    [JsonProperty("events", NullValueHandling=NullValueHandling.Ignore)]
    public object? Events { get; set; }

    [JsonProperty("genre", NullValueHandling=NullValueHandling.Ignore)]
    public object? Genre { get; set; }

    [JsonProperty("has_favourited", NullValueHandling=NullValueHandling.Ignore)]
    public bool? HasFavourited { get; set; }

    [JsonProperty("language", NullValueHandling=NullValueHandling.Ignore)]
    public object? Language { get; set; }

    [JsonProperty("nominations", NullValueHandling=NullValueHandling.Ignore)]
    public object? Nominations { get; set; }

    [JsonProperty("pack_tags", NullValueHandling=NullValueHandling.Ignore)]
    public List<string>? PackTags { get; set; }

    [JsonProperty("ratings", NullValueHandling=NullValueHandling.Ignore)]
    public object? Ratings { get; set; }

    [JsonProperty("recent_favourites", NullValueHandling=NullValueHandling.Ignore)]
    public object? RecentFavourites { get; set; }

    [JsonProperty("related_users", NullValueHandling=NullValueHandling.Ignore)]
    public object? RelatedUsers { get; set; }

    [JsonProperty("user", NullValueHandling=NullValueHandling.Ignore)]
    public OsuUser? User { get; set; } // not sure if this is actually needed

    [JsonProperty("track_id")]
    public int? TrackId { get; set; }
}

public enum OsuBeatmapRankStatus {
    Graveyard = -2,
    Wip       = -1,
    Pending   = 0,
    Ranked    = 1,
    Approved  = 2,
    Qualified = 3,
    Loved     = 4
}