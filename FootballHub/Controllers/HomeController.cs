using FootballHub.Data;
using FootballHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var playerList = _db.Players;
            return View(playerList);
        }
        [HttpPost]
        public IActionResult SearchPlayer(string searchPlayer)
        {
            IQueryable<Player> playerList;
            if (string.IsNullOrEmpty(searchPlayer))
            {
                playerList = _db.Players;

            }
            else
            {
                playerList = _db.Players.Where(p => p.Name.ToLower().Contains(searchPlayer.ToLower().Trim()));

            }
            
            return View("Index",playerList);
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {
            var statVM = new StatsVM()
            {
                Player = _db.Players.Single(p => p.Id == id),
                Stats = _db.Stats.Where(s => s.PlayerId == id).ToList()
            };
            return View(statVM);
        }
        [HttpGet]
        public IActionResult News(int pageNumber = 1)
        {
            int pageSize = 3;
            
            var newsPagination = new NewsPagination()
            {
                NewsList = _db.News.OrderByDescending(n => n.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNumber,
                LastPage = Math.Ceiling(Convert.ToDecimal(_db.News.Count()) / pageSize)
            };
            
            return View(newsPagination);
        }
        [HttpGet]
        public IActionResult FullNews(int id)
        {
            News news = _db.News.SingleOrDefault(s => s.Id == id);
            if(news == null)
            {
                return NotFound();
            }
            return View(news);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public JsonResult GetPlayersName(string query)
        {
            
            List<Player> playerList = _db.Players.ToList();
            if (!string.IsNullOrEmpty(query))
            {
                playerList = playerList.Where(p => p.Name.ToLower().Contains(query.Trim().ToLower())).ToList();
            }
            return Json(playerList);
        }
        public IActionResult GetFixtures()
        {
            var fixtures = _db.Fixtures.Include(f => f.Opponent).Where(f => f.MatchTime > DateTime.Now).OrderBy(f => f.MatchTime).ToList();
            return View(fixtures);
        }
    }
}