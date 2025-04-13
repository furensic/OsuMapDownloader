using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapsetAvailability {
    [JsonProperty("download_disabled")]
    public bool DownloadDisabled { get; set; }

    [JsonProperty("more_information")]
    public string MoreInformation { get; set; }
}