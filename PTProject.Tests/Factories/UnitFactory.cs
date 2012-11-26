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
        public static Unit create(int _user_id = 0, string _title = "This is a unit", string _type = "case_study", bool _in_progress = true, bool _approved = false, bool _can_be_searched = false)
        {
            using (var db = new PT_DB())
            {
                _user_id = _user_id == 0 ? UserFactory.create().Id : _user_id;
                Unit new_u = new Unit() { title = _title, type = _type, approved = _approved, can_be_searched = _can_be_searched, in_progress = _in_progress, usersId = _user_id };
                db.Units.AddObject(new_u);
                db.SaveChanges();
                return new_u;
            }
        }

        public static Unit build(string _title = "This is a unit", string _type = "case_study", bool _in_progress = true, bool _approved = false, int _user_id = 0, bool _can_be_searched = false)
        {
            Unit new_u = new Unit() { title = _title, type = _type, approved = _approved, can_be_searched = _can_be_searched, in_progress = _in_progress, usersId = _user_id };
            return new_u;
        }

    }
}
