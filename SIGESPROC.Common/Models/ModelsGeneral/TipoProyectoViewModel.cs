using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class TipoProyectoViewModel
    {
        public int tipr_Id { get; set; }
        public string tipr_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime tipr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? tipr_FechaModificacion { get; set; }
        public bool? tipr_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int row { get; set; }
    }
}
