namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Personal
    {
        #region Properties
        [Key]
        public int PersonalId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Acerca de")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string About { get; set; }
        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion
    }
}
