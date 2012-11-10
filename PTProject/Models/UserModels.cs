using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        String searchTerm;
        ISearchable[]  search_result;
        
        
    }

    public class CaseStudyCreator : Searcher
    {
    }

    public class MessageSender : CaseStudyCreator
    {

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