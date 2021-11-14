using Microsoft.AspNetCore.Mvc;
using RecruitmentTaskForJuniorASF.Data;
using RecruitmentTaskForJuniorASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LanguagesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<LanguageModel> languagesList = _db.Languages;

            return View(languagesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LanguageModel obj)
        {
            if(obj !=null)
            {
                _db.Languages.Add(obj);
                _db.SaveChanges();
                NLogCommunicator.Info($"{obj.Language} has been added");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Languages.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LanguageModel obj)
        {
            if (obj != null)
            {
                _db.Languages.Update(obj);
                _db.SaveChanges();
                NLogCommunicator.Info($"obj with id: {obj.Id} has been changed to {obj.Language}");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Languages.Find(id);
            if (obj == null)
            {
                NLogCommunicator.Error($"obj with id {id} is null or equal to 0");
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Languages.Find(id);
            if (obj == null)
            {
                NLogCommunicator.Error("Object is null");
                return NotFound();
            }
                _db.Languages.Remove(obj);
                _db.SaveChanges();
                 NLogCommunicator.Info($"{obj.Language} been deleted");
                return RedirectToAction("Index");
            }
    }
}
