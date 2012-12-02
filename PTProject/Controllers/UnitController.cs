using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;
using PTProject.ViewHelpers;


namespace PTProject.Controllers
{
    public class UnitController : Controller
    {
        //
        // GET: /Unit/

        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /Unit/Details/5

        public ActionResult Details(int id)
        {
           
            
            var unit = Unit.find(id);
            var unit_helper = new UnitHelper(unit);

            return View(unit_helper);
        }
       
        //
        // GET: /Unit/Create

        public ActionResult Create()
        {
            //ViewBag.user = 
            return View();
        } 

        //
        // POST: /Unit/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Unit unit = new Unit();
                unit.type = collection["type"];
                unit.title = collection["title"]; 
                unit.usersId = Convert.ToInt32(collection["usersId"]);
                unit.in_progress = Convert.ToBoolean(collection["in_progress"]);
                unit.approved = Convert.ToBoolean(collection["approved"]);

                Unit.insert(unit);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Unit/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Unit/Edit/5

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
        // GET: /Unit/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Unit/Delete/5

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
