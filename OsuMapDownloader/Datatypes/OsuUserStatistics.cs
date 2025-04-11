using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuUserStatistics {
    [JsonProperty("count_100")]
    public int Count100 { get; set; }
    
    [JsonProperty("count_300")]
    public int Count300 { get; set; }
    
    [JsonProperty("count_50")]
    public int Count50 { get; set; }
    
    [JsonProperty("count_miss")]
    public int CountMiss { get; set; }
    
    [JsonProperty("level")]
    public object Level { get; set; }
    
    [JsonProperty("global_rank")]
    public int GlobalRank { get; set; }
    
    [JsonProperty("global_rank_exp")]
    public int GlobalRankExp { get; set; }
    
    [JsonProperty("pp")]
    public float Pp { get; set; }
    
    [JsonProperty("pp_exp")]
    public float PpExp { get; set; }
    
    [JsonProperty("ranked_score")]
    public int RankedScore { get; set; }
    
    [JsonProperty("hit_accuracy")]
    public float HitAccuracy { get; set; }
    
    [JsonProperty("play_count")]
    public int PlayCount { get; set; }
    
    [JsonProperty("play_time")]
    public int PlayTime { get; set; }
    
    [JsonProperty("total_score")]
    public int TotalScore { get; set; }
    
    [JsonProperty("total_hits")]
    public int TotalHits { get; set; }
    
    [JsonProperty("maximum_combo")]
    public int MaximumCombo { get; set; }
    
    [JsonProperty("replays_watched_by_others")]
    public int ReplaysWatchedByOthers { get; set; }
    
    [JsonProperty("is_ranked")]
    public bool IsRanked { get; set; }
    
    [JsonProperty("grade_counts")]
    public object GradeCounts { get; set; }
    
    [JsonProperty("country_rank")]
    public int CountryRank { get; set; }
    
    [JsonProperty("rank")]
    public object Rank { get; set; }
}