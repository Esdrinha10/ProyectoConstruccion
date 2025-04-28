using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class ViaticoDetViewModel
    {
        public int codigo { get; set; }

        public int vide_Id { get; set; }
        public string vide_Descripcion { get; set; }
        public string vide_ImagenFactura { get; set; }
        public decimal? vide_MontoGastado { get; set; }
        public int vien_Id { get; set; }
        public int cavi_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime vide_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? vide_FechaModificacion { get; set; }
        [NotMapped]
        public decimal vide_MontoReconocido { get; set; }
    }
}
