namespace MiSitioWeb.Data.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkExperienceDto
    {
        #region Properties
        public int WorkExperienceId { get; set; }
        public int UserId { get; set; }
        public string Organization { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }

        public int KeyId { get { return WorkExperienceId; } }
        public string SStartDate { get { return StartDate.ToString("yyyy-MM-dd"); } }
        public string SEndDate { get { return EndDate.ToString("yyyy-MM-dd"); } }
        public bool IsWork { get { return true; } }
        #endregion
    }
}
