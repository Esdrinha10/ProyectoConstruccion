using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class ActividadesViewModel
    {
        public int acti_Id { get; set; }
        public string acti_Descripcion { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? acti_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? acti_FechaModificacion { get; set; }
        public bool? acti_Estado { get; set; }

        public string usuaCreacion { get; set; }
        public string usuaModificacion { get; set; }
    }
}
