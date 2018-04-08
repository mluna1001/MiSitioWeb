namespace MiSitioWeb.Data
{
    using Models.Tables;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {
        #region Catalogs
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<SocialNetwork> SocialNetwork { get; set; }
        public DbSet<Page> Page { get; set; }
        #endregion

        #region Tables
        public DbSet<User> User { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<ScholarshipProject> ScholarshipProject { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<WorkProject> WorkProject { get; set; }
        public DbSet<PersonalProject> PersonalProject { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<PersonalContact> PersonalContact { get; set; }
        public DbSet<Photo> Photo { get; set; }
        #endregion

        public DataContext() : base("DefaultConnection")
        {
            
        }

        #region Events
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 
        #endregion
    }
}
