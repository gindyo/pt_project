using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PTProject.ModelMetadata;

namespace PTProject.Models
{
    [MetadataType(typeof(UserMeta))]
    public partial class User : IAccountRepository
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

        public bool IsValidLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool user_name_exists(string username)
        {
           using(PT_DB db = new PT_DB())
           {
               return db.Users.SingleOrDefault(u => u.username == username) == null ? false : true;
           }
            
        }

        public bool email_exists(string username)
        {
            using (PT_DB db = new PT_DB())
            {
                return db.Users.SingleOrDefault(u => u.email == email) == null ? false : true;
            }
        }
        public void destroy()
        {
            using (var context = new PT_DB())
            {
                var query = (from s in context.Users
                             where s.Id == this.Id
                             select s).FirstOrDefault();

                context.Users.DeleteObject(query);
                context.SaveChanges();
            }
        }

        
    }
}