using FootballHub.Data;
using FootballHub.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddPlayer(Player player, IFormFile PlayerImage)
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
    }
}
