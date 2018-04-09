namespace MiSitioWeb.Data.Models.DTO
{
    using Newtonsoft.Json;
    using System;

    public class EducationDto
    {
        #region Properties
        public int EducationId { get; set; }
        public string EducationLevel { get; set; }
        public string School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }

        public int KeyId { get { return EducationId; } }
        public string Description { get { return School; } }
        public string SStartDate { get { return StartDate.ToShortDateString(); } }
        public string SEndDate { get { return EndDate.ToShortDateString(); } }
        public bool IsEducation { get { return true; } }
        #endregion
    }
}
