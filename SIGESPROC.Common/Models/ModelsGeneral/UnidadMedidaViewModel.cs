using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class UnidadMedidaViewModel
    {
        public int unme_Id { get; set; }
        public string unme_Nombre { get; set; }
        public string unme_Nomenclatura { get; set; }
        public string unme_Identificador { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? unme_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? unme_FechaModificacion { get; set; }
    }
}
