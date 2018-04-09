namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ScholarshipProject
    {
        #region Properties
        [Key]
        public int ProjectId { get; set; }

        public int EducationId { get; set; }

        [Display(Name = "Proyecto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Project { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string Description { get; set; }

        [NotMapped]
        public int KeyId { get { return ProjectId; } }
        #endregion

        #region References
        [JsonIgnore]
        public virtual Education Education { get; set; } 
        #endregion
    }
}
