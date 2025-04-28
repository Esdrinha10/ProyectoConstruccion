using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class MaterialViewModel
    {
        public int mate_Id { get; set; }
        public string mate_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime mate_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? mate_FechaModificacion { get; set; }
        public bool? mate_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int row { get; set; }
    }
}
