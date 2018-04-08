namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Education
    {
        #region Properties
        [Key]
        public int EducationId { get; set; }

        public int EducationLevelId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Escuela")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string School { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(40, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string State { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(40, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Town { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(40, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Country { get; set; }
        #endregion

        #region References
        [JsonIgnore]
        public virtual EducationLevel EducationLevel { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion

        #region Used References
        [JsonIgnore]
        public ICollection<ScholarshipProject> ScholarshipProjects { get; set; }
        #endregion
    }
}
