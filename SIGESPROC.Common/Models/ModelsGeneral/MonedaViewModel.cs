using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class MonedaViewModel
    {
        //NOTMAPPED
        [NotMapped]
        public int codigo { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }

        [NotMapped]
        public string usuaModificacion { get; set; }

        [NotMapped]
        public string pais_Nombre { get; set; }

        //END NOTMAPPED
        public int mone_Id { get; set; }
        public string mone_Nombre { get; set; }
        public int pais_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime mone_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? mone_FechaModificacion { get; set; }
        public bool? mone_Estado { get; set; }
        public string mone_Abreviatura { get; set; }
    }
}
