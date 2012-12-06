using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;

namespace PTProject.Controllers
{ 
    public class SearchablesController : Controller
    {
        private PT_DB db = new PT_DB();

        //
        // GET: /Searchables/

        public ViewResult Index()
        {
            var searchables = db.Searchables.Include("Unit");
            return View(searchables.ToList());
        }

        //
        // GET: /Searchables/Details/5

        public ViewResult Details(int id)
        {
            Searchable searchable = db.Searchables.Single(s => s.Id == id);
            return View(searchable);
        }

        //
        // GET: /Searchables/Create

        public ActionResult Create()
        {
            ViewBag.unitId = new SelectList(db.Units, "Id", "title");
            return View();
        } 

        //
        // POST: /Searchables/Create

        [HttpPost]
        public ActionResult Create(Searchable searchable)
        {
         
            if (ModelState.IsValid)
            {
                db.Searchables.AddObject(searchable);
                db.SaveChanges();
                return RedirectToAction("UserUnits", "unit" );  
            }


            return RedirectToAction("Edit", new { id = searchable.Id });
        }
        
        //
        // GET: /Searchables/Edit/5
 
        public ActionResult Edit(int id)
        {
            Searchable searchable = db.Searchables.Single(s => s.Id == id);
            ViewBag.unitId = new SelectList(db.Units, "Id", "title", searchable.unitId);
            return View(searchable);
        }

        //
        // POST: /Searchables/Edit/5

        [HttpPost]
        public ActionResult Edit(Searchable searchable)
        {
            if (ModelState.IsValid)
            {
                db.Searchables.Attach(searchable);
                db.ObjectStateManager.ChangeObjectState(searchable, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("UserUnits", "unit");
            }
            ViewBag.unitId = new SelectList(db.Units, "Id", "title", searchable.unitId);
            return View(searchable);
        }

        //
        // GET: /Searchables/Delete/5
 
        public ActionResult Delete(int id)
        {
            Searchable searchable = db.Searchables.Single(s => s.Id == id);
            return View(searchable);
        }

        //
        // POST: /Searchables/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Searchable searchable = db.Searchables.Single(s => s.Id == id);
            db.Searchables.DeleteObject(searchable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}