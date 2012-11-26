using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Models;
using PTProject.Interfaces;

namespace PTProject.DB
{
    public class Parents
    {
        private List<int> _ids;
        private List<String> _titles;
        private List<String> _types;

        public Parents()
        {
            _ids = new List<int>();
            _titles = new List<string>();
            _types = new List<string>();

            _titles.Add("My First Study");
            _ids.Add(1);
            _types.Add("case_study");

            _titles.Add("My Second Study");
            _ids.Add(2);
            _types.Add("case_study");

            _titles.Add("My First Intervention");
            _ids.Add(3);
            _types.Add("intervention");
        }

        public int insert(String title, String type){
            _types.Add(type);
            _titles.Add(title);
            int last_id = _ids.Last<int>();

            _ids.Add(last_id++);
            return last_id++;
        }

        public IParent find_by_id(int id){
            IParent p;
            if (_types[id] == "case_study")
            {
                 p = new CaseStudy();
            }
            else{
                 p = new Intervention();
            }




            p.id = _ids.IndexOf(id);
            if (p.id >= 0)
            {
                p.title = _titles[_ids.IndexOf(id)];
            }
            Searchables db = new Searchables();
            p.contents = db.find_by_parent_id(id);
            return p;
        }
    }
}