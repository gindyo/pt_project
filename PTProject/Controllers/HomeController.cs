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

            using (var db = new PT_DB())
            {
                var query = from s in db.Searchables
                            select s.type.Distinct();
            

                ViewBag.search_types = query.ToList();

                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
