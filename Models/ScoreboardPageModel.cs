using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ccs.Models
{
    public class ScoreboardPageItem
    {
        public string name { get; set; }
        public string tid { get; set; }
        public int score { get; set; }
        public string affiliation { get; set; }
    }

    public class PlayerScore
    {
        public int scoreboardPage { get; set; }
        public int scoreboardPosition { get; set; }
        public string name { get; set; }
        public string tid { get; set; }
        public int score { get; set; }
        public string affiliation { get; set; }

        public PlayerScore(ScoreboardPageItem item, int scoreboardPage, int positionInPage)
        {
            this.scoreboardPage = scoreboardPage;
            this.scoreboardPosition = (scoreboardPage - 1) * 50 + positionInPage + 1;
            this.name = item.name;
            this.tid = item.tid;
            this.score = item.score;
            this.affiliation = item.affiliation;
        }
    }
}
