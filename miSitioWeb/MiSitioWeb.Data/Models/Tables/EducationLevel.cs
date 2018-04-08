namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EducationLevel
    {
        #region Properties
        [Key]
        public int EducationLevelId { get; set; }

        [Display(Name = "Nivel de Estudios")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(30, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Description { get; set; }

        [NotMapped]
        public int KeyId { get { return EducationLevelId; } }
        #endregion

        #region Used References
        [JsonIgnore]
        public ICollection<Education> Educations { get; set; } 
        #endregion
    }
}
