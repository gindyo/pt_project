using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PTProject.ModelMetadata;


namespace PTProject.Models{
    
    [MetadataType(typeof(UnitMeta))]
    public partial class Unit
    {
           

        public static Unit find(int id)
        {
            var db = new PT_DB();
            var query = (from p in db.Units
                        where p.Id == id
                        select p).FirstOrDefault();
            return (Unit)query;

           
        }

        public static void insert(Unit unit)
        {
            using (var db = new PT_DB())
            {
                db.Units.AddObject(unit);
                db.SaveChanges();
            }
        }

        public void destroy()
        {
            using (var context = new PT_DB())
            {
                var query = (from s in context.Units
                             where s.Id == this.Id
                             select s).FirstOrDefault();

                context.Units.DeleteObject(query);
                context.SaveChanges();
            }
        }

         
      
    }
}