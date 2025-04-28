using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class PrestamoViewModel
    {
        public int pres_Id { get; set; }
        public decimal pres_Monto { get; set; }
        public decimal pres_TasaInteres { get; set; }
        public decimal pres_Abonado { get; set; }
        public string pres_Descripcion { get; set; }
        public DateTime pres_FechaPrimerPago { get; set; }
        public int pres_Pagos { get; set; }

        public int? pres_PagosRestantes { get; set; }

        public int? empl_Id { get; set; }
        [NotMapped]
        public string? empleado { get; set; }
        public int? frec_Id { get; set; }
        [NotMapped]
        public string? frec_Descripcion { get; set; }

        public decimal? saldoRestante { get; set; }

        public decimal? montoCuotas { get; set; }

        public string? pres_UltimaFechaPago { get; set; }

        public int? frec_NumeroDias { get; set; }

        public decimal totalPrestamo { get; set; }

        public decimal cuotaSiguiente { get; set; }

        public int usua_Creacion { get; set; }
        public DateTime pres_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pres_FechaModificacion { get; set; }
        public bool? pres_Estado { get; set; }
    }
}
