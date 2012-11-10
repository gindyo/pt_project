using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;
using PTProject.Models;
using PTProject.AbstractClasses;


namespace PTProject.Models
{
    public class FakeDB
    {
        public List<String> contents { get; private set; }
        public List<String> titles { get; private set; }
        public List<String> types { get; private set; }
        public List<String> keywords { get; private set; }
        public List<String> ids { get; private set; }

        public FakeDB()
        {
            this.contents = new List<string>();
            this.titles = new List<string>();
            this.types = new List<string>();
            this.keywords = new List<string>();
            this.ids = new List<string>();


            contents.Add("this is the first case study. It does not consist of anything");
            titles.Add("My first case study");
            types.Add("CaseStudy");
            keywords.Add("bla");
            ids.Add("1");


            contents.Add("This patient was evaluated/examined in an outpatient setting where lab values werent available");
            titles.Add("My first intervention");
            types.Add("Intervention");
            keywords.Add("hello, case");
            ids.Add("2");

            contents.Add("The patient presented at IE with c/o of ® heel pain felt when taking the first few steps upon awakening felt for a month and half now. She was referred by an orthopaedist with the diagnosis of ® plantar fasciitis and her x-rays reveal a minor heel spur. She had been walking for a while before she came in the clinic");
            titles.Add("My first case study");
            types.Add("CaseStudy");
            keywords.Add("bla");
            ids.Add("3");

            contents.Add("I palapated her ® heel and there was point tenderness. Her ® gastrco-soleus complex were tight upon examination");
            titles.Add("My first case study");
            types.Add("CaseStudy");
            keywords.Add("bla");
            ids.Add("4");

            contents.Add("this is the first case study. It does not consist of anything");
            titles.Add("ankle ms strength were");
            types.Add("CaseStudy");
            keywords.Add("bla");
            ids.Add("5");
        }

        public List<Searchable> find(String[] whereArray, String search_term)
        {
            List<Searchable> results = new List<Searchable>();

            try
            {
                if (whereArray[0] != "all")
                {
                    List<int> indexes = new List<int>();
                    whereArray.ToList<String>().ForEach(delegate(String where)
                        {
                            List<String> where_to_search = (List<String>)this.GetType().GetProperty(where).GetValue(this);
                            indexes.AddRange(search_in(where_to_search, search_term));

                        });

                    results = prepare_results(indexes.Distinct().ToList(), search_term);
                }
                else
                {
                    List<int> indexes = new List<int>();
                    List<int> i1 = search_in(contents, search_term);
                    List<int> i2 = search_in(titles, search_term);
                    List<int> i3 = search_in(keywords, search_term);
                    if (i1 != null)
                    { indexes.AddRange(i1); }
                    if (i2 != null)
                    { indexes.AddRange(i2); }
                    if (i3 != null)
                    { indexes.AddRange(i3); }
                    results = prepare_results(indexes.Distinct().ToList(), search_term);
                }
            }
            catch
            {
                return new List<Searchable>();
            }
            
            return results;
        }

              
        private List<Searchable> prepare_results(List<int> indexes, String search_term)
        {
            List<Searchable> result = new List<Searchable>();
            foreach (int el in indexes)
            {
                Type type = Type.GetType(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".Models." + types[el]);
                object typeInstace = Activator.CreateInstance(type);

                Searchable item = typeInstace as Searchable;
                item.title = titles[el];
                item.content = contents[el];
                item.id = ids[el];
                item.search_term = search_term ;
                result.Add(item);
            }
            return result;
        }

        private List<int> search_in(List<String> where, String what)
        {
            List<int> result = new List<int>();
            int count = 0;
            foreach (String element in where)
            {
                if (element.Contains(what))
                {
                    result.Add(count);
                }
                count++;
            }
            return result;

        }



    }
}