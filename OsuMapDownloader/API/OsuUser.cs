using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuMapDownloader.API {
    internal class OsuUser {
        public string avatar_url { get; set; } = string.Empty;
        public string country_code { get; set; } = string.Empty;
        public string? default_group { get; set; }
        public int id { get; set; }
        public bool is_active { get; set; }
        public bool is_bot { get; set; }
        public bool is_deleted { get; set; }
        public bool is_online { get; set; }
        public bool is_supporter { get; set; }
        public DateTime last_visit { get; set; } // convert to/from ISO 8061 format
        public bool pm_friends_only { get; set; }
        public string? profile_color { get; set; }
        public string username { get; set; } = string.Empty;

        // optional attributes
        public string cover_url { get; set; } = string.Empty;
        public string? discord { get; set; }
        public bool has_supported { get; set; }
        public string? interests { get; set; }
        public DateTime join_date { get; set; } // convert to/from ISO 8061 format
        public string? location { get; set; }
        public int max_blocks { get; set; }
        public int max_friends { get; set; }
        public string? occupation { get; set; }
        public string playmode { get; set; } = string.Empty; // change to enum Ruleset
        public string[] playstyle { get; set; } = Array.Empty<string>();
        public int post_count { get; set; }
        public int profile_hue { get; set; }
        public string[] profile_order { get; set; } = Array.Empty<string>(); // change to ProfilePage[] later
        public string? title { get; set; }
        public string? title_url { get; set; }
        public string? twitter { get; set; }
        public string? website { get; set; }


    }
}
