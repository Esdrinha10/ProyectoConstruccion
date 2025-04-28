using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
   public class EstadoProyectoViewModel
    {
        public int espr_Id { get; set; }
        public string espr_Descripcion { get; set; }
        public int? usua_Creacion { get; set; }
        [NotMapped]
        public string UsuaModificacion { get; set; }
        [NotMapped]
        public string UsuaCreacion { get; set; }
        public DateTime? espr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? espr_FechaModificacion { get; set; }
        public bool? espr_Estado { get; set; }
    }
}
