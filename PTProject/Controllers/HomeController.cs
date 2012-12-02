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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        
    }
}
