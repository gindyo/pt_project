using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Web.Security;
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
                searchable_div_title.SetInnerText(SearchablesHelper.pretty_type(s.type));
                             
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

            foreach (Unit u in Unit.unique_types())
            {
                
                if (u.type == selected)
                {
                    option.Attributes["selected"] = "selected";
                }
                option.Attributes["value"] = u.title;
                option.SetInnerText(u.pretty_type());
                select_tag.InnerHtml = new StringBuilder(select_tag.InnerHtml).Append(option.ToString()).ToString();
            }

            return new MvcHtmlString(select_tag.ToString());
        }

        public MvcHtmlString unit_components()
        {
            var searchables = unit.Searchables.ToList<Searchable>();
            var components = new StringBuilder();
            foreach (var s in searchables)
            {
                components.Append(SearchablesHelper.print_searchable(s));
            }
            return new MvcHtmlString(components.ToString());
        }

        public MvcHtmlString unit_components_links()
        {
            
            List<Searchable> unit_components = new List<Searchable>();
            using (PT_DB db = new PT_DB())
            {
                unit_components = db.Searchables.Where(s => s.unitId == unit.Id ).ToList<Searchable>();
            }

            StringBuilder links_str = new StringBuilder();
            foreach (Searchable s in unit_components)
            {
                TagBuilder link = new TagBuilder("a");
                link.Attributes["href"] = "/searchables/edit/" + s.Id.ToString();
                link.SetInnerText(SearchablesHelper.pretty_type(s.type));
                links_str.Append(link).Append(new TagBuilder("br"));
            }
            return new MvcHtmlString(links_str.ToString());
        }

    }
}