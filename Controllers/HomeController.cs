using System.Diagnostics;
using System.Threading.Tasks;
using ccs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ccs.Controllers
{
    public class HomeController : Controller
    {
        ScoreService scoreService = new ScoreService();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Scoreboard()
        {
            var scores = await scoreService.getScores();
            ViewData["Scores"] = scores;

            return View();
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
