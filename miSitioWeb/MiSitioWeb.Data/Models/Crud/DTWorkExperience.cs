namespace MiSitioWeb.Data.Models.Crud
{
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTWorkExperience
    {
        public static List<WorkExperienceDto> GetList()
        {
            List<WorkExperienceDto> list = new List<WorkExperienceDto>();

            using (var db = new DataContext())
            {
                list = (from e in db.WorkExperience
                        join u in db.User on e.UserId equals u.UserId
                        select new WorkExperienceDto
                        {
                            WorkExperienceId = e.WorkExperienceId,
                            Organization = e.Organization,
                            Job = e.Job,
                            Description = e.Description,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate,
                            State = e.State,
                            Town = e.Town,
                            Country = e.Country,
                        }).ToList();
            }
            return list;
        }

        public static bool Create(WorkExperience workExperience)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (workExperience.WorkExperienceId == 0)
                        db.Entry(workExperience).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(workExperience).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTEducation.Create");
            }

            return bandera;
        }

        public static WorkExperience Find(int WorkExperienceId)
        {
            WorkExperience we = new WorkExperience();

            using (var db = new DataContext())
            {
                we = db.WorkExperience.Find(WorkExperienceId);
            }

            return we;
        }

        public static bool Delete(int WorkExperienceId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    WorkExperience we = db.WorkExperience.Find(WorkExperienceId);
                    db.WorkExperience.Remove(we);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTWorkExperience.Delete");
            }

            return bandera;
        }
    }
}
