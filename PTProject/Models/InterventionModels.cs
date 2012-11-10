using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;
using PTProject.AbstractClasses;

namespace PTProject.Models
{
    public class Intervention: Searchable
    {



        public string title { get; set; }

        public string short_content(String reference)
        {
            int refLocation = content.LastIndexOf(reference);
            int beginningOfShortContent = (refLocation - 35) < 0 ? 0 : refLocation - 35;
            int endOfShortContent = refLocation + 45 > this.content.Length ? this.content.Length : refLocation + 45; 
            return content.Substring(beginningOfShortContent, endOfShortContent) + (endOfShortContent==this.content.Length ? "." : " ...");
        }

        public string link()
        {
            return "/interventions/details/" + id;
        }

        public string content { get; set; }

        public int id { get; set; }


        public string short_content()
        {
            throw new NotImplementedException();
        }


        public string keywords { get; set; }
    }
}