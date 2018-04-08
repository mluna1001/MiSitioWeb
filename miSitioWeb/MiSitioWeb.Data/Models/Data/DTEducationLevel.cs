namespace MiSitioWeb.Data.Models.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTEducationLevel
    {
        public static List<EducationLevel> GetEducationLevels()
        {
            using (var db = new DataContext())
            {
                return db.EducationLevel.ToList();
            }
        }
    }
}
