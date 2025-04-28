using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class IncidenciasPorActividadesViewModel
    {
        public int inac_Id { get; set; }
        public int? acet_Id { get; set; }
        public int? inci_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? inac_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inac_FechaModificacion { get; set; }
        public bool? inac_Estado { get; set; }
    }
}
