using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class AbonosPorPrestamosViewModel
    {
        public int abpr_Id { get; set; }
        public int pres_Id { get; set; }
        public decimal abpr_MontoAbonado { get; set; }
        public bool abpr_DeducidoEnPlanilla { get; set; }
        public DateTime abpr_Fecha { get; set; }
        [NotMapped]
        public string fecha { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime abpr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? abpr_FechaModificacion { get; set; }
    }
}
