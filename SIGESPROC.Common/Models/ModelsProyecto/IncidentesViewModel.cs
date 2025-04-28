using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class IncidentesViewModel
    {
        public int inci_Id { get; set; }
        public string inci_Descripcion { get; set; }
        
        [NotMapped]
        public int codigo { get; set; }

        [NotMapped]
        public int acet_Id { get; set; }

        public DateTime inci_Fecha { get; set; }
        public decimal inci_Costo { get; set; }
        public int empl_Id { get; set; }
        [NotMapped]
        public string imin_Imagen { get; set; }

        [NotMapped] //
        public DateTime? imin_FechaModificacion { get; set; }

        [NotMapped] //
        public DateTime? imin_FechaCreacion { get; set; }



        [NotMapped]
        public string usuario_Creacion { get; set; }
        [NotMapped]
        public string usuario_Modificacion { get; set; }

        [NotMapped]
        public int proy_Id { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string proy_Descripcion { get; set; }
        [NotMapped]
        public DateTime proy_FechaInicio { get; set; }
        [NotMapped]
        public DateTime proy_FechaFin { get; set; }

        [NotMapped]

        public string etap_Descripcion { get; set; }

        public string acti_Descripcion { get; set; }
        [NotMapped]
        public int acet_Cantidad { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string etap_Id { get; set; }
        [NotMapped]
        public string etpr_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? inci_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inci_FechaModificacion { get; set; }
        public bool? inci_Estado { get; set; }
    }
}
