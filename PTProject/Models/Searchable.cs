using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PTProject.Models
{
    public partial class Searchable 
    {
        public string search_term { get; set; }

        public string link { get; set; }

        public string short_content(string search_term)
        {
            String reference = search_term;
            int refLocation = 0;
            refLocation = content.LastIndexOf(reference);
            if (refLocation > 0)
            {

                int beginningOfShortContent = (refLocation - 55) < 0 ? 0 : refLocation - 55;
                int lenghtOfSubstring = refLocation + 100 > this.content.Length ? this.content.Length - beginningOfShortContent : refLocation + 100;
                String short_st = content.Substring(beginningOfShortContent,lenghtOfSubstring) + (beginningOfShortContent + lenghtOfSubstring <= this.content.Length ? "." : " ...");
                return short_st.Replace(search_term, "<b>" + search_term + "</b>");
            }
            else
            {
                int endOfShortContent =  100 > this.content.Length -1? this.content.Length : 100;
                return content.Substring(0, endOfShortContent) + "...";
            }
        }

        
        public string pretty_type()
        {
            string no_ = this.type.Replace('_', ' ');
            return char.ToUpper(no_[0]) + no_.Substring(1);
        }

        public static Searchable find(int id)
        {
            using (var db = new PT_DB())
            {
                var query = (from s in db.Searchables
                             where s.Id == id
                             select s).SingleOrDefault();
                Searchable result = new Searchable();
                result = query;
                return result;
            }
        }

        public static void destroy(int id)
        {
            using (var db = new PT_DB())
            {
                var query = from s in db.Searchables
                            where s.Id == id
                            select s;
                db.Searchables.DeleteObject(query.FirstOrDefault());

            }
        }

        public void destroy()
        {
            using (var db = new PT_DB())
            {
                var query = from s in db.Searchables
                            where s.Id == this.Id
                            select s;
                db.Searchables.DeleteObject(query.FirstOrDefault());
                db.SaveChanges();
            }
        }

        public static List<Searchable> find(string[] where_to_search, string search_term)
        {
                 
                using (var db = new PT_DB()){
                var query = (from s in db.Searchables
                            where where_to_search.Contains(s.type) && s.content.Contains(search_term)
                            select s);

                query.ToList().ForEach(s => s.search_term = search_term); 
                return query.ToList();
             }

        }

        public static IQueryable<Searchable> find_in_content(string search_term)
        {
            var db = new PT_DB();
            var query = from s in db.Searchables
                            where s.content.Contains(search_term)
                            select s;
            query.ToList().ForEach(s => s.search_term = search_term); 
            return query;
        }
    }
}