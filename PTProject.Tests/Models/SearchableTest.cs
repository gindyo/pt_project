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
            Searchable s1 = SearchableFactory.create(0, "", "patient_history", "this is a tes dfasasdfasfsarchable");
            Searchable s2 = SearchableFactory.create(0, "", "social_history", "this is a tes dfasasdfasfsarchable");
            Searchable s3 = SearchableFactory.create(0, "", "social_history", "this is a tes dfasasdfasfsarchable");
            Searchable s4 = SearchableFactory.create(0, "", "patient_history", "this is a tes dfasasdfasfsarchable");
            Searchable s5 = SearchableFactory.create(0, "", "patient_history", "this is a tes dfasasdfasfsarchable");

            var found_s = Searchable.find(new[]{"patient_history"}, "dfasasdfasfsarchable").Count();
            Assert.AreEqual(3,found_s);
            s1.destroy();
            s2.destroy();
            s3.destroy();
            s4.destroy();
            s5.destroy();
        }

        [TestMethod]
        public void searchable_assigns_search_term_to_results()
        {
            var content = "this is a tes dfasasdfasfsarchable";
            Searchable s = SearchableFactory.create(0, "", "", content );
            var found_s = Searchable.find_in_content("dfasasdfasfsarchable");
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
