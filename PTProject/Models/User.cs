using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PTProject.Models
{
    public partial class User
    {
        

        public enum Roles { Super = 100, Admin = 90, ContentCreator = 80, Normal = 70 }
        
        public static User find(int id)
        {
            return new PT_DB().Users.Single<User>(u => u.Id == id);
        }

        public static User find(String username)
        {
            return new PT_DB().Users.Single<User>(u => u.username == username);
        }

        public static void insert(User user){
            var db = new PT_DB();
            user.password = Security.PasswordHash.CreateHash(user.password);
            db.Users.AddObject(user);
            db.SaveChanges();

        }
    }
}