using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
   public class TipoDocumentoViewModel
    {
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string codigo { get; set; }

        public int tido_Id { get; set; }
        public string tido_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime tido_FechaCreacion { get; set; }
        public int? usua_Mofificacion { get; set; }
        public DateTime? tido_FechaModificacion { get; set; }
        public bool? tido_Estado { get; set; }
    }
}
