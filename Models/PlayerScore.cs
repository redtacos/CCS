using Newtonsoft.Json;

namespace ccs.Models
{
    public class PlayerScore
    {
        [JsonProperty(PropertyName = "scoreboard_page")]
        public int ScoreboardPage { get; set; }

        [JsonProperty(PropertyName = "scoreboard_position")]
        public int ScoreboardPosition { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "tid")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }
        
        [JsonProperty(PropertyName = "affiliation")]
        public string Affiliation { get; set; }
    }
}
