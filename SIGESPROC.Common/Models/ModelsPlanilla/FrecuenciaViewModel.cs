using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class FrecuenciaViewModel
    {
        [NotMapped]
        public int codigo { get; set; }
        public int frec_Id { get; set; }
        public string frec_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime frec_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? frec_FechaModificacion { get; set; }
        public bool? frec_Estado { get; set; }
        public string frec_NumeroDias { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
    }
}
