using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class InsumoViewModel
    {
        public int insu_Id { get; set; }
     
        public int prov_Id { get; set; }
    
        public decimal? inpp_Preciocompra { get; set; }
        public int suca_Id { get; set; }
        public int unme_Id { get; set; }

        public int coti_Id { get; set; }
        public DateTime? coti_Fecha { get; set; }
        public bool coti_Incluido { get; set; }
        public int empl_Id { get; set; }
        public bool coti_CompraDirecta { get; set; }
        public string insu_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nombre { get; set; }
        [NotMapped]
        public string mate_Descripcion { get; set; }
        [NotMapped]
        public string cate_Descripcion { get; set; }
        [NotMapped]
        public string suca_Descripcion { get; set; }
        public string insu_Observacion { get; set; }

        public string inpp_Observacion { get; set; }
        public int mate_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime insu_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? insu_FechaModificacion { get; set; }
        public bool? insu_Estado { get; set; }
        public decimal? insu_UltimoPrecioUnitario { get; set; }


        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }


        [NotMapped]
        public int cate_Id { get; set; }
    }
}
