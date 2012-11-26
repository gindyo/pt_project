using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;

namespace PTProject.Interfaces
{
    public interface IParent
    {
         int id { set; get; }
         String title { set; get; }
         String type { set; get; }
         List<Searchable> contents { set; get; }
    }
}
