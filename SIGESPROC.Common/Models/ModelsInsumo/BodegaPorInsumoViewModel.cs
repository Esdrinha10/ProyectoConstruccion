using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class BodegaPorInsumoViewModel
    {
        public int bopi_Id { get; set; }
        public int? inpp_Id { get; set; }
        public int? bode_Id { get; set; }
        public int? bopi_Stock { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? bopi_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? bopi_FechaModificacion { get; set; }
    }
}
