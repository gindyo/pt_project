using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Interfaces
{
    public interface ISearchable
    {
        int id { set; get; }
        String title { set; get; }
        String short_content();
        String link();
        String content { set; get; }
        String keywords { set; get; }
    }
}
