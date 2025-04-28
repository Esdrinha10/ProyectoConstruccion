using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
 public   class ProyectoConstruccionBienRaizViewModel
    {

        public int pcon_Id { get; set; }
        public int terr_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime pcon_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pcon_FechaModificacion { get; set; }
        public bool? pcon_Estado { get; set; }
        public int proy_Id { get; set; }
        [NotMapped]
        public string Proy_Descripcion { get; set; }
        [NotMapped]
        public string Proy_DireccionExacta { get; set; }
        [NotMapped]
        public string terr_Descripcion { get; set; }
        [NotMapped]
        public string terr_Direccion { get; set; }
    }
}
