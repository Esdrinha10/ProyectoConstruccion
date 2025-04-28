using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
   public class EtapaViewModel
    {
        public int etap_Id { get; set; }
        public string etap_Descripcion { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? etap_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? etap_FechaModificacion { get; set; }
        public bool? etap_Estado { get; set; }
    }
}
