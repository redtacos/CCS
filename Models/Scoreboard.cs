using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ccs.Models
{
    public class Scoreboard
    {
        [JsonProperty(PropertyName = "last_fetch_time")]
        public DateTime LastFetchTime { get; set; }

        [JsonProperty(PropertyName = "player_scores")]
        public List<PlayerScore> PlayerScores { get; set; }
    }
}
