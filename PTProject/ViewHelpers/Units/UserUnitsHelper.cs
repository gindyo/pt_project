using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Text;
using PTProject.Models;

namespace PTProject.ViewHelpers
{
    public class UserUnitsHelper
    {
        private MembershipUser _user;

        public UserUnitsHelper(MembershipUser user)
        {
            _user = user;
        }

        public MvcHtmlString user_units_links()
        {
            string user_id = _user.ProviderUserKey.ToString();
            List<Unit> user_units = new List<Unit>();
            using (PT_DB db = new PT_DB())
            {
                user_units = db.Units.Where(u => u.usersId == user_id ).ToList<Unit>();
            }

            StringBuilder links_str = new StringBuilder();
            foreach (Unit u in user_units)
            {
                TagBuilder link = new TagBuilder("a");
                link.Attributes["href"] = "/unit/editcontent/" + u.Id.ToString();
                link.SetInnerText(u.title);
                links_str.Append(link).Append(new TagBuilder("br"));
            }
            return new MvcHtmlString(links_str.ToString());

        }

        


    }
}