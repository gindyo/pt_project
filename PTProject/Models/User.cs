using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PTProject.Models
{
    public partial class User
    {

        public static User find(int id)
        {
            using (var db = new PT_DB())
            {
                var query = (from p in db.Users
                             where p.Id == id
                             select p).FirstOrDefault();
                return (User)query;

            }
        }
    }
}