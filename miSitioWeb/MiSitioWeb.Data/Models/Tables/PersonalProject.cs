namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PersonalProject
    {
        #region Properties
        [Key]
        public int PersonalProjectId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Proyecto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(70, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Project { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string Description { get; set; }

        [Display(Name = "Fecha de Publicación")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "URL Google Play Store")]
        public string PlayStoreURL { get; set; }

        [Display(Name = "URL Apple AppStore")]
        public string AppStoreURL { get; set; }

        [Display(Name = "URL Microsoft Store")]
        public string WinStoreURL { get; set; }

        [Display(Name = "URL Sitio Web")]
        public string SiteURL { get; set; }

        [Display(Name = "Eliminado")]
        [Required(ErrorMessage = "The field {0} is requiered.")]

        public bool Deleted { get; set; }
        #endregion

        #region Constructors
        public PersonalProject()
        {
            Deleted = false;
        }

        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion
    }
}
