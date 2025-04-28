using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class EquipoSeguridadPorActividadViewModel
    {
        public int eqac_Id { get; set; }
        public int eqpp_Id { get; set; }
        public decimal eqac_Costo { get; set; }
        public int eqac_Cantidad { get; set; }
        public int? equs_Id { get; set; }
        public int acet_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? eqac_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? eqac_FechaModificacion { get; set; }
        public bool? eqac_Estado { get; set; }
    }
}
