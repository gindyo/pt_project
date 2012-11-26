using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;
using PTProject.Models;



namespace PTProject.DB
{
    public class Searchables : IStorage
    {
         List<String> _contents { get;  set; }
         List<String> _types { get;  set; }
         List<int> _ids { get;  set; }
         List<int> _parent_ids { get;  set; }
         List<Boolean> _can_search { get;  set;}
        

        public Searchables()
        {
            this._contents = new List<string>();
            this._types = new List<string>();
            this._ids = new List<int>();
            this._parent_ids = new List<int>();
            this._can_search = new List<bool>();

            this.insert(1, 2, "patient_history", "this is the first case study. It does not consist of anything. And this is some random text to make it bigger");
            this.insert(2, 1, "patient_history", "This patient was evaluated/examined in an outpatient setting where lab values werent available");
            this.insert(3, 1, "medical_history", "The patient presented at IE with c/o of ® heel pain felt when taking the first few steps upon awakening felt for a month and half now. She was referred by an orthopaedist with the diagnosis of ® plantar fasciitis and her x-rays reveal a minor heel spur. She had been walking for a while before she came in the clinic");
            this.insert(4, 1, "patient_demographics", "I palapated her ® heel and there was point tenderness. Her ® gastrco-soleus complex were tight upon examination");
            this.insert(5, 2, "medical_history", "this is the first case study. It does not consist of anything");
        
        }

        public String[] types(){
            return _types.Distinct().ToArray<String>();
        }

        public void insert(int id, int parent_id, String type, String content)
        {
            _contents.Add(content);
            _types.Add(type);
            _ids.Add(id);
            _parent_ids.Add(parent_id);
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
                            
                            indexes.AddRange(search_in(_contents, search_term));

                        });

                    results = prepare_results(indexes.Distinct().ToList(), search_term);
                }
                else
                {
                    List<int> indexes = new List<int>();
                    List<int> i2 = search_in(_contents, search_term);
                   
                    
                    if (i2 != null)
                    { indexes.AddRange(i2); }
                   
                    results = prepare_results(indexes.Distinct().ToList(), search_term);
                }
            }
            catch
            {
                return new List<Searchable>();
            }
            
            return results;
        }

        public List<Searchable> find_by_parent_id(int id)
        {
            List<Searchable> results = new List<Searchable>();

            List<int> indexes = new List<int>();

            indexes = search_in_int(_parent_ids, id);
            results = assemble_searcable_list(indexes);
            
            return results;
        }

              
        private List<Searchable> prepare_results(List<int> indexes, String search_term)
        {
           
            List<int> parents = new List<int>();
            List<int> elements_with_unique_parents = new List<int>();
            foreach (int el in indexes)
            {
                int id = _ids[el];
                int parent_id = _parent_ids[el];
 
                if(!parents.Contains(parent_id))
                {
                    parents.Add(parent_id);
                    elements_with_unique_parents.Add(id);
                }
            }
            
            
            return assemble_searcable_list(elements_with_unique_parents);
        }


        private List<Searchable> assemble_searcable_list(List<int> elements)
        {
            List<Searchable> result = new List<Searchable>();

            foreach (int el in elements)
            {
                Searchable item = new Searchable();
                item.content = _contents[el];
                item.id = _ids[el];
                item.parent_id = _parent_ids[el];
                item.type = _types[el];
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

        private List<int> search_in_int(List<int> where, int what)
        {
            List<int> result = new List<int>();
            int count = 0;
            foreach (int element in where)
            {
                if (element == what)
                {
                    result.Add(count);
                }
                count++;
            }
            return result;

        }






    }
}