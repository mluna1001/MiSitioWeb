namespace MiSitioWeb.Data.Models.Tables
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        #region Properties
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(35, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string LastName { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(35, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string MiddleName { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(35, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string FirstName { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public byte Age { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(10, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string UserName { get; set; }

        [NotMapped]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public string RealPassword { get; set; }

        [Required(ErrorMessage = "The field {0} is requiered.")]
        public byte[] Password { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string Email { get; set; }

        [NotMapped]
        public byte[] PhotoArray { get; set; }

        [Display(Name = "Foto")]
        public string PhotoURL { get; set; }

        [Display(Name = "Foto")]
        public string PhotoFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(PhotoURL))
                {
                    return "noimage";
                }

                return string.Format($"http://localhost/{PhotoURL.Substring(1)}");
            }
        }

        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName + " " + MiddleName;
            }
        }
        #endregion

        #region Used References
        [JsonIgnore]
        public ICollection<Education> Educations { get; set; }
        [JsonIgnore]
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        [JsonIgnore]
        public ICollection<PersonalProject> PersonalProjects { get; set; }
        [JsonIgnore]
        public ICollection<Personal> Personals { get; set; }
        [JsonIgnore]
        public ICollection<Skill> Skills { get; set; }
        [JsonIgnore]
        public ICollection<PersonalContact> PersonalContacts { get; set; }
        [JsonIgnore]
        public ICollection<Photo> Photos { get; set; }
        #endregion

    }
}