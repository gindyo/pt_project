using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PTProject.Models;
using System.Data.Entity;
using System.Collections.Generic;


namespace PTProject.Tests.Models
{
    

    [TestClass]
    public class SearchableTest
    {
        Searchable s1;
        Searchable s2;
        Searchable s3;
        Searchable s4;
        Searchable s5;
        Searcher searcher;
        PT_DB db;

        [TestInitialize]
        public void Initialize()
        {
           
            db = new PT_DB();
            var factory = new SearchableFactory(db);
            s1 = factory.create(0,  "patient_history", "this is a tes dfasasdfasfsarchable");
            s2 = factory.create(0,  "social_history", "this is a tes dfasasdfasfsarchable");
            s3 = factory.create(0,  "social_history", "this is a tes dimitar");
            s4 = factory.create(0,  "patient_history", "this is a tes dimitar");
            s5 = factory.create(0,  "patient_history", "this is a tes dfasasdfasfsarchable");
            searcher = new Searcher(db);
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
            db.Dispose();

        }
       
        [TestMethod]
        public void searchable_factory_works()
        {
            using (var db = new PT_DB())
            {
                Unit p = UnitFactory.create();
                Searchable s = new SearchableFactory(db).create(p.Id);
                s.type = "Hello world";

                Assert.AreEqual(s.unitId, p.Id) ;
                Searchable.destroy(s.Id);
            };
        }

        [TestMethod]
        public void destroys_itself()
        {
            Searchable s = new SearchableFactory(db).create(0, "", "this is a test seagaergaschable");
            s = db.Searchables.Single(sl => sl.Id == s.Id);
            s.destroy();
            Assert.IsNull(searcher.find(s.Id));

        }




        [TestMethod]
        public void searchable_find_in_patient_history()
        {
            var found_s = searcher.find(new[]{"patient_history"}, "dimitar").Count();
            Assert.AreEqual(1,found_s);
            
        }

        [TestMethod]
        public void searchable_find_in_all()
        {
            var found_s = searcher.find(null, "dimitar").Count();
            Assert.AreEqual(2, found_s);

        }

        [TestMethod]
        public void searchable_assigns_search_term_to_results()
        {
            var content = "this is a tes dfasasdfasfsarchable";
            Searchable s = new SearchableFactory(db).create(0, "", content );
            var found_s = searcher.find(null,"dfasasdfasfsarchable");
            Assert.AreEqual("dfasasdfasfsarchable", found_s.ToList().Last().search_term);
            s.destroy();

        }

        [TestMethod]
        public void find_searchable_by_id()
        {
            Searchable new_s = new SearchableFactory(db).create();
            Assert.IsNotNull(searcher.find(new_s.Id));
            new_s.destroy();
        }



       
    }
}
