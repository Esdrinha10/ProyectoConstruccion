using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class TasaCambioViewModel
    {
        public int taca_Id { get; set; }
        public int mone_A { get; set; }
        public int mone_B { get; set; }

        [NotMapped]
        public string moneda_A { get; set; }
        [NotMapped]
        public string moneda_B { get; set; }
        public decimal? taca_ValorA { get; set; }
        public decimal taca_ValorB { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime taca_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? taca_FechaModificacion { get; set; }
        public bool? taca_Estado { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int codigo { get; set; }
    }
}
