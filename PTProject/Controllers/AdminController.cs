using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTProject.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/PendingCaseFiles/

        public ActionResult PendingCasefiles()
        {
            return View();
        }

        //
        // GET: /Admin/

        public ActionResult PendingInterventions()
        {
            return View();
        }

        //
        // GET: /Admin/

        public ActionResult PendingAccounts()
        {
            return View();
        }

        //
        // GET: /Admin/

        public ActionResult UpdateAccounts()
        {
            return View();
        }


    }
}
