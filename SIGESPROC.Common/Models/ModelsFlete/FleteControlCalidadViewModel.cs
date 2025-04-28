using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsFlete
{
    public class FleteControlCalidadViewModel
    {
        public int flcc_Id { get; set; }
        public string flcc_DescripcionIncidencia { get; set; }
        public DateTime flcc_FechaHoraIncidencia { get; set; }
        public int flen_Id { get; set; }
        public int usua_Creacion { get; set; }
        [NotMapped]
        public string codigo { get; set; }
        public DateTime flcc_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? flcc_FechaModificacion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        public bool? flcc_Estado { get; set; }
        [NotMapped]
        public DateTime flen_FechaHoraSalida { get; set; }
        [NotMapped]
        public DateTime flen_FechaHoraEstablecidaDeLlegada { get; set; }
        [NotMapped]
        public bool? flen_Estado { get; set; }
        [NotMapped]
        public bool? flen_DestinoProyecto { get; set; }

    }
}
