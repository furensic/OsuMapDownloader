using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuUserAchievement {
    [JsonProperty("achieved_at")]
    public string AchievedAt { get; set; }

    [JsonProperty("achievement_id")]
    public int AchievementId { get; set; }
}