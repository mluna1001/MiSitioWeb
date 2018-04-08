namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SocialNetwork
    {
        #region Properties
        [Key]
        public int SocialId { get; set; }

        [Display(Name = "Red Social")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(30, ErrorMessage = "The field {0} only can containts a maxium of {1} characters length")]
        public string Description { get; set; }
        #endregion

        #region Used References
        [JsonIgnore]
        public ICollection<PersonalContact> PersonalContacts { get; set; } 
        #endregion
    }
}
