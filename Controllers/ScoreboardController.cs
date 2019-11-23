using System;
using Microsoft.AspNetCore.Mvc;

namespace ccs.Controllers
{
    public class ScoreboardController : Controller
    {
        ScoreService scoreService = new ScoreService();

        public IActionResult Index()
        {
            try
            {
                var scoreboard = scoreService.getScoreboard();
                ViewData["Scoreboard"] = scoreboard;

                return View();
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }
    }
}
