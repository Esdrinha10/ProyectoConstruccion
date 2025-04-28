using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class RetrasoViewModel
    {
        public int retr_Id { get; set; }
        public string retr_Descripcion { get; set; }
        public decimal retr_Monto { get; set; }
        public DateTime retr_Fecha { get; set; }
        public int? Proy_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime retr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? retr_FechaModificacion { get; set; }
    }
}
