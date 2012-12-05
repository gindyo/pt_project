using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Models;
using System.Web.Mvc;
using System.Text;

namespace PTProject.ViewHelpers
{
    public class ResultsHelper
    {
        public List<Unit> unique_units;
        private List<Searchable> _searchables;

        public ResultsHelper(List<Searchable> searchables)
        {
            this._searchables = searchables;
            set_unique_units();
        }

        public MvcHtmlString print()
        {
            MvcHtmlString resulting_string = new MvcHtmlString("");
            StringBuilder string_builder = new StringBuilder();
           foreach( Searchable el in _searchables)
           {
               
               var a_result_div = new TagBuilder("div");
               var link = new TagBuilder("a");
               var short_content = new TagBuilder("div");
               var bold_s_term = new TagBuilder("b");

               bold_s_term.InnerHtml = el.search_term;

               link.Attributes["href"] = el.link;
               link.SetInnerText(new StringBuilder(el.Unit.title).Append(": ").Append(el.pretty_type()).ToString());

               short_content.InnerHtml =  el.short_content().Replace(el.search_term, bold_s_term.ToString());

               a_result_div.InnerHtml = string_builder.Append(link.ToString()).Append(short_content.ToString()).ToString();

               resulting_string = new MvcHtmlString(a_result_div.ToString());
           }

           return resulting_string;

        }



        private void set_unique_units()
        {
            List<int> unit_ids = new List<int>();
            unique_units = new List<Unit>();

            _searchables.ForEach(s =>
                {

                    if (!unit_ids.Contains(s.unitId))
                    {
                        
                        unit_ids.Add(s.unitId);
                        unique_units.Add(s.Unit);
                    }

                });
        }
    }
}