using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
 public  class CategoriaVaticoViewModel
    {
        public int cavi_Id { get; set; }
        public string cavi_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime cavi_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? cavi_FechaModificacion { get; set; }
        public bool? cavi_Estado { get; set; }

        [NotMapped]
        public string usuarioCreacion { get; set; }

        [NotMapped]
        public string usuarioModificacion { get; set; }

        [NotMapped]
        public string codigo { get; set; }
    }
}
