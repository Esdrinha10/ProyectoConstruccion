using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class InsumoPorProyectoDetalleViewModel
    {
        public int ippe_Id { get; set; }
        public int inpe_Id { get; set; }
        public int ippe_stock { get; set; }
        public bool ippe_EsCompra { get; set; }
        public DateTime ippe_Fecha { get; set; }
        public int ippe_CompraOBodega { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime ippe_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? ippe_FechaModificacion { get; set; }
        public bool? ippe_Estado { get; set; }
    }
}
