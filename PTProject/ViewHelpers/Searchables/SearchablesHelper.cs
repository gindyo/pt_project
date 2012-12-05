using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Models;
using System.Web.Mvc;
using System.Text;

namespace PTProject.ViewHelpers
{
    public class SearchablesHelper
    {
        
        
        public static MvcHtmlString print_searchable(Searchable searchable)
        {
             
                var searchable_div = new TagBuilder("div");
                searchable_div.Attributes["class"] = "searchable_container";
                searchable_div.Attributes["id"] = "searchable" + searchable.Id.ToString(); 
                var textarea = new TagBuilder("textarea");
                textarea.SetInnerText(searchable.content);
                searchable_div.InnerHtml = textarea.ToString();

                return new MvcHtmlString(searchable_div.ToString());
        
        }

        public static MvcHtmlString new_searchable()
        {

            var searchable_div = new TagBuilder("div");
            var title = new TagBuilder("h3");
            title.SetInnerText(
            searchable_div.Attributes["class"] = "searchable_container";
            searchable_div.Attributes["id"] = "searchable";

            var textarea = new TagBuilder("textarea");
            searchable_div.InnerHtml = type_selector().ToHtmlString();
            searchable_div.InnerHtml += textarea.ToString();

            return new MvcHtmlString(searchable_div.ToString());

        }

        public static MvcHtmlString type_selector(String selected = "")
        {
            TagBuilder select_tag = new TagBuilder("select");
            select_tag.Attributes["name"] = "type";
            var option = new TagBuilder("option");
            option.Attributes["value"] = "";
            option.SetInnerText("Select One");
            if ("" == selected)
            {
                option.Attributes["selected"] = "selected";
            }
            select_tag.InnerHtml = option.ToString();

            foreach (Searchable s in Searchable.unique_types())
            {

                if (s.type == selected)
                {
                    option.Attributes["selected"] = "selected";
                }
                option.Attributes["value"] = s.title;
                option.SetInnerText(s.pretty_type());
                select_tag.InnerHtml = new StringBuilder(select_tag.InnerHtml).Append(option.ToString()).ToString();
            }

            return new MvcHtmlString(select_tag.ToString());
        }




    }
}