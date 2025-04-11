using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

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
    public OsuBeatmapRankStatus Status { get; set; } // enum Status int to string

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

    // optional Beatmap properties. Most unknown type

    [JsonProperty("beatmaps")]
    public object Beatmaps { get; set; }

    [JsonProperty("converts")]
    public object Converts { get; set; }

    [JsonProperty("current_nominations")]
    public List<OsuBeatmapNomination> CurrentNominations { get; set; }

    [JsonProperty("current_user_attributes")]
    public object CurrentUserAttribute { get; set; }

    [JsonProperty("description")]
    public object Description { get; set; }

    [JsonProperty("discussions")]
    public object Discussions { get; set; }

    [JsonProperty("events")]
    public object Events { get; set; }

    [JsonProperty("genre")]
    public object Genre { get; set; }

    [JsonProperty("has_favourited")]
    public bool HasFavourited { get; set; }

    [JsonProperty("language")]
    public object Language { get; set; }

    [JsonProperty("nominations")]
    public object Nominations { get; set; }

    [JsonProperty("pack_tags")]
    public List<string> PackTags { get; set; }

    [JsonProperty("ratings")]
    public object Ratings { get; set; }

    [JsonProperty("recent_favourites")]
    public object RecentFavourites { get; set; }

    [JsonProperty("related_users")]
    public object RelatedUsers { get; set; }

    [JsonProperty("user")]
    public object User { get; set; }

    [JsonProperty("track_id")]
    public object TrackId { get; set; }
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