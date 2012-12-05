using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using PTProject.Models; 

namespace PTProject.ViewHelpers
{
    public class HomeHelper
    {
        public static MvcHtmlString type_checkboxes()
        {
            StringBuilder types_block = new StringBuilder();
            var unique_types = Searchable.unique_types();

            TagBuilder div = new TagBuilder("div");
            
            foreach(Searchable s in unique_types)
            {
                var filter_div = new TagBuilder("div");
                filter_div.Attributes["class"] = "filter";
                TagBuilder input = new TagBuilder("input");
                input.Attributes["type"] = "checkbox";
                input.Attributes["id"] = s.type;
                input.Attributes["name"] = "search_types";
                input.Attributes["value"] = s.type;
                input.Attributes["class"] = "search_types";
                filter_div.InnerHtml = new StringBuilder(input.ToString(TagRenderMode.SelfClosing)).Append(s.pretty_type()).ToString();
                types_block.Append(filter_div);
            }
            return new MvcHtmlString(types_block.ToString());

        }

    }
}