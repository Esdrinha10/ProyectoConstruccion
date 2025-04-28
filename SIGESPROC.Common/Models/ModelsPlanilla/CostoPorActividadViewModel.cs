using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class CostoPorActividadViewModel
    {
        [NotMapped]
        public int codigo { get; set; }
        public int copc_Id { get; set; }
        public string copc_Observacion { get; set; }
        [NotMapped]
        public string UnidadDeMedida { get; set; }

        public int? unme_Id { get; set; }
        [NotMapped]
        public string Actividad { get; set; }
        public int? acti_Id { get; set; }
        public decimal? copc_Valor { get; set; }
        public bool? copc_EsPorcentaje { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? copc_FechaCreacion { get; set; }
        [NotMapped]
        public string UsuarioModifica { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? copc_FechaModificacion { get; set; }
        public int? copc_EstadoActividad { get; set; }
    }
}
