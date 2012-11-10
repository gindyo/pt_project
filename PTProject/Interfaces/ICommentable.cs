using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;

namespace PTProject.Interfaces
{
    public interface ICommentable
    {
        void receive_comment(Commenter commenter);


    }
}
