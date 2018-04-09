namespace MiSitioWeb.Data.Models.Crud
{
    using Tables;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Comun.Tool;

    public class DTScholarshipProject
    {
        public static List<ScholarshipProject> GetList(int EducationId)
        {
            List<ScholarshipProject> list = new List<ScholarshipProject>();

            using (var db = new DataContext())
            {
                list = db.ScholarshipProject.Where(s => s.EducationId == EducationId).ToList();
            }

            return list.To<List<ScholarshipProject>>();
        }

        public static bool Create(ScholarshipProject scholarshipProject)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (scholarshipProject.ProjectId == 0)
                        db.Entry(scholarshipProject).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(scholarshipProject).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTscholarshipProject.Create");
            }

            return bandera;
        }

        public static ScholarshipProject Find(int scholarshipProjectId)
        {
            ScholarshipProject el = new ScholarshipProject();

            using (var db = new DataContext())
            {
                el = db.ScholarshipProject.Find(scholarshipProjectId);
            }

            return el;
        }

        public static bool Delete(int scholarshipProjectId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    ScholarshipProject el = db.ScholarshipProject.Find(scholarshipProjectId);
                    db.ScholarshipProject.Remove(el);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTscholarshipProject.Delete");
            }

            return bandera;
        }
    }
}