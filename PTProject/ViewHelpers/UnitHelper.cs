using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using PTProject.Models;

namespace PTProject.ViewHelpers
{
    public class UnitHelper
    {
        public Unit unit { get; set; }
        

        public UnitHelper(Unit unit)
        {
            this.unit = unit;
           
        }


        public MvcHtmlString print(){
            var unit_div = new TagBuilder("div");
            StringBuilder cls = new StringBuilder(unit.type);
            unit_div.Attributes["class"] = cls.Append(" unit").ToString();

            StringBuilder searchables_string = new StringBuilder();
            
            unit.Searchables.ToList().ForEach(delegate(Searchable s)
            {
                var searchable_div = new TagBuilder("div");
                searchable_div.Attributes["id"] = s.type;
                searchable_div.Attributes["class"] = "searchable";

                var searchable_div_title = new TagBuilder("h3");
                searchable_div_title.Attributes["class"] = "s_titles";
                searchable_div_title.SetInnerText(s.pretty_type());
                             
                searchable_div.InnerHtml = searchable_div_title.ToString() + s.content;
                
                
                searchables_string.Append(searchable_div.ToString());

               
            });

            unit_div.InnerHtml = searchables_string.ToString();
            return MvcHtmlString.Create(unit_div.ToString());
        }
    }
}