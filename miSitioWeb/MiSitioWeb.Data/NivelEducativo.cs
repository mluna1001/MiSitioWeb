namespace MiSitioWeb.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NivelEducativo
    {
        [Key]
        public int IdNivelEstudio { get; set; }

        [Display(Name = "Nivel de Estudios")]
        public string Nombre { get; set; }

    }
}
