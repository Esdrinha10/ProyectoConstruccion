using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class PaisViewModel
    {
        public int pais_Id { get; set; }
        public string pais_Nombre { get; set; }
        public string pais_Codigo { get; set; }
        public string pais_Prefijo { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime pais_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pais_FechaModificacion { get; set; }
        [NotMapped]
        public string usuarioCreacion { get; set; }
        [NotMapped]
        public string usuarioModificacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
    }
}
