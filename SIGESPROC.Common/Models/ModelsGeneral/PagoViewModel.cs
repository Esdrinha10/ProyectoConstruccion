using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class PagoViewModel
    {
        public int pago_Id { get; set; }
        public decimal pago_Monto { get; set; }
        public DateTime pago_Fecha { get; set; }
        public int clie_Id { get; set; }
        public int proy_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? pago_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pago_FechaModificacion { get; set; }

        [NotMapped]
        public string cliente { get; set; }
        [NotMapped]
        public int row { get; set; }
    }
}
