using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ArchivoAdjuntoViewModel
    {
        public int arch_Id { get; set; }
        public string arch_Nombre { get; set; }
        public string arch_Ruta { get; set; }
        public int? Proy_Id { get; set; }
        public int? inci_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime arch_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? arch_FechaModificacion { get; set; }
        public bool? arch_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }

        [NotMapped]

        public int Imge_Id { get; set; }
        [NotMapped]

        public string Imge_Imagen { get; set; }
        [NotMapped]

        public DateTime Imge_FechaCreacion { get; set; }
        [NotMapped]

        public DateTime? Imge_FechaModificacion { get; set; }
        [NotMapped]

        public bool? Imge_Estado { get; set; }
        [NotMapped]

        public int? adic_Id { get; set; }
    }
}
