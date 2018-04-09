namespace MiSitioWeb.Data.Models.Crud
{
    using Tables;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MiSitioWeb.Data.Models.Helpers;

    public class DTUser
    {
        public static User Login(string user, string password)
        {
            User userObj = new User();
            byte[] pwd = PasswordSecurity.Encript(password);

            try
            {
                using (var db = new DataContext())
                {
                    userObj = db.User.FirstOrDefault(u => u.UserName == user && u.Password == pwd);
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTUser.Login");
            }

            return userObj;
        }

        public static bool CreateUser(User user)
        {
            bool bandera = false;
            int age = DateTime.Now.Year - user.BirthDate.Year;
            user.Age = byte.Parse(age.ToString());

            try
            {
                using (var db = new DataContext())
                {
                    user.Password = PasswordSecurity.Encript(user.RealPassword);
                    db.User.Add(user);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTUser.CreateUser");
            }

            return bandera;
        }
    }
}
