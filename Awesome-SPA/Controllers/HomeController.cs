using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Awesome_SPA.Services;

namespace Awesome_SPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInstagramService _instagramService;

        public HomeController(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Awesome Single Page Application";
            return View();
        }
    }
}
