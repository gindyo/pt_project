using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;

namespace PTProject.Tests.Models
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void unit_factory_build_works()
        {
            Unit u = UnitFactory.build();
            u.title = "some title";
            Assert.AreEqual(u.title, "some title");
        }
        [TestMethod]
        public void unit_factory_create_works()
        {
            Unit u = UnitFactory.create();

            var found_unit = Unit.find(u.Id);
            Assert.IsInstanceOfType(found_unit, typeof(PTProject.Models.Unit));

        }



    }
}
