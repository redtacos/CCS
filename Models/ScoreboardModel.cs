using System;
using System.Collections.Generic;

namespace ccs.Models
{
    public class Scoreboard
    {
        public string name { get; set; }
        public string tid { get; set; }
        public int score { get; set; }
        public string affiliation { get; set; }
    }

    public class GlobalScoreboard
    {
        public string name { get; set; }
        public int pages { get; set; }
        public int start_page { get; set; }
        public List<Scoreboard> scoreboard { get; set; }
    }

    public class StudentScoreboard
    {
        public string name { get; set; }
        public int pages { get; set; }
        public List<Scoreboard> scoreboard { get; set; }
        public int start_page { get; set; }
    }

    public class ScoreboardModel
    {
        public string tid { get; set; }
        public List<object> groups { get; set; }
        public GlobalScoreboard global { get; set; }
        public string country { get; set; }
        public StudentScoreboard student { get; set; }
    }
}
