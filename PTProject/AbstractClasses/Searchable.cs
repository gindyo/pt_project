using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;

namespace PTProject.AbstractClasses
{
    public abstract class Searchable 
    {
        public string search_term { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string keywords { get; set; }

        public string id { get; set; }

        public string link { get; set; }

        public int parent_id { get; set; }

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
                return short_st.Replace(search_term, "<b>" + search_term + "</b>");
            }
            else
            {
                int endOfShortContent =  100 > this.content.Length -1? this.content.Length : 100;
                return content.Substring(0, endOfShortContent) + "...";
            }
        }

        public static bool operator !=(Searchable subject, Searchable compare_to)
        {
            return (subject.id != compare_to.id);
        }

        public static bool operator ==(Searchable subject, Searchable compare_to)
        {
            return (subject.id == compare_to.id);
        }

        
        }
}