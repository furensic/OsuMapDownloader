using Newtonsoft.Json;

namespace OsuMapDownloader.Definitions;

public class OsuBeatmapExtended {
    [JsonProperty("accuracy")]
    public float Accuracy { get; set; }
    
    [JsonProperty("ar")]
    public float Ar { get; set; }
    
    [JsonProperty("beatmapset_id")]
    public int BeatmapsetId { get; set; }
    
    [JsonProperty("bpm")]
    public float Bpm { get; set; }
    
    [JsonProperty("convert")]
    public bool Convert { get; set; }
    
    [JsonProperty("count_circles")]
    public int CountCircles { get; set; }
    
    [JsonProperty("count_sliders")]
    public int CountSliders { get; set; }
    
    [JsonProperty("count_spinners")]
    public int CountSpinners { get; set; }
    
    [JsonProperty("cs")]
    public float Cs { get; set; }
    
    [JsonProperty("deleted_at")]
    public string DeletedAt { get; set; } // maybe use Datetime
    
    [JsonProperty("drain")]
    public float Drain { get; set; }
    
    [JsonProperty("hit_length")]
    public int HitLength { get; set; }
    
    [JsonProperty("is_scorable")]
    public bool IsScorable { get; set; }
    
    [JsonProperty("last_updated")]
    public string LastUpdated { get; set; } // maybe use Datetime
    
    [JsonProperty("mode_int")]
    public int ModeInt { get; set; }
    
    [JsonProperty("passcount")]
    public int Passcount { get; set; }
    
    [JsonProperty("playcount")]
    public int Playcount { get; set; }
    
    [JsonProperty("ranked")]
    public int Ranked { get; set; } // need enum for this or smth
    
    [JsonProperty("url")]
    public string Url { get; set; }
}