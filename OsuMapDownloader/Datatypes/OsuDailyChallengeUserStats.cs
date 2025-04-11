using Newtonsoft.Json;

namespace OsuMapDownloader.Datatypes;

public class OsuDailyChallengeUserStats {
    [JsonProperty("daily_streak_best")]
    public int DailyStreakBest { get; set; }
    
    [JsonProperty("daily_streak_current")]
    public int DailyStreakCurrent { get; set; }
    
    [JsonProperty("last_update")]
    public string LastUpdate { get; set; }
    
    [JsonProperty("last_weekly_streak")]
    public string LastWeeklyStreak { get; set; }
    
    [JsonProperty("playcount")]
    public int PlayCount { get; set; }
    
    [JsonProperty("top_10p_placements")]
    public int Top10PPlacements { get; set; }
    
    [JsonProperty("top_50p_placements")]
    public int Top50PPlacements { get; set; }
    
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    
    [JsonProperty("weekly_streak_best")]
    public int WeeklyStreakBest { get; set; }
    
    [JsonProperty("weekly_streak_current")]
    public int WeeklyStreakCurrent { get; set; }
}