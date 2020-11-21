using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace Mafia.Controllers
{
    public class GameController : Controller
    {
        private ServicesManager _servicesManager;

        public GameController(DataManager dataManager)
        {
            _servicesManager = new ServicesManager(dataManager);
        }

        public IActionResult GameList()
        {
            var games = _servicesManager.Games.GetGamesList();
            return View(games);
        }

        public IActionResult Index(int gameId)
        {
            var game = _servicesManager.Games.GameDbToViewModel(gameId);
            return View(game);
        }
    }
}
