using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;
using PTProject.Interfaces;
using PTProject.AbstractClasses;
using System.Collections.Generic;


namespace PTProject.Tests.Models
{
    [TestClass]
    public class FakeDBTest
    {
        [TestMethod]
        public void Find()
        {
            FakeDB db = new FakeDB();
            List<Searchable> result = db.find(new []{"contents"},"case");
            Assert.AreEqual(2, result.Count);

        }

        [TestMethod]
        public void findInAll()
        {
            FakeDB db = new FakeDB();
            List<Searchable> result = db.find( new []{"all"}, "case");
            Assert.AreEqual(5, result.Count);
           
        }
       
       
    }
}
