using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
    public class ImageneProcesoVentaViewModel
    {
        public int impr_Id { get; set; }
        public int btrp_Id { get; set; }
        public string impr_Imagen { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime impr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime impr_FechaModificacion { get; set; }
        [NotMapped]
        public string dobt_DescipcionDocumento { get; set; }
        [NotMapped]
        public int? dobt_Id { get; set; }
        [NotMapped]
        public int? dobt_Terreno_O_BienRaizId { get; set; }
        [NotMapped]
        public bool? dobt_Terreno_O_BienRaizbit { get; set; }
        [NotMapped]
        public string dobt_Imagen { get; set; }
        [NotMapped]
        public int tido_Id { get; set; }
        [NotMapped]
        public string tido_Descripcion { get; set; }

        [NotMapped]
        public string codigo { get; set; }
    }
}
