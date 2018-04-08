namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonalContact
    {
        #region Properties
        [Key]
        public int PersonalContactId { get; set; }

        public int SocialId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(200, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string DataContact { get; set; }
        #endregion

        #region References
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual SocialNetwork SocialNetwork { get; set; } 
        #endregion
    }
}
