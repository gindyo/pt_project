using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;

namespace PTProject.Tests.Models
{
    class UnitFactory
    {
        public static Unit create(string _user_id = "gindyo", string _title = "This is a unit", string _type = "case_study", bool _in_progress = true, bool _approved = false, bool _can_be_searched = false)
        {
            
            Unit new_u = new Unit() { title = _title, type = _type, approved = _approved, can_be_searched = _can_be_searched, in_progress = _in_progress, usersId = _user_id };

            var db = new PT_DB();
            
                db.Units.AddObject(new_u);
                db.SaveChanges();
            
            return new_u;
        }

        public static Unit create_with_children(string _user_id = "gindyo", string _title = "This is a unit", string _type = "case_study", bool _in_progress = true, bool _approved = false, bool _can_be_searched = false)
        {
            
            Unit new_u = new Unit() { title = _title, type = _type, approved = _approved, can_be_searched = _can_be_searched, in_progress = _in_progress, usersId = _user_id };

            var db = new PT_DB();

            db.Units.AddObject(new_u);


           var factory = new SearchableFactory(db);
           Searchable s1 = factory.create(new_u.Id, "patient_history", "this is a tes dfasasdfasfsarchable");
           Searchable s2 = factory.create(new_u.Id, "social_history", "this is a tes dfasasdfasfsarchable");
           Searchable s3 = factory.create(new_u.Id, "social_history", "this is a tes dfasasdfasfsarchable");
           Searchable s4 = factory.create(new_u.Id, "patient_history", "this is a tes dfasasdfasfsarchable");
           Searchable s5 = factory.create(new_u.Id, "patient_history", "this is a tes dfasasdfasfsarchable");



            db.SaveChanges();

            return new_u;
        }

        public static Unit build(string _title = "This is a unit", string _type = "case_study", bool _in_progress = true, bool _approved = false, string _user_id = "gindyo", bool _can_be_searched = false)
        {
            Unit new_u = new Unit() { title = _title, type = _type, approved = _approved, can_be_searched = _can_be_searched, in_progress = _in_progress, usersId = _user_id };
            return new_u;
        }

    }
}
