using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoreLinq;
using RecruitmentTaskForJuniorASF.Data;
using RecruitmentTaskForJuniorASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Services;

namespace RecruitmentTaskForJuniorASF.Controllers
{
    public class TranslationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TranslationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [WebMethod]
        public void SuccessfulAjaxPostLogger(SuccessfulResponseAjaxLoggerModel obj)
        {
            NLogCommunicator.Info("text to translate- " + obj.contents.text);
            NLogCommunicator.Info("result-  " + obj.contents.translated);            
        }

        [WebMethod]
        public void FailedAjaxPostLogger(string data)
        {
            NLogCommunicator.Error(data);           
        }

        [HttpGet]
        public IActionResult Create()
        {        
            TranslationRequestVM translationRequestModel = new TranslationRequestVM()
            {
                AvaiableLanguages = _db.Languages.Select(x => new SelectListItem
                {
                    Text = x.Language,
                    Value = x.Id.ToString()
                }).DistinctBy(i=>i.Text)
            };
            return View(translationRequestModel);
        }

    }
}
