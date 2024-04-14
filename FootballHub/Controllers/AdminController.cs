﻿using FootballHub.Data;
using FootballHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballHub.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _host;
        public AdminController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;

        }
        public IActionResult AddPlayer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayer(Player player, IFormFile? PlayerImage)
        {
            if(ModelState.IsValid)
            {
                if(PlayerImage != null && PlayerImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString()+"_"+PlayerImage.FileName;
                    var filePath = Path.Combine(_host.WebRootPath,"Image", fileName);
                    using(var fileStream = new FileStream(filePath,FileMode.Create))
                    {
                        PlayerImage.CopyTo(fileStream);
                    }
                    player.Image = fileName;
                }
                _db.Players.Add(player);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(player);
        }
        [HttpGet]
        public IActionResult UpdatePlayer()
        {
            var playerList = _db.Players;
            return View(playerList);
        }
        [HttpGet]
        public IActionResult UpdatePlayerData(int id)
        {
            var player = _db.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return NotFound();
            return View(player);

        }
        [HttpPost]
        public IActionResult UpdatePlayerData(Player player, IFormFile? PlayerImage)
        {
            if(ModelState.IsValid)
            {
                string newImagePath = string.Empty;
                if (player.Image != null)
                    newImagePath = player.Image;

                if (PlayerImage != null && PlayerImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + PlayerImage.FileName;
                    var filePath = Path.Combine(_host.WebRootPath, "Image", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        PlayerImage.CopyTo(fileStream);
                    }
                    newImagePath = fileName;
                    

                }
                player.Image = newImagePath;
                _db.Players.Update(player);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(player);
        }
        [HttpGet]
        public IActionResult UpdatePlayerStats(int playerId)
        {
            
            var player = _db.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
                return NotFound();
            var statsVM = new StatsVM()
            {
                Player = player,
                Stats = _db.Stats.Include(s => s.Player).Where(s => s.PlayerId == playerId).ToList()
            };
            return View(statsVM);
        }
        [HttpPost]
        public IActionResult UpdatePlayerStats(StatsVM statsVM)
        {
            
            if(ModelState.IsValid)
            {
                int playerId = statsVM.Player.Id;
                foreach (var stat in statsVM.Stats)
                {
                    stat.PlayerId = playerId;
                    if (stat.Id == 0)
                        _db.Stats.Add(stat);
                   
                }
                _db.SaveChanges();
            }
            var newStatsVM = new StatsVM()
            {
                Player = statsVM.Player,
                Stats = _db.Stats.Include(s => s.Player).Where(s => s.PlayerId == statsVM.Player.Id).ToList()
            };
            return View(newStatsVM);
        }
        [HttpPost]
        public IActionResult Back()
        {
            return RedirectToAction(nameof(UpdatePlayer));
        }
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNews(News news,IFormFile newsImage)
        {
            string rootDirectory = _host.WebRootPath;
            if(ModelState.IsValid)
            {
                if(newsImage != null)
                {
                    string fileName = Guid.NewGuid().ToString()+"_"+newsImage.FileName;
                    string filePath = Path.Combine(rootDirectory, "NewsImage", fileName);
                    using(var stream = new FileStream(filePath,FileMode.Create))
                    {
                        newsImage.CopyTo(stream);
                    }
                    news.ImageUrl = fileName;
                }
                _db.News.Add(news);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}
