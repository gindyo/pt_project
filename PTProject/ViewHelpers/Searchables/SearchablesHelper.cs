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

        private static Searchable _searchable { get; set; }

       

        private static TagBuilder hidden_field
        {
            get
            {
                var hidden = new TagBuilder("input");
                hidden.Attributes["type"] = "hidden";
                return hidden;
            }
        }
        
        public static MvcHtmlString print_searchable(Searchable searchable)
        {
            _searchable = searchable;
             return build_searchable();   
        }

        public static string pretty_type(string tipe = "notype")
        {

            string pty_type = "";
            if (tipe != "notype" && tipe != null)
            {
                string no_ = tipe.Replace('_', ' ');
                pty_type = char.ToUpper(no_[0]) + no_.Substring(1);
            }
            return pty_type;

        }

        private static MvcHtmlString type_selector(Searchable selected )
        {
            

            TagBuilder select_tag = new TagBuilder("select");
            select_tag.Attributes["name"] = "type";
            select_tag.Attributes["id"] = "types";
            var option = new TagBuilder("option");
            option.Attributes["value"] = "";
            option.SetInnerText("Select One");
            option.Attributes["disabled"] = "disabled";
            if ("" == selected.type)
            {
                option.Attributes["selected"] = "selected";
             
            }
            select_tag.InnerHtml = option.ToString();

            foreach (string type in Searchable.unique_types())
            {
              Searchable sbl = new Searchable();
              option = new TagBuilder("option");
              if(unit_has_searchable_with_type(type, ref sbl))
                option.Attributes["onclick"] = "loadSearchable(" + sbl.unitId + ",'" + sbl. type + "')";
              else
                option.Attributes["onclick"] = "clear_textarea()";
             
    
                if (type == selected.type)
                {
                    option.Attributes["selected"] = "selected";
                }
                option.Attributes["value"] = type;
                option.SetInnerText(pretty_type(type));
                select_tag.InnerHtml = new StringBuilder(select_tag.InnerHtml).Append(option.ToString()).ToString();
            }

            return new MvcHtmlString(select_tag.ToString());
        }

        private static bool unit_has_searchable_with_type(string type, ref Searchable  s)
        {
                    using (PT_DB db = new PT_DB())
                    { 
                        bool result = false;
                        var unit = db.Units.SingleOrDefault(u => u.Id == _searchable.unitId );
                        foreach (var redirect_to in unit.Searchables)
                        {
                            if (redirect_to.type == type)
                            {
                                s = redirect_to;
                                result = true;
                                return result;
                            }
                        }
                        return result;
                    }
        }

        private static MvcHtmlString build_searchable( )
        {
            var textarea = new TagBuilder("textarea");
            textarea.Attributes["name"] = "content";
            textarea.AddCssClass("searchable_textarea");
            textarea.Attributes["id"] = "searchable_textarea";
            textarea.SetInnerText(_searchable.content);

            var unit_id = hidden_field;
            unit_id.Attributes["name"] = "unitId";
            unit_id.Attributes["value"] = _searchable.unitId.ToString();

            var id = hidden_field;
            id.Attributes["name"] = "id";
            id.Attributes["value"] = _searchable.Id.ToString();
             
            var br = new TagBuilder("br");
            var searchable_table = new TagBuilder("table");
            var searchable_row1 = new TagBuilder("tr");
            var td1_1 = new TagBuilder("td");
            td1_1.SetInnerText("Choose the type of your content");
            var td1_2 = new TagBuilder("td");
            td1_2.InnerHtml = type_selector(_searchable).ToHtmlString() + unit_id + id;
            searchable_row1.InnerHtml = td1_1.ToString() + td1_2.ToString();
            var searchable_row2 = new TagBuilder("tr");
            var td2_1 = new TagBuilder("td");
            var td2_2 = new TagBuilder("td");
            var submit_button = new TagBuilder("button");
            submit_button.SetInnerText("Submit");
            submit_button.Attributes["id"] = "submit";
            td2_2.InnerHtml = textarea.ToString() + br + submit_button.ToString();
            searchable_row2.InnerHtml = td2_1.ToString() + td2_2.ToString() ;
            searchable_table.InnerHtml = searchable_row1.ToString() + searchable_row2.ToString();
            return new MvcHtmlString(searchable_table.ToString());
        
        }

    }
}