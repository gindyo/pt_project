using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.AbstractClasses;
using PTProject.Interfaces;


namespace PTProject.Models
{
    public class User
    {
        public string first_name;
        public string last_name;
        public string email;
        public string type;

        public User()
        {
            type = this.GetType().Name;
        }

    }

    public class Searcher : User
    {
        private String _search_term { get; set; }

        private IStorage _storage { get; set; }

        private string[] _where_to_search { set; get; }

        List<Searchable>  _search_result;

        public Searcher(IStorage s, String[] where, String search_term)
        {
            this._storage = s;
            this._search_term = search_term;
            this._where_to_search = where;
        }
        
        public void search()
        {
            _search_result = this._storage.find(_where_to_search, _search_term);
        }
        
        
    }

    public class ContentCreator : User
    {

        public ContentCreator(List<Searchable> content_parts)
        {

        }
    }

    public class MessageSender : CaseStudyCreator
    {
        public MessageSender(){}
    }

    public class Commenter : MessageSender
    {
        String my_comment;

        public void comment_on(ICommentable comment_on_me, string comment)
        {
            my_comment = comment;
            comment_on_me.receive_comment(this);
        }
    }

    public class Reviewer : Commenter
    {
        IReviewable case_study;
        
        public void set_case_study(IReviewable cs)
        {
            case_study = cs;
        }

    }

    public class Instructor : Reviewer
    {

    }

    public class Super : Instructor
    {

    }

   
}