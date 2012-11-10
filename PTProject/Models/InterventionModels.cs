using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;
using PTProject.AbstractClasses;

namespace PTProject.Models
{
    public class Intervention: Searchable
    {



        public string title { get; set; }

        public string link()
        {
            return "/interventions/details/" + id;
        }

        public string content { get; set; }

        public int id { get; set; }


        public string short_content()
        {
            throw new NotImplementedException();
        }


        public string keywords { get; set; }
    }
}