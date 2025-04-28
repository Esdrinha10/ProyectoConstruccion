using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsFlete
{
    public class IncidenciaPorFleteViewModel
    {
        public int infl_Id { get; set; }
        public int inci_Id { get; set; }
        public int flen_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime infl_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? infl_FechaModificacion { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        
    }
}
