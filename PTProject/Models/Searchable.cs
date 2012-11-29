using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace PTProject.Models
{
    public partial class Searchable 
    {
        public string search_term { get; set; }

        public string link { get{ return "/Unit/Details/"+this.Unit.Id;} }

        public string short_content()
        {
            String reference = search_term;
            int refLocation = 0;
            refLocation = content.LastIndexOf(reference);
            if (refLocation > 0)
            {

                int beginningOfShortContent = (refLocation - 55) < 0 ? 0 : refLocation - 55;
                int lenghtOfSubstring = refLocation + 100 > this.content.Length ? this.content.Length - beginningOfShortContent : refLocation + 100;
                String short_st = content.Substring(beginningOfShortContent,lenghtOfSubstring) + (beginningOfShortContent + lenghtOfSubstring <= this.content.Length ? "." : " ...");
                return short_st;
            }
            else
            {
                int endOfShortContent =  100 > this.content.Length -1? this.content.Length : 100;
                return content.Substring(0, endOfShortContent) + "...";
            }
        }

        
        public string pretty_type()
        {
            string pty_type = "";
            if (this.type.Count() > 0)
            {
                string no_ = this.type.Replace('_', ' ');
                pty_type =  char.ToUpper(no_[0]) + no_.Substring(1);
            }
            return pty_type;
        }

        public static Searchable find(int id)
        {
                var db = new PT_DB();
           
                var query = (from s in db.Searchables
                             where s.Id == id
                             select s).SingleOrDefault();
                Searchable result = new Searchable();
                result = query;
                return result;
            
        }

        public static List<Searchable> find(string[] where_to_search, string search_term)
        {
            return (where_to_search == null) ? search_all(search_term) : search_specific_types(where_to_search, search_term);

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
           
            using (var context = new PT_DB())
            {
                var query = (from s in context.Searchables
                             where s.Id == this.Id
                             select s).FirstOrDefault();
                
                
               
                context.Searchables.DeleteObject(query);
                context.SaveChanges();
            }
        }

        
       

        private static List<Searchable> search_all(string search_term)
        {
            IQueryable<Searchable> query;
            List<Searchable> l;
                var db = new PT_DB();
         
                query = (from s in db.Searchables
                             where s.content.Contains(search_term)
                             select s);
                 query.ToList().ForEach(s => s.search_term = search_term);
                 l = query.ToList();
            
            return l;
        }

        private static List<Searchable> search_specific_types(string[] where_to_search, string search_term)
        {
            List<Searchable> result;
                var db = new PT_DB();
            
                IQueryable<Searchable> query = (from s in db.Searchables
                         where where_to_search.Contains(s.type) && s.content.Contains(search_term)
                         select s);
                query.ToList().ForEach(s => s.search_term = search_term);
                result = query.ToList();
            
            return result;
        }

        private static PT_DB db
        {
            get
            {
                return new PT_DB();
            }
        }
    }
}