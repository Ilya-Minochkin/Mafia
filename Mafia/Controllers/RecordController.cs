using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace Mafia.Controllers
{
    public class RecordController : Controller
    {
        private readonly ServicesManager _servicesManager;

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
