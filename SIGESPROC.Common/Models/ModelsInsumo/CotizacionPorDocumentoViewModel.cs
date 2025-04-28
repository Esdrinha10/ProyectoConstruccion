using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class CotizacionPorDocumentoViewModel
    {
        public int copd_Id { get; set; }
        public string copd_Documento { get; set; }

        public string copd_Descripcion { get; set; }
        public int coti_Id { get; set; }

        public int usua_Creacion { get; set; }
    }
}
