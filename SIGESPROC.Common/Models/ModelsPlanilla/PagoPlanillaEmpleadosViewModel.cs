using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class PagoPlanillaEmpleadosViewModel
    {
        public int plan_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime empl_FechaCreacion { get; set; }
        public int codigo { get; set; }
        public int empl_Id { get; set; }
        public Boolean empl_Estado { get; set; }
        public string empl_DNI { get; set; }
        public string empl_Nombre { get; set; }
        public string empl_Apellido { get; set; }
        public string empl_CorreoElectronico { get; set; }
        public int empl_Salario { get; set; }
        public int carg_Id { get; set; }
        public string cargo { get; set; }
        public string frecuencia { get; set; }
        public int horasExtras { get; set; }
        public int salarioExtra { get; set; }
        public int salarioDiario { get; set; }
        public int totalDevenagado { get; set; }
        public int totalPrestamos { get; set; }

        public decimal totalDeducido { get; set; }

        public decimal sueldoTotal { get; set; }

        public string frec_Descripcion { get; set; }

        public int frec_NumeroDias { get; set; }

        public IEnumerable<SIGESPROC.Common.Models.ModelsPlanilla.DeduccionViewModel> deducciones { get; set; }
        public IEnumerable<SIGESPROC.Common.Models.ModelsPlanilla.PrestamoViewModel> prestamos { get; set; }
    }
}
