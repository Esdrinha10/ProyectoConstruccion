using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class GestionRiesgoViewModel
    {
        public int geri_Id { get; set; }
        public string geri_Descripcion { get; set; }
        public string geri_Impacto { get; set; }
        public decimal geri_Probabilidad { get; set; }
        public string geri_Mitigacion { get; set; }
        public int proy_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime geri_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? geri_FechaModificacion { get; set; }
        public bool? geri_Estado { get; set; }

        [NotMapped]
        public string proy_Nombre { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int row { get; set; }
    }
}
