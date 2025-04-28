using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class PresupuestoPorTasaCambioViewModel
    {
        public int pptc_Id { get; set; }
        public int? pren_Id { get; set; }
        public int? taca_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? pptc_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pptc_FechaModificacion { get; set; }

    }
}
