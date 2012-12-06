﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;
using PTProject.ViewHelpers;
using System.Web.Security;


namespace PTProject.Controllers
{
    public class UnitController : Controller
    {
        private MembershipUser membership_user { get { return Membership.Provider.GetUser(User.Identity.Name, true); } }
        private PT_DB db = new PT_DB();
        private Unit _unit { 
            get
            {
                var id = Int32.Parse((string)this.RouteData.Values["id"]);
                return db.Units.SingleOrDefault(u => u.Id == id); 
            } 
        }
        //
        // GET: /Unit/
        [Authorize(Roles = "instructror")]
        [Authorize(Roles = "super")]
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            
            return View(db.Units);
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
            ViewBag.user_is_instructor = User.IsInRole("instructor");
            return View();
        } 

        //
        // POST: /Unit/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            
                // TODO: Add insert logic here
                Unit unit = new Unit();
                unit.type = collection["type"];
                unit.title = collection["title"];
                unit.usersId = membership_user.ProviderUserKey.ToString();
                Unit.insert(unit);

                return RedirectToAction("UserUnits");
           
        }
        
        //
        // GET: /Unit/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(db.Units.SingleOrDefault(u=>u.Id == id));
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
        [Authorize(Roles = "instructror")]
        [Authorize(Roles = "super")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Unit/Delete/5
        [Authorize(Roles = "instructror")]
        [Authorize(Roles = "super")]
        [Authorize(Roles = "admin")]
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

        public ActionResult UserUnits()
        {
            UserUnitsHelper uuh = new UserUnitsHelper(membership_user);
            
            return View(uuh);
        }

        public ActionResult EditContent(int id, string type = "")
        {
            UnitHelper uh = new UnitHelper(_unit);
            ViewBag.unit_helper = uh;
            var sbl = new Searchable();
            var s_count = db.Searchables.Where(s => s.unitId == _unit.Id && s.type == type ).Count();
            if( s_count > 0 )
            {
                sbl =_unit.Searchables.Where(s => s.type == type).FirstOrDefault();
            }
            else
            {
               
                sbl.unitId = id;
                sbl.type = "";
            }

            ViewBag.post_to = sbl.Id == 0 ? "/searchables/create" : "/searchables/edit";
            
            ViewBag.searchable = sbl;
            
            return View(_unit);
        }





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
