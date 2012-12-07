using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
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

        public static MvcHtmlString can_be_searched(int user_id)
        {
            var can_be_searched = new MvcHtmlString("");
            User user;
            using (PT_DB db = new PT_DB())
            {
                user = db.Users.Single(u => u.Id == user_id);
            }


            return can_be_searched;

            
        }

    }
}