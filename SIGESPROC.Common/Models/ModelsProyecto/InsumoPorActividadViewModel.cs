using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class InsumoPorActividadViewModel
    {
        public int inpa_Id { get; set; }
        public int acet_Id { get; set; }
        public int inpa_stock { get; set; }
        public decimal inpa_PrecioCompra { get; set; }
        public int inpa_Desperdicio { get; set; }

        public decimal inpa_Rendimiento { get; set; }
        public string? inpa_FormulaRendimiento { get; set; }
        public string? inpa_StockFormula { get; set; }
        
        public string? inpa_PrecioCompraFormula { get; set; }

        public int? inpa_ActividadLlenado { get; set; }

        public bool inpa_EsCompra { get; set; }
        public DateTime inpa_Fecha { get; set; }
        public int inpp_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime inpa_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inpa_FechaModificacion { get; set; }
        public bool? inpa_Estado { get; set; }

        [NotMapped]
        public int row { get; set; }
        [NotMapped]
        public string insu_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nombre { get; set; }
        [NotMapped]
        public string unme_Nomenclatura { get; set; }
        [NotMapped]
        public int bopi_Stock { get; set; }
        [NotMapped]
        public string mate_Descripcion { get; set; }
        [NotMapped]
        public string prov_Descripcion { get; set; }
        [NotMapped]
        public string suca_Descripcion { get; set; }
        [NotMapped]
        public string cate_Descripcion { get; set; }
        [NotMapped]
        public string inpp_Observacion { get; set; }
        [NotMapped]
        public decimal inpp_Preciocompra { get; set; }
    }
}
