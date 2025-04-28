using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class InsumoPorProyectoEncabezadoViewModel
    {
        public int inpe_Id { get; set; }
        public int proy_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime inpe_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inpe_FechaModificacion { get; set; }
        public bool? inpe_Estado { get; set; }
    }
}
