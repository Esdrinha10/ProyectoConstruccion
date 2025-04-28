using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class PlanillaDetalleViewModel
    {
        public int plde_Id { get; set; }
        public int plde_Frecuencia { get; set; }
        public decimal plde_SueldoBruto { get; set; }
        public decimal plde_TotalDeducciones { get; set; }
        public decimal plde_SueldoNeto { get; set; }
        public decimal plde_TotalPrestamos { get; set; }
        public int empl_Id { get; set; }
        public int plan_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime? plde_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? plde_FechaModificacion { get; set; }
    }
}
