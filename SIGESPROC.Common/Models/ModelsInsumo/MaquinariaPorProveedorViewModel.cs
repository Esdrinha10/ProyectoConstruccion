using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class MaquinariaPorProveedorViewModel
    {
        public int mapr_Id { get; set; }
        public decimal? mapr_PrecioCompra { get; set; }
        public int maqu_Id { get; set; }
        public int prov_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime mapr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? mapr_FechaModificacion { get; set; }

        [NotMapped]
        public int nive_Id { get; set; }
        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string maqu_Descripcion { get; set; }
        [NotMapped]
        public string estado { get; set; }
        [NotMapped]
        public string renta { get; set; }
        [NotMapped]
        public string nive_Descripcion { get; set; }
        [NotMapped]
        public string prove_Descripcion { get; set; }

    }
}
