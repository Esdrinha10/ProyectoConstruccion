using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class BancoViewModel
    {
        public int banc_Id { get; set; }
        public string banc_Descripcion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime banc_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        public DateTime? banc_FechaModificacion { get; set; }
    }
}
