using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class EquipoSeguridadPorProveedorViewModel
    {
        public int eqpp_Id { get; set; }
        public int? equs_Id { get; set; }
        public int? prov_Id { get; set; }
        public decimal eqpp_PrecioCompra { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime eqpp_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? eqpp_FechaModificacion { get; set; }

        [NotMapped]
        public string equs_Nombre { get; set; }
        [NotMapped]
        public string equs_Descripcion { get; set; }
        [NotMapped]
        public string prov_Descripcion { get; set; }
        [NotMapped]
        public int eqbo_Stock { get; set; }
    }
}
