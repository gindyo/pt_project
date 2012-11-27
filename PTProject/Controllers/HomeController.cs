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
        public ActionResult Index()
        {

            var db = new PT_DB();
            var query = from s in db.Searchables
                        group s by s.type into uniqueTypes
                        select uniqueTypes.FirstOrDefault().type;
            ViewBag.search_types = query.ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
