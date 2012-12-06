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

            TagBuilder table = new TagBuilder("table");
            TagBuilder tr0 = tr;
            TagBuilder th1 = th;
            TagBuilder th2 = th;
            TagBuilder th3 = th;
            th2.SetInnerText("Title");
            th3.SetInnerText("Type");
            tr0.InnerHtml = th1.ToString() + th2.ToString() + th3.ToString();
            table.InnerHtml = tr0.ToString();
            TagBuilder td1 = td;
            TagBuilder td2 =td;
            TagBuilder td3 = td;
            TagBuilder td4 = td;
            TagBuilder tr1 = tr;
            foreach (Unit s in user_units)
            {

                TagBuilder link = new TagBuilder("a");
                link.Attributes["href"] = "/unit/editcontent/" + s.Id.ToString();
                link.SetInnerText("Add Content");
                td1.InnerHtml = link.ToString();

                td2.SetInnerText(s.title);
                
                td3.SetInnerText(s.type);

                               
                tr1.InnerHtml = td1.ToString() + td2.ToString() + td3.ToString();
                table.InnerHtml += tr1.ToString();
            }
            return new MvcHtmlString(table.ToString());

        }

        private TagBuilder td{ get{ return new TagBuilder("td");}}
        private TagBuilder th{ get{ return new TagBuilder("th");}}
        private TagBuilder tr { get { return new TagBuilder("tr"); } }
       
        


    }
}