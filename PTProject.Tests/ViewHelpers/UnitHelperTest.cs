using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;
using PTProject.Tests.Models;
using System.Collections.Generic;

namespace PTProject.Tests.ViewHelpers
{
    [TestClass]
    public class UnitHelperTest
    {
        

        [TestMethod]
        public void print()
        {
            var unit = UnitFactory.create();
            var s1 = SearchableFactory.create(unit.Id);
            var s2 = SearchableFactory.create(unit.Id, "", "social_history", "the content of this social history");
            var s3 = SearchableFactory.create(unit.Id, "", "family_history", "the content of this family history");

            var result = Searchable.find(new[] { "social_history", "family_history" }, "family");

            var units = new List<int>();


        }
    }
}
