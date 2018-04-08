namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkExperience
    {
        #region Properties
        [Key]
        public int WorkExperienceId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Organización")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(70, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Organization { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string State { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Town { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Country { get; set; }

        [Display(Name = "Puesto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Job { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string Description { get; set; } 
        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion

        #region Used References
        public ICollection<WorkProject> WorkProjects { get; set; }
        #endregion
    }
}
