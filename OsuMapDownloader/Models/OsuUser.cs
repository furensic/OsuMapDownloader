using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

// maybe i need to split this class into 2 sub classes as to documentation. theres User, User optional attributes and UserExtended
public class OsuUser {
    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; } // maybe change to Uri type

    [JsonProperty("country_code")]
    public string? CountryCode { get; set; } // could use an enum later, because Country has a code property already

    [JsonProperty("default_group")]
    public string? DefaultGroup { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("is_active")]
    public bool IsActive { get; set; }

    [JsonProperty("is_bot")]
    public bool IsBot { get; set; }

    [JsonProperty("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonProperty("is_online")]
    public bool IsOnline { get; set; }

    [JsonProperty("is_supporter")]
    public bool IsSupporter { get; set; }

    [JsonProperty("last_visit")]
    public string? LastVisit { get; set; } // convert to/from ISO 8061 format, rfc3339

    [JsonProperty("pm_friends_only")]
    public bool PmFriendsOnly { get; set; }

    [JsonProperty("profile_colour")]
    public string? ProfileColour { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }
}