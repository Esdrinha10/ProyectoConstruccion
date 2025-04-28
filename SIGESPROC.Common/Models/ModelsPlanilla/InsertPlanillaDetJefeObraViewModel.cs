using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class InsertPlanillaDetJefeObraViewModel
    {
        public decimal empl_Salario { get; set; }
        public decimal totalDeducido { get; set; }
        public decimal totalPrestamos { get; set; }
        public int empl_Id { get; set; }
        public int plan_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime empl_FechaCreacion { get; set; }

    }
}
