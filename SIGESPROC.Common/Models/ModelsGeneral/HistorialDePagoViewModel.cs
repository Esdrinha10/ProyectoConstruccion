using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class HistorialDePagoViewModel
    {
        public int codigo { get; set; }
        public int plan_NumNomina { get; set; }
        public int empl_Id { get; set; }
        public string nombreCompleto { get; set; }
        public string cargo { get; set; }
        public string frecuencia { get; set; }
        public int frec_NumeroDias { get; set; }
        public int plan_Id { get; set; }
        public decimal empl_Salario { get; set; }
        public decimal totalDeducido { get; set; }
        public decimal totalPrestamos { get; set; }
        public decimal plde_SueldoNeto { get; set; }
    }
}
