using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ccs.Models;
using Newtonsoft.Json;

namespace ccs.Controllers
{
    public class ScoreService
    {
        private static TimeSpan cacheLifetime = TimeSpan.FromMinutes(20);
        static private DateTime lastFetchTime;
        static private List<PlayerScore> cachedScores = new List<PlayerScore>();
        static private List<string> wantedUsernames = new List<string> {"Ruben", "marcan2020", "cookie", "Calex", "Nodral"};

        public async Task<List<PlayerScore>> getScores()
        {
            if(lastFetchTime < DateTime.Now.Subtract(cacheLifetime))
            {
                cachedScores = await fetchScores();
                lastFetchTime = DateTime.Now;
            }
            return cachedScores;
        }

        public async Task<List<PlayerScore>> fetchScores()
        {
            var client = new HttpClient();
            var scores = new List<PlayerScore>();

            var scoreboard = await ApiGet<ScoreboardModel>(client, "https://2018game.picoctf.com/api/stats/scoreboard");
            for(int page = 1; page <= scoreboard.global.pages; ++page)
            {
                var playerScores = await ApiGet<IEnumerable<ScoreboardPageItem>>(client, "https://2018game.picoctf.com/api/stats/scoreboard/global/" + page);
                var playerScoresFound = playerScores.Select((x, i) => new PlayerScore(x, page, i) )
                                                    .Where(x => wantedUsernames.Contains(x.name));
                scores.AddRange(playerScoresFound.ToList());
                if(scores.Count == wantedUsernames.Count())
                    break;                    
            }

            return scores;
        }

        private async Task<T> ApiGet<T>(HttpClient client, string url) where T: class
        {
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var message = JsonConvert.DeserializeObject<ApiMessage<T>>(body);
            return message.data;
        }
    }
}