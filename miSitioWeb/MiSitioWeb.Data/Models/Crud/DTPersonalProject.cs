namespace MiSitioWeb.Data.Models.Crud
{
    using Comun.Tool;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTPersonalProject
    {
        public static List<PersonalProject> GetList()
        {
            List<PersonalProject> list = new List<PersonalProject>();

            using (var db = new DataContext())
            {
                list = db.PersonalProject.ToList();
            }

            return list.To<List<PersonalProject>>();
        }

        public static bool Create(PersonalProject PersonalProject)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (PersonalProject.PersonalProjectId == 0)
                        db.Entry(PersonalProject).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(PersonalProject).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTPersonalProject.Create");
            }

            return bandera;
        }

        public static PersonalProject Find(int PersonalProjectId)
        {
            PersonalProject el = new PersonalProject();

            using (var db = new DataContext())
            {
                el = db.PersonalProject.Find(PersonalProjectId);
            }

            return el;
        }

        public static bool Delete(int PersonalProjectId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    PersonalProject el = db.PersonalProject.Find(PersonalProjectId);
                    el.Deleted = true;
                    db.Entry(el).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTPersonalProject.Delete");
            }

            return bandera;
        }
    }
}
