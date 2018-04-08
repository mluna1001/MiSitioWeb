namespace MiSitioWeb.Data.Models.Crud
{
    using System;
    using Tables;

    public class DTErrorLog
    {
        public static void Add(Exception ex, string actionName)
        {
            using (var db = new DataContext())
            {
                ErrorLog el = new ErrorLog()
                {
                    ActionName = actionName,
                    ExceptionName = ex.ToString(),
                    Message = ex.Message,
                    UserId = 1,
                };

                db.ErrorLog.Add(el);
                db.SaveChanges();
            }
        }
    }
}
