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

        [TestInitialize]
        public void initialize()
        {
            s1 = SearchableFactory.create(0, "", "patient_history", "this is a tes dfasasdfasfsarchable");
            s2 = SearchableFactory.create(0, "", "social_history", "this is a tes dfasasdfasfsarchable");
            s3 = SearchableFactory.create(0, "", "social_history", "this is a tes dimitar");
            s4 = SearchableFactory.create(0, "", "patient_history", "this is a tes dimitar");
            s5 = SearchableFactory.create(0, "", "patient_history", "this is a tes dfasasdfasfsarchable");
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
        public void searchable_factory_works()
        {
            using (var db = new PT_DB())
            {
                Unit p = UnitFactory.create();
                Searchable s = SearchableFactory.create(p.Id);
                s.title = "Hello world";

                Assert.AreEqual(s.unitId, p.Id) ;
                Searchable.destroy(s.Id);
            };
        }

        [TestMethod]
        public void destroys_itself()
        {
            Searchable s = SearchableFactory.create(0, "", "", "this is a test seagaergaschable");
            s.destroy();
            Assert.IsNull(Searchable.find(s.Id));

        }




        [TestMethod]
        public void searchable_find_in_patient_history()
        {
            var found_s = Searchable.find(new[]{"patient_history"}, "dimitar").Count();
            Assert.AreEqual(1,found_s);
            
        }

        [TestMethod]
        public void searchable_find_in_all()
        {
            var found_s = Searchable.find(null, "dimitar").Count();
            Assert.AreEqual(2, found_s);

        }

        [TestMethod]
        public void searchable_assigns_search_term_to_results()
        {
            var content = "this is a tes dfasasdfasfsarchable";
            Searchable s = SearchableFactory.create(0, "", "", content );
            var found_s = Searchable.find(null,"dfasasdfasfsarchable");
            Assert.AreEqual("dfasasdfasfsarchable", found_s.ToList().Last().search_term);
            s.destroy();

        }

        [TestMethod]
        public void find_searchable_by_id()
        {
            Searchable new_s = SearchableFactory.create();
            Assert.IsNotNull(Searchable.find(new_s.Id));
            new_s.destroy();
        }



        [TestMethod]
        public void searchable_pretty_type()
        {
            Searchable new_s = SearchableFactory.build();
            new_s.type = "make_pretty";
            Assert.AreEqual("Make pretty", new_s.pretty_type());
            
        }
    }
}
