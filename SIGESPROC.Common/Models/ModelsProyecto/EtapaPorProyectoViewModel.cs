using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class EtapaPorProyectoViewModel
    {
        public int etpr_Id { get; set; }
 
        public int etap_Id { get; set; }
        public int empl_Id { get; set; }

        public int proy_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? etpr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? etpr_FechaModificacion { get; set; }
        public bool? etpr_Estado { get; set; }


        [NotMapped]
        public string UsuaModificacion { get; set; }
        [NotMapped]
        public string UsuaCreacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string etap_Descripcion { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string proy_FechaInicio { get; set; }
        [NotMapped]
        public string etpr_FechaInicio { get; set; }
        [NotMapped]
        public string etpr_FechaFin { get; set; }
        [NotMapped]
        public string empl_NombreCompleto { get; set; }
        [NotMapped]
        public string carg_Descripcion { get; set; }
        [NotMapped]
        public decimal etpr_CostoInsumos { get; set; }
        [NotMapped]
        public decimal etpr_CostoMaquinaria { get; set; }
        [NotMapped]
        public decimal etpr_CostoEquipoSeguridad { get; set; }
        [NotMapped]
        public string etpr_Progreso { get; set; }
        [NotMapped]
        public int row { get; set; }
    }
}
