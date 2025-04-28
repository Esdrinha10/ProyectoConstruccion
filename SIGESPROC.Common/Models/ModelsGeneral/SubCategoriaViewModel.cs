using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class SubCategoriaViewModel
    {
        public int suca_Id { get; set; }
        public string suca_Descripcion { get; set; }
        public int cate_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime suca_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? suca_FechaModificacion { get; set; }
        public bool? suca_Estado { get; set; }

        [NotMapped]
        public string cate_Descripcion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }

        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
    }
}
