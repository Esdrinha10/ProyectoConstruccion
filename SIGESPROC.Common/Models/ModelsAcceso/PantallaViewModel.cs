using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsAcceso
{
    public class PantallaViewModel
    {
        public int pant_Id { get; set; }
        public string pant_Descripcion { get; set; }
        public string pant_direccionURL { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime pant_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pant_FechaModificiacion { get; set; }
        public bool? pant_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
    }
}
