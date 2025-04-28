using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class NivelViewModel
    {

        public int nive_Id { get; set; }
        public string nive_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime nive_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? nive_FechaModificacion { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
    }
}
