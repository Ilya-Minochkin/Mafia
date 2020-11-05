using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mafia.Models;
using BusinessLayer.Interfaces;
using DataLayer.Entities;

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private DataManager _dataManager;

        public HomeController(ILogger<HomeController> logger, DataManager dataManager)
        {
            this.logger = logger;
            this._dataManager = dataManager;
        }

        public IActionResult Index()
        {
            List<Player>_players = _dataManager.Players.GetAllPlayers().ToList();
            return View(_players);
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
