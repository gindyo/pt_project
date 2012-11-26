using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTProject.Interfaces;

namespace PTProject.Models
{
    public class Intervention: IParent
    {
        public int id { get; set; }

        public string title { get; set; }

        public string type { get; set; }

        public List<Searchable> contents { get; set; }
    }
}