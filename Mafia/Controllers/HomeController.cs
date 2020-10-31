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

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private MafiaDbContext context;
        private IPlayerRepository playerRepo;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, MafiaDbContext context, IPlayerRepository playerRepo)
        {
            this.logger = logger;
            this.context = context;
            this.playerRepo = playerRepo;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
