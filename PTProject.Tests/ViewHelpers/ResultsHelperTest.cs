using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;
using PTProject.ViewHelpers;
using PTProject.Tests.Models;

namespace PTProject.Tests.ViewHelpers
{
    [TestClass]
    public class ResultsHelperTest
    {
        List<Searchable> result;
        ResultsHelper helper;
        Searchable s1;
        Searchable s2;
        Searchable s3;
        Searchable s4;
        Searchable s5;

        [TestInitialize]
        public void initialize()
        {

            s1 = SearchableFactory.create(0, "", "patient_history", "this is a test value fdsfasd test value fdsfasdfgsgr fgsgr tes dfasasdfasfsarchable");
            s2 = SearchableFactory.create(0, "", "social_history", "this is a tes dfasa test value fdsfasdfgsgr sdfasfsarchable");
            s3 = SearchableFactory.create(0, "", "social_history", "this test value f test value fdsfasdfgsgr dsfasdfgsgr");
            s4 = SearchableFactory.create(0, "", "patient_ history", "this is a t test value fdsfasdfgsgres dfasasdfasfsarchable");
            s5 = SearchableFactory.create(0, "", "patient_history", "this is a t test value fdsfasdfgsgr es dfasasdfasfsarchable");
            
            helper = new ResultsHelper(Searchable.find(new[]{"patient_history", "social_history"}, "test value fdsfasdfgsgr"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (s1 != null)
                s1.destroy();
            if (s2 != null)
                s2.destroy();
            if (s3 != null)
                s3.destroy();
            if (s4 != null)
                s4.destroy();
            if (s5 != null)
                s5.destroy();
        }

        [TestMethod]
        public void print()
        {
            string page = helper.print().ToString();
            Assert.IsTrue(page.Contains(" <b>test value fdsfasdfgsgr</b>"));
           
        }
    }
}
