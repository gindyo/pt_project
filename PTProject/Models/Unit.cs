using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace PTProject.Models{
    public partial class Unit
    {
        public static Unit find(int id)
        {
            using (var db = new PT_DB())
            {
                var query = (from p in db.Units
                             where p.Id == id
                             select p).FirstOrDefault();
                return (Unit)query;

            }
        }

         
      
    }
}