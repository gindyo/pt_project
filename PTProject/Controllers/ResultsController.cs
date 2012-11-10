using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;
using PTProject.AbstractClasses;

namespace PTProject.Controllers
{
    public class ResultsController : Controller
    {
        
        //
        // GET: /Results/

        public ActionResult Index(String[] searchTypes, String searchTerm)
        {
            List<Searchable> results = new List<Searchable>();
           
            FakeDB db = new FakeDB();
            results = db.find( searchTypes, searchTerm);
              

             test_data = results;
             ViewBag.results = results;
            return View();
        }

        public List<Searchable> test_data {get; set;}

    }
}
