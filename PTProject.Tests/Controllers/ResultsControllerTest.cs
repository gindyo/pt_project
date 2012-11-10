using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PTProject.Controllers;
using PTProject.AbstractClasses;
namespace PTProject.Tests.Controllers
{
    [TestClass]
    public class ResultsControllerTest
    {
        [TestMethod]
        public void index()
        {
            ResultsController c = new ResultsController();
            c.Index(new [] {"titles","contents"}, "case");
            List<Searchable> result = c.test_data;
            
            Assert.AreEqual(4, result.Count);


        }
    }
}
