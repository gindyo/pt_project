using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;

namespace PTProject.Controllers
{
    public class HomeController : Controller
    {

        private PT_DB db = new PT_DB();
        public ActionResult Index()
        {
            
            ViewBag.search_types = Searchable.unique_types();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult UserManual()
        {
            return View();
        }
        public ActionResult HomePageTutorial()
        {
            return View();
        }

        public ActionResult LogOnInstructions()
        {
            return View();
        }

        public ActionResult AdministrativePageInstruct()
        {
            return View();
        }

        public ActionResult RegisterInstructions()
        {
            return View();
        }

        public ActionResult UserHomePageInstruct()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Tutorials()
        {
            return View();
        }

        
    }
}
