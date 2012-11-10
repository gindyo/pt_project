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

        public string short_content()
        {
            String reference = search_term;
            int refLocation = content.LastIndexOf(reference);
            int beginningOfShortContent = (refLocation - 35) < 0 ? 0 : refLocation - 35;
            int endOfShortContent = refLocation + 45 > this.content.Length ? this.content.Length : refLocation + 45;
            String short_st = content.Substring(beginningOfShortContent, endOfShortContent) + (endOfShortContent == this.content.Length ? "." : " ...");
            return short_st.Replace(search_term,"<b>"+search_term+"</b>");
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