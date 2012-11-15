using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.AbstractClasses;

namespace PTProject.Interfaces
{
    public interface IStorage
    {
         List<Searchable> find(String[] where, String search_term);
       
    }
}
