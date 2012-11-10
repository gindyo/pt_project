using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;
using PTProject.AbstractClasses;

namespace PTProject.Models
{
    public class CaseStudy : Searchable, ICommentable
    {

        public CaseStudy(){}
        public CaseStudy(String t, String c, String k)
        {
            this.title = t;
            this.content = c;
            this.keywords = k;

        }

        
        public void receive_comment(Commenter commenter)
        {
            throw new NotImplementedException();
        }
    }
}