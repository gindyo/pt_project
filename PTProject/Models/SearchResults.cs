using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.AbstractClasses;

namespace PTProject.Models
{
    public class SearchResults
    {
        public SearchResults(List<Searchable> results)
        {
            results.ForEach(
                delegate(Searchable result)
                {
                    prep_test_data(result);


                });


        }

        public List<String> links {get; private set;}

        public List<String> contents { get; private set; }

        public List<String> titles { get; private set; }

        public List<String> keywords { get; private set; }


        private void prep_test_data(Searchable result)
        {
            links.Add(result.link);
            contents.Add(result.content);
            titles.Add(result.title);
            keywords.Add(result.keywords);
        }
    }
}