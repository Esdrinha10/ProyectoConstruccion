using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class InsumoPorProveedorViewModel
    {
        public int inpp_Id { get; set; }
        public int? insu_Id { get; set; }
        public int? prov_Id { get; set; }
        public decimal? inpp_Preciocompra { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime inpp_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inpp_FechaModificacion { get; set; }
        
        [NotMapped]
        public string inpp_Observacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string mate_Descripcion { get; set; }
        [NotMapped]
        public string insu_Descripcion { get; set; }
        [NotMapped]
        public string prov_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nombre { get; set; }
        [NotMapped]
        public int unme_Id { get; set; }
        [NotMapped]
        public string suca_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nomenclatura { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int bode_Id { get; set; }
        [NotMapped]
        public string bode_Descripcion { get; set; }
        [NotMapped]
        public decimal bopi_Stock { get; set; }
        [NotMapped]
        public decimal inpa_Stock { get; set; }
    }
}
