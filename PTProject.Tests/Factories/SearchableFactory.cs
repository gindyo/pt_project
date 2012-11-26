using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;

namespace PTProject.Tests.Models
{
    class SearchableFactory
    {
        public static Searchable create(int _unit_id = 0, string _title = "Patient History", string _type = "patient_history", string _content = "bla bla bla" )
        {
            using (var db = new PT_DB())
            {
                _unit_id = _unit_id == 0 ? UnitFactory.create().Id : _unit_id;
                Searchable new_s = new Searchable() { title = _title, type = _type,  content = _content, unitId = _unit_id};
                db.Searchables.AddObject(new_s);
                db.SaveChanges();
                return new_s;
            }
        }

        public static Searchable build(string _title = "Patient History", string _type = "patient_history", string _content = "bla bla bla", int _parent_id = 0)
        {
            using (var db = new PT_DB())
            {
                Searchable new_s = new Searchable() { title = _title, type = _type, content = _content, Id = _parent_id };
                return new_s;
            }
        }
    }
}
