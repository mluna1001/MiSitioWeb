namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        #region Properties
        [Key]
        public int SkillId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Aptitud")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string SkillName { get; set; }
        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion
    }
}
