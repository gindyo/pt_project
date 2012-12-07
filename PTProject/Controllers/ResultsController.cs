using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;
using PTProject.ViewHelpers;

namespace PTProject.Controllers
{
    public class ResultsController : Controller
    {
        
        //
        // GET: /Results/
        private PT_DB db = new PT_DB();

        public ActionResult Index(String[] search_types, String search_term)
        {
            Searcher searcher = new Searcher(db);

                var results = searcher.find(search_types, search_term);
              
                test_data = results;
                ViewBag.search_term = search_term;
                
                return View(new ResultsHelper(results));
            
        }

        public List<Searchable> test_data {get; set;}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
