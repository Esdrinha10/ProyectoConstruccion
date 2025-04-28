using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
   public class CategoriaViewModel
    {
        public int cate_Id { get; set; }
        public string cate_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime cate_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? cate_FechaModificacion { get; set; }
        public bool? cate_Estado { get; set; }

        [NotMapped]
        public string usuarioCreacion { get; set; }

        [NotMapped]
        public string usuarioModificacion { get; set; }

        [NotMapped]
        public string codigo { get; set; }
    }
}
