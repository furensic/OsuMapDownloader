using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapDifficultyAttributes {
    [JsonProperty("star_rating")]
    public float StarRating { get; set; }

    [JsonProperty("max_combo")]
    public int MaxCombo { get; set; }

    // taiko extra
    // mono_stamina_factor
    [JsonProperty("mono_stamina_factor")]
    public float MonoStaminaFactor { get; set; }

    // std extra
    // "aim_difficulty": 4.466509819030762,
    [JsonProperty("aim_difficulty")]
    public float PropertyName { get; set; }

    // "aim_difficult_slider_count": 96.04679870605469,
    [JsonProperty("aim_difficulty_slider_count")]
    public float AimDifficultySliderCount { get; set; }

    // "speed_difficulty": 3.0189599990844727,
    [JsonProperty("speed_difficulty")]
    public float SpeedDifficulty { get; set; }

    // "speed_note_count": 850.6069946289062,
    [JsonProperty("speed_note_count")]
    public float SpeedNoteCount { get; set; }

    // "slider_factor": 0.9989089965820312,
    [JsonProperty("slider_factory")]
    public float SliderFactory { get; set; }

    // "aim_difficult_strain_count": 230.875,
    [JsonProperty("aim_difficulty_strain_count")]
    public float AimDifficultyStrainCount { get; set; }

    // "speed_difficult_strain_count": 268.9779968261719
    [JsonProperty("speed_difficulty_strain_count")]
    public float SpeedDifficultyStrainCount { get; set; }

    // mania extra
    // none
}