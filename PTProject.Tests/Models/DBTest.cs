using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Models;
using PTProject.Interfaces;
using System.Collections.Generic;
using System.Data.Ob

namespace PTProject.Tests.Models
{
    [TestClass]
    public class SearchablesTest
    {
        [TestMethod]
        public void Find()
        {
            using ( var db = new PT_DB()){
                Searchable s = new Searchable { content = "lkjadlfkj" };
                db.Searchables.Add(s);
                db.SaveCanges();
                List<Searchable> result = db.find(new[] { "contents" }, "case");
                Assert.AreEqual(1, result.Count);
            }
        }

        //[TestMethod]
        //public void findInAll()
        //{
        //    Searchables db = new Searchables();
        //    List<Searchable> result = db.find( new []{"all"}, "case");
        //    Assert.AreEqual(1, result.Count);
           
        //}

        //[TestMethod]
        //public void PartentFind_by_id()
        //{
        //    Parents paretns = new Parents();
        //    IParent p = paretns.find_by_id(1);
        //    Assert.AreEqual("My First Study", p.title);
        //}
    }
    }

      
