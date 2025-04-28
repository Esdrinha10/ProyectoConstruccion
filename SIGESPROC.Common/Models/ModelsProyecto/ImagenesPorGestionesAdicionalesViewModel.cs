using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ImagenesPorGestionesAdicionalesViewModel
    {
        public int Imge_Id { get; set; }
        public string Imge_Imagen { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime Imge_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? Imge_FechaModificacion { get; set; }
        public bool? Imge_Estado { get; set; }
        public int? adic_Id { get; set; }
    }
}
