namespace MiSitioWeb.Data.Models.Crud
{
    using Comun.Tool;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTWorkProject
    {
        public static List<WorkProject> GetList(int WorkExperienceId)
        {
            List<WorkProject> list = new List<WorkProject>();

            using (var db = new DataContext())
            {
                list = db.WorkProject.Where(s => s.WorkExperienceId == WorkExperienceId).ToList();
            }

            return list.To<List<WorkProject>>();
        }

        public static bool Create(WorkProject workProject)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (workProject.WorkProyectId == 0)
                        db.Entry(workProject).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(workProject).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTWorkProject.Create");
            }

            return bandera;
        }

        public static WorkProject Find(int WorkProjectId)
        {
            WorkProject wp = new WorkProject();

            using (var db = new DataContext())
            {
                wp = db.WorkProject.Find(WorkProjectId);
            }

            return wp;
        }

        public static bool Delete(int WorkProjectId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    WorkProject wp = db.WorkProject.Find(WorkProjectId);
                    db.WorkProject.Remove(wp);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTWorkProject.Delete");
            }

            return bandera;
        }
    }
}
