using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ContratoEmpleadoViewModel
    {
        public int coem_Id { get; set; }
        public string coem_Descripcion { get; set; }
        public int empl_Id { get; set; }
        public int proy_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? coem_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? coem_FechaModificacion { get; set; }
        public bool? coem_Estado { get; set; }
    }
}
