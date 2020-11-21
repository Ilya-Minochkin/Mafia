using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using System.Linq;

namespace Mafia.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ServicesManager _servicesManager;

        public PlayerController(DataManager dataManager)
        {
            _servicesManager = new ServicesManager(dataManager);
        }


        public IActionResult Index(int playerId)
        {
            var player = _servicesManager.Players.PlayerDbToViewModel(playerId);
            return View(player);
        }

        [HttpGet]
        public IActionResult PlayerEditor(int playerId)
        {
            var playerEditModel = _servicesManager.Players.GetPlayerEditModel(playerId);
            return View(playerEditModel);
        }

        [HttpPost]
        public IActionResult SavePlayer(PlayerEditModel model)
        {
            _servicesManager.Players.SavePlayerEditModelToDb(model);
            return RedirectToAction("PlayerEditor", "Player", new {playerId = model.Id});
        }

        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            if (id != 0)
            {
                var model = _servicesManager.Players.PlayerDbToViewModel(id);
                _servicesManager.Players.DeletePlayer(model);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }

        public IActionResult AddNewRecord(int playerId)
        {
            _servicesManager.Players.AddNewRecord(_servicesManager.Players.PlayerDbToViewModel(playerId));
            return RedirectToAction("Index", "Player", new {playerId = playerId});
        }
    }
}
