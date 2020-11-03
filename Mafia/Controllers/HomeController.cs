using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mafia.Models;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private MafiaDbContext context;
        //private IPlayerRepository playerRepo;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, MafiaDbContext context/*, IPlayerRepository playerRepo*/)
        {
            this.logger = logger;
            this.context = context;
            //this.playerRepo = playerRepo;
        }

        public IActionResult Index()
        {
            var players = context.Players.Include(x => x.PlayerRecords).ToList(); 
            return View(players);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Player(int playerId)
        {
            var player = context.Players.Include(x => x.PlayerRecords).AsNoTracking().FirstOrDefault(x => x.Id == playerId);
            if (player != null)
                return View(player);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
