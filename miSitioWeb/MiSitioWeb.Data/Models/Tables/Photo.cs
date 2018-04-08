namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Photo
    {
        #region Properties
        [Key]
        public int PhotoId { get; set; }

        public int UserId { get; set; }

        public int PageId { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string PhotoURL { get; set; } 
        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Page Page { get; set; } 
        #endregion
    }
}
