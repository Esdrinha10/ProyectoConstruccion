using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class ContenedordePlanilla
    {
        public IEnumerable<PlanillaViewModel> planillaViewModel { get; set; }
        public IEnumerable<PagoPlanillaEmpleadosViewModel> planillaEmpleado { get; set; }
    }
}
