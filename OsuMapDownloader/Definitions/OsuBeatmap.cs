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
    public OsuRuleset Mode { get; set; }
    
    [JsonProperty("status")]
    public string Status { get; set; }
    
    [JsonProperty("total_length")]
    public int TotalLength { get; set; }
    
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    
    [JsonProperty("version")]
    public string Version { get; set; }
    
    [JsonProperty("beatmapset")]
    public OsuBeatmapset Beatmapset { get; set; }
    
    [JsonProperty("checksum")]
    public string? Checksum { get; set; }
    
    [JsonProperty("current_user_playcount")]
    public int CurrentUserPlayCount { get; set; }
    
    [JsonProperty("failtimes")]
    public OsuFailtime Failtimes { get; set; }
    
    [JsonProperty("max_combo")]
    public int MaxCombo { get; set; }
    
    [JsonProperty("owners")]
    public List<OsuUser> Users { get; set; }
}