using System;
using System.IO;
using ccs.Models;
using Newtonsoft.Json;

namespace ccs.Controllers
{
    public class ScoreService
    {
        public Scoreboard getScoreboard()
        {
            var scoreboardsPath = Environment.GetEnvironmentVariable("APPSETTING_SCOREBOARD_PATH");
            var filePath = Path.Combine(scoreboardsPath, "picoctf", "scoreboard.json");

            using (var r = new StreamReader(filePath))
            {
                var json = r.ReadToEnd();
                var scoreboard = JsonConvert.DeserializeObject<Scoreboard>(json);
                return scoreboard;
            }
        }
    }
}