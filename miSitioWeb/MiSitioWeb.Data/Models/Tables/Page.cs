namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Page
    {
        #region Properties
        [Key]
        public int PageId { get; set; }

        [Display(Name = "Página")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(30, ErrorMessage = "The field {0} only can contains a maxium of {1} characters length")]
        public string PageName { get; set; }

        [Display(Name = "URL de Página")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} only can contains a maxium of {1} characters length")]
        public string PageURL { get; set; }

        [Display(Name = "Target")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(10, ErrorMessage = "The field {0} only can contains a maxium of {1} characters length")]
        public string Target { get; set; }

        [Display(Name = "Orden")]
        [Required(ErrorMessage = "The field {0} is required")]
        public byte Order { get; set; } 
        #endregion

        #region Used References
        [JsonIgnore]
        public ICollection<Photo> Photos { get; set; }
        #endregion
    }
}
