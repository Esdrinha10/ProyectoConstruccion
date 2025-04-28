using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class PlanillaViewModel
    {
        public int plan_Id { get; set; }
        public int plan_NumNomina { get; set; }
        public string plan_FechaPago { get; set; }
        public string plan_FechaPeriodoFin { get; set; }
        public string plan_Observaciones { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime plan_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? plan_FechaModificacion { get; set; }
        public int? frec_Id { get; set; }
        public bool? plan_PlanillaJefes { get; set; }

        // [NotMapped] se puede dejar si no se usan en la base de datos
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
    }
}
