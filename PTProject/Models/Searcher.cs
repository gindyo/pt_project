using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTProject.Models
{
    public class Searcher
    {
        private PT_DB db;

        public Searcher(PT_DB context)
        {
            db = context;
        }

        public Searchable find(int id)
        {
           return db.Searchables.SingleOrDefault(s => s.Id == id);
        }

        public List<Searchable> find(string[] where_to_search, string search_term)
        {
            return (where_to_search == null) ? search_all(search_term) : search_specific_types(where_to_search, search_term);

        }

        private List<Searchable> search_all(string search_term)
        {
            IQueryable<Searchable> query;
            List<Searchable> l;

            query = (from s in db.Searchables
                     where s.content.Contains(search_term)
                     select s);
            query.ToList().ForEach(s => s.search_term = search_term);
            l = query.ToList();

            return l;
        }

        private List<Searchable> search_specific_types(string[] where_to_search, string search_term)
        {
            List<Searchable> result;
            IQueryable<Searchable> query = (from s in db.Searchables
                                            where where_to_search.Contains(s.type) && s.content.Contains(search_term)
                                            select s);
            query.ToList().ForEach(s => s.search_term = search_term);
            result = query.ToList();

            return result;
        }

    }
}