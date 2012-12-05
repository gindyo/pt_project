using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;
using PTProject.Tests.Models;

namespace PTProject.Tests.Models
{
    [TestClass]
    public class UnitTest
    {
        Unit u1;
        

        [TestInitialize]
        public void initialize()
        {
            u1 = new Unit();
            u1.type = "type";
            u1.title = "title";
            u1.usersId = "gindyo";
            Unit.insert(u1); 
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (u1 != null)
            {
                u1.destroy();
            }
           
        }

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

        [TestMethod]
        public void unit_is_inserted()
        {
            Unit found = Unit.find(u1.Id);
            Assert.AreEqual(found.title, u1.title);
        }

        [TestMethod]
        public void unit_destroy()
        {
            Unit u = UnitFactory.create();
            u.destroy();
            Assert.AreEqual(null, Unit.find(u.Id));
        }




    }
}
