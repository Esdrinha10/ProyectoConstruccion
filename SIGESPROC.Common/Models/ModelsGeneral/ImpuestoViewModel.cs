using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class ImpuestoViewModel
    {
        public int impu_Id { get; set; }
        public decimal impu_Porcentaje { get; set; }

        public int? usua_Modificacion { get; set; }
        public DateTime? impu_FechaModificacion { get; set; }

    }
}
