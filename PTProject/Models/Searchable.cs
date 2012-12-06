using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace PTProject.Models
{
    public partial class Searchable 
    {
        public string search_term { get; set; }

        public string link { get{ return "/Unit/Details/"+this.unitId;} }

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
        


        public static List<string> unique_types()
        {
            using (PT_DB db = new PT_DB())
            {
                var types = from u in db.Searchables
                            group u by u.type into unique_types
                            select unique_types.FirstOrDefault().type;
                return types.ToList();
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
           
            using (var context = new PT_DB())
            {
                var query = (from s in context.Searchables
                             where s.Id == this.Id
                             select s).FirstOrDefault();
                
                
               
                context.Searchables.DeleteObject(query);
                context.SaveChanges();
            }
        }

        
       

        

        
    }
}