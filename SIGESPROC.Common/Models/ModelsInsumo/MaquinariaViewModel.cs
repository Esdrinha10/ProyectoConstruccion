using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class MaquinariaViewModel
    {
        
        public int? mapr_DiaHora { get; set; }
        public int maqu_Id { get; set; }
        public int coti_Id { get; set; }
        public DateTime? coti_Fecha { get; set; }
        public bool coti_Incluido { get; set; }
        public int empl_Id { get; set; }
        public bool coti_CompraDirecta { get; set; }
        public int prov_Id { get; set; }
        public decimal maqu_UltimoPrecioUnitario { get; set; }
        public string maqu_Descripcion { get; set; }
        public int nive_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime maqu_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? maqu_FechaModificacion { get; set; }
        public bool? maqu_Estado { get; set; }
    }
}
