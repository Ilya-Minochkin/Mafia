using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace Mafia.Controllers
{
    public class RecordController : Controller
    {
        private readonly ServicesManager _servicesManager;

        public RecordController(DataManager dataManager)
        {
            _servicesManager = new ServicesManager(dataManager);
        }

        [HttpGet]
        public IActionResult RecordEditor(int recordId)
        {
            RecordEditModel model;
            if (recordId != 0)
            {
                model = _servicesManager.Records.GetRecordEditModel(recordId);
            }
            else
            {
                model = _servicesManager.Records.CreateNewRecordEditModel();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveRecord(RecordEditModel model)
        {
            _servicesManager.Records.SaveRecordEditModelToDb(model);
            return RedirectToAction("Index", "Player", new {id = 1});
        }
    }
}
