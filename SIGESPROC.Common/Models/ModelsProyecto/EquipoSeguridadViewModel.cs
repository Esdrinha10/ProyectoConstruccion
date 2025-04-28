using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
   public class EquipoSeguridadViewModel
    {
        public int equs_Id { get; set; }
        public string equs_Nombre { get; set; }

      
        public string equs_Descripcion { get; set; }
        [NotMapped]
        public string UsuaModificacion { get; set; }
        [NotMapped]
        public string UsuaCreacion { get; set; }

        public int coti_Id { get; set; }
        public DateTime? coti_Fecha { get; set; }
        public bool coti_Incluido { get; set; }
        public int empl_Id { get; set; }
        public bool coti_CompraDirecta { get; set; }





        [NotMapped]
        public int eqpp_Id { get; set; }
        [NotMapped]
        public int bode_Id { get; set; }
        [NotMapped]
        public string bode_Descripcion { get; set; }
        [NotMapped]
        public int bopi_Stock { get; set; }
        [NotMapped]
        public int prov_Id { get; set; }
        [NotMapped]
        public string prov_Descripcion { get; set; }
        [NotMapped]
        public double eqpp_PrecioCompra { get; set; }

        public int? usua_Creacion { get; set; }
        public DateTime? equs_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? equs_FechaModificacion { get; set; }
        public bool? equs_Estado { get; set; }
    }
}
