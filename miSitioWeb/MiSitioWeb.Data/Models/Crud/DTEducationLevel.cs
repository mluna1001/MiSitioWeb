namespace MiSitioWeb.Data.Models.Crud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTEducationLevel
    {
        public static List<EducationLevel> GetList()
        {
            using (var db = new DataContext())
            {
                return db.EducationLevel.ToList();
            }
        }

        public static bool Create(EducationLevel educationLevel)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (educationLevel.EducationLevelId == 0)
                        db.Entry(educationLevel).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(educationLevel).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTEducationLevel.Create");
            }

            return bandera;
        }

        public static EducationLevel Find(int educationLevelId)
        {
            EducationLevel el = new EducationLevel();

            using (var db = new DataContext())
            {
                el = db.EducationLevel.Find(educationLevelId);
            }

            return el;
        }

        public static bool Delete(int educationLevelId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    EducationLevel el = db.EducationLevel.Find(educationLevelId);
                    db.EducationLevel.Remove(el);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTEducationLevel.Delete");
            }

            return bandera;
        }
    }
}
