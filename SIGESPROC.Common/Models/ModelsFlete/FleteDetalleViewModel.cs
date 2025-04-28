using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGESPROC.Common.Models.ModelsFlete
{
    public class FleteDetalleViewModel
    {
        [NotMapped]
        public int codigo { get; set; }
        public int flde_Id { get; set; }
        public int flde_Cantidad { get; set; }
        public int flen_Id { get; set; }
        public int usua_Creacion { get; set; }
        public bool? flde_llegada { get; set; }
        public DateTime flde_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? flde_FechaModificacion { get; set; }
        [NotMapped]
        public string inpp_Observacion { get; set; }
        [NotMapped]
        public string bode_Descripcion { get; set; }
        [NotMapped]
        public int bode_Id { get; set; }
        [NotMapped]
        public int bopi_Stock { get; set; }
        public int inpp_Id { get; set; }
        [NotMapped]
        public string prov_Descripcion { get; set; }
        [NotMapped]
        public string insu_Descripcion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }

        [NotMapped]
        public bool flde_TipodeCarga { get; set; }







        [NotMapped]
        public string mate_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nombre { get; set; }
        [NotMapped]
        public int unme_Id { get; set; }

        [NotMapped]
        public string unme_Nomenclatura { get; set; }
        [NotMapped]
        public string equs_Nombre { get; set; }
        [NotMapped]
        public string equs_Descripcion { get; set; }


        [NotMapped]

        public int? proy_Id { get; set; }
        [NotMapped]
        public string? proy_Nombre { get; set; }
        [NotMapped]
        public string? proy_Descripcion { get; set; }
        [NotMapped]

        public int? etpr_Id { get; set; }
        [NotMapped]
        public string? etap_Descripcion { get; set; }
        [NotMapped]

        public int? acti_Id { get; set; }
        [NotMapped]
        public string? acti_Descripcion { get; set; }
        [NotMapped]
        public string? insu_Observacion { get; set; }
        [NotMapped]
        public int? mate_Id { get; set; }


        [NotMapped]
        public string flen_ComprobanteLLegada { get; set; }

    }
}
