using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Models;

namespace PTProject.Tests.Models
{
    class UserFactory
    {
        
        public static User create(string _first_name = "dimitar", string _last_name = "ginev" , string _email = "gindio@gmial.com", string _password = "", string _alt_id = "z000", string _username = "gindio", string _type = "super" )
        {
            using (var db = new PT_DB()){
                User new_u = new User(){first_name = _first_name, last_name = _last_name, email = _email, type = _type, password = _password, username = _username, alt_id = _alt_id};
                db.Users.AddObject(new_u);
                db.SaveChanges();

                return new_u;
            }
        }

        public static User build(string _first_name = "dimitar", string _last_name = "ginev", string _email = "gindio@gmial.com", string _password = "", string _alt_id = "z000", string _username = "gindio", string _type = "super")
        {
            using (var db = new PT_DB())
            {
                User new_u = new User() { first_name = _first_name, last_name = _last_name, email = _email, type = _type, password = _password, username = _username, alt_id = _alt_id };
                return new_u;
            }
        }

    }
}
