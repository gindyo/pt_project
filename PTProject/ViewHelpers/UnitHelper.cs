using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTProject.Models;

namespace PTProject.ViewHelpers
{
    public class UnitHelper
    {
        public static MvcHtmlString print(Unit unit){
            var unit_div = new TagBuilder("div");
            unit_div.Attributes["class"] = unit.type;

            string searchables = "";
            unit.Searchables.ToList().ForEach(delegate(Searchable s)
            {
                var searchable_div = new TagBuilder("div");
                searchable_div.Attributes["id"] = s.type;

                var searchable_div_title = new TagBuilder("h3");
                searchable_div_title.Attributes["class"] = "s_titles";
                searchable_div_title.SetInnerText(s.pretty_type());
                             
                searchable_div.InnerHtml = searchable_div_title.ToString(TagRenderMode.SelfClosing) + s.content;
                
                searchables = searchables + searchable_div.ToString(TagRenderMode.SelfClosing);
            });

            unit_div.InnerHtml = searchables;
            return MvcHtmlString.Create(unit_div.ToString(TagRenderMode.SelfClosing));
        }
    }
}