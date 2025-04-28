using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class RentaMaquinariaPorActividadViewModel
    {
        public int rmac_Id { get; set; }
        public DateTime? rmac_FechaContratacion { get; set; }
        public int? rmac_Rentapor { get; set; }
        public int? rmac_CantidadRenta { get; set; }
        public decimal? rmac_PrecioRenta { get; set; }
        public int? rmac_CantidadMaquinas { get; set; }
        public int? mapr_Id { get; set; }
        public int? acet_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public int? rmac_ActividadLlenado { get; set; }

        public DateTime rmac_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public string? rmac_CantidadMaquinaFormula { get; set; }
        public string? rmac_PrecioRentaFormula { get; set; }
        public string? rmac_CantidadRentaFormula { get; set; }
        public DateTime? rmac_FechaModificacion { get; set; }

        public bool rmac_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }


        public int rmac_HorasRenta { get; set; }
    }
}
