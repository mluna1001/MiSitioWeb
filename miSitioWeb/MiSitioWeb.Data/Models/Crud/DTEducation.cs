namespace MiSitioWeb.Data.Models.Crud
{
    using Comun.Tool;
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTEducation
    {
        public static List<EducationDto> GetList()
        {
            List<EducationDto> list = new List<EducationDto>();

            using (var db = new DataContext())
            {
                list = (from e in db.Education
                           join el in db.EducationLevel on e.EducationLevelId equals el.EducationLevelId
                           join u in db.User on e.UserId equals u.UserId
                           select new EducationDto
                           {
                               EducationId = e.EducationId,
                               EducationLevel = el.Description,
                               School = e.School,
                               StartDate = e.StartDate,
                               EndDate = e.EndDate,
                               State = e.State,
                               Town = e.Town,
                               Country = e.Country,
                           }).ToList();
            }
            return list;
        }

        public static bool Create(Education education)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (education.EducationId == 0)
                        db.Entry(education).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(education).State = System.Data.Entity.EntityState.Modified;

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

        public static Education Find(int EducationId)
        {
            Education el = new Education();

            using (var db = new DataContext())
            {
                el = db.Education.Find(EducationId);
            }

            return el;
        }

        public static bool Delete(int EducationId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    Education el = db.Education.Find(EducationId);
                    db.Education.Remove(el);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTEducation.Delete");
            }

            return bandera;
        }
    }
}
