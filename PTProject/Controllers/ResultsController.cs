using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;

namespace PTProject.Controllers
{
    public class ResultsController : Controller
    {
        
        //
        // GET: /Results/

        public ActionResult Index(String[] search_types, String search_term)
        {
            using (var db = new PT_DB())
            {

                var results = Searchable.find(search_types, search_term);
              
                test_data = results;
                ViewBag.search_term = search_term;
                ViewBag.results = results;
                return View();
            }
        }

        public List<Searchable> test_data {get; set;}

    }
}
