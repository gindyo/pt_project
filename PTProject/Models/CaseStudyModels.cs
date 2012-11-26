using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;

namespace PTProject.Models
{
    public class CaseStudy : IParent, ICommentable
    {
        public List<Searchable> _components {private set; get; }

              
        public void receive_comment(Commenter commenter)
        {
            throw new NotImplementedException();
        }

        public int id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string title
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string type
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Searchable> contents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}