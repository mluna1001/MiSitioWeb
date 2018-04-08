namespace MiSitioWeb.Data.Models.Crud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tables;

    public class DTSocialNetwork
    {
        public static List<SocialNetwork> GetList()
        {
            using (var db = new DataContext())
            {
                return db.SocialNetwork.ToList();
            }
        }

        public static bool Create(SocialNetwork socialNetwork)
        {
            bool bandera = false;
            try
            {
                using (var db = new DataContext())
                {
                    if (socialNetwork.SocialId == 0)
                        db.Entry(socialNetwork).State = System.Data.Entity.EntityState.Added;
                    else
                        db.Entry(socialNetwork).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTSocialNetwork.Create");
            }

            return bandera;
        }

        public static SocialNetwork Find(int SocialNetworkId)
        {
            SocialNetwork el = new SocialNetwork();

            using (var db = new DataContext())
            {
                el = db.SocialNetwork.Find(SocialNetworkId);
            }

            return el;
        }

        public static bool Delete(int SocialNetworkId)
        {
            bool bandera = false;

            try
            {
                using (var db = new DataContext())
                {
                    SocialNetwork el = db.SocialNetwork.Find(SocialNetworkId);
                    db.SocialNetwork.Remove(el);
                    db.SaveChanges();
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                DTErrorLog.Add(ex, "DTSocialNetwork.Delete");
            }

            return bandera;
        }
    }
}
