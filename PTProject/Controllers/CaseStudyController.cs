using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;


namespace PTProject.Controllers
{
    public class CaseStudyController : Controller
    {
        //
        // GET: /CaseStudy/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CaseStudy/Details/5

        public ActionResult Details(int id)
        {
           
            Unit cs = new Unit();
            cs = Unit.find(id);
            

            return View(cs);
        }

        //
        // GET: /CaseStudy/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CaseStudy/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /CaseStudy/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CaseStudy/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CaseStudy/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CaseStudy/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
