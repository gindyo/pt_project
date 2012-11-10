using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PTProject.Tests.Models
{
    [TestClass]
    public class UserModelsTest
    {
       

        [TestMethod]
        public void UserTypeIsCorrect()
        {
            Searcher me = new Searcher();
            Assert.AreEqual(me.type, "Searcher");
        }
        [TestMethod]
        public void CommenerCanSearch()
        {
            Commenter me = new Commenter();
            
        }
        [TestMethod]
        public void ReviewerCanReview()
        {
            CaseStudy cs = new CaseStudy("","","");
            Reviewer me = new Reviewer();
            
        }








    }
}
