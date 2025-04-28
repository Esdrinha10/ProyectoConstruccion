using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ContratoViewModel
    {
        public int cont_Id { get; set; }
        public string cont_ImgenDescripcion { get; set; }
        public DateTime cont_Fecha { get; set; }
        public int Proy_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? cont_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? cont_FechaModificacion { get; set; }
        public bool? cont_Estado { get; set; }
    }
}
