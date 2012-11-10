using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;

namespace PTProject.AbstractClasses
{
    public abstract class Searchable 
    {
        public string title { get; set; }

        public string content { get; set; }

        public string keywords { get; set; }

        public string id { get; set; }

        public string link { get; set; }

        public static bool operator !=(Searchable subject, Searchable compare_to)
        {
            return (subject.id != compare_to.id);
        }

        public static bool operator ==(Searchable subject, Searchable compare_to)
        {
            return (subject.id == compare_to.id);
        }

        
        }
}