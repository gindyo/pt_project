using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using PTProject.ViewHelpers;
using PTProject.Models;
using PTProject.Tests.Models;

namespace PTProject.Tests.ViewHelpers
{
    [TestClass]
    public class UnitHelperTest
    {
        PT_DB db;

        [TestInitialize]
        public void initialize()
        {
            db = new PT_DB();
        }

        [TestCleanup]
        public void cleanup()
        {
            db.Dispose();
        }

        [TestMethod]
        public void print()
        {
            var unit = UnitFactory.create();

            var factory = new SearchableFactory(db);
            var s1 = factory.create(unit.Id);
            var s2 = factory.create(unit.Id, "", "social_history", "the content of this social history");
            var s3 = factory.create(unit.Id, "", "family_history", "the content of this family history");

            UnitHelper uh = new UnitHelper(unit);
            MvcHtmlString unit_html = uh.print();

            Assert.IsTrue(unit_html.ToString().Contains("social") && !unit_html.ToString().Contains("scial"));
        }
    }
}
