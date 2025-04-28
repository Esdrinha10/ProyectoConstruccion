using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsFlete
{
    public class FleteEncabezadoViewModel
    {
        public int flen_Id { get; set; }
        public DateTime flen_FechaHoraSalida { get; set; }
        public DateTime flen_FechaHoraEstablecidaDeLlegada { get; set; }
        public DateTime flen_FechaHoraLlegada { get; set; }
        public bool flen_Estado { get; set; }
        public bool flen_DestinoProyecto { get; set; }
        public int boas_Id { get; set; }
        public int emtr_Id { get; set; }
        public int emss_Id { get; set; }
        public int emsl_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime flen_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? flen_FechaModificacion { get; set; }
        public int? flen_EstadoFlete { get; set; }
        public int boat_Id { get; set; }
        [NotMapped]
        public string boat_Descripcion { get; set; }
        [NotMapped]
        public int proy_Id { get; set; }
        [NotMapped]
        public string proy_Descripcion { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public int acti_Id { get; set; }
        [NotMapped]
        public int etap_Id { get; set; }
        [NotMapped]
        public string acti_Descripcion { get; set; }
        [NotMapped]
        public string etap_Descripcion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public  bool? flen_SalidaProyecto { get; set; }

        [NotMapped]
        public string flen_ComprobanteLLegada { get; set; }
    }
}
