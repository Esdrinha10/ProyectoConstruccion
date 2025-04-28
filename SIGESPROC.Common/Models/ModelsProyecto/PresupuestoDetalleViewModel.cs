using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class PresupuestoDetalleViewModel
    {
        public int pdet_Id { get; set; }
        public int? pdet_Cantidad { get; set; }
        public decimal? pdet_PrecioManoObra { get; set; }
        public decimal? pdet_PrecioMateriales { get; set; }
        public decimal? pdet_PrecioMaquinaria { get; set; }
        public string pdet_MaquinariaFormula { get; set; }
        public string pdet_MaterialFormula { get; set; }
        public string pdet_ManoObraFormula { get; set; }
        public string pdet_CantidadFormula { get; set; }

        public int? unme_Id { get; set; }
        public int? pren_Id { get; set; }
        public int? acet_Id { get; set; }
        public bool? pdet_Incluido { get; set; }
       public int? pdet_Ganancia { get; set; }

        public int? acti_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? pdet_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pdet_FechaModificacion { get; set; }
    }
}
