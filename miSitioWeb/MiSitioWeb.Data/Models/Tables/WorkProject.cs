namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WorkProject
    {
        #region Properties
        [Key]
        public int WorkProyectId { get; set; }

        public int WorkExperienceId { get; set; }

        [Display(Name = "Proyecto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(300, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Project { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string Description { get; set; }

        [NotMapped]
        public int KeyId { get { return WorkProyectId; } }
        #endregion

        #region References
        [JsonIgnore]
        public virtual WorkExperience WorkExperience { get; set; }
        #endregion
    }
}