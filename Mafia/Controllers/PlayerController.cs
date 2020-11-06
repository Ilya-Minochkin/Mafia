using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace Mafia.Controllers
{
    public class PlayerController : Controller
    {
        private ServicesManager _servicesManager;

        public PlayerController(DataManager dataManager)
        {
            _servicesManager = new ServicesManager(dataManager);
        }


        public IActionResult Index(int playerId)
        {
            var player = _servicesManager.Players.GetPlayersList().FirstOrDefault(x => x.Player.Id == playerId);
            return View(player);
        }
    }
}
