﻿using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuReplaysWatchedCount {
    [JsonProperty("start_date")]
    public string StartDate { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
}