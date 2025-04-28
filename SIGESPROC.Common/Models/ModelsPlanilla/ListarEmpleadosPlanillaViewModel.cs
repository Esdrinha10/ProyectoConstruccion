using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class ListarEmpleadosPlanillaViewModel
    {
        public string fecha { get; set; } 
        public int frecid { get; set; } 
        public bool jefeplani { get; set; } 
        public bool saberCrear { get; set; } 
        public int plan_Id { get; set; }
        public int usuaCrea { get; set; }
    }
}
