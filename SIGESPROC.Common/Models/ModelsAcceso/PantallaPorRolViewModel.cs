using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsAcceso
{
    public class PantallaPorRolViewModel
    {
        public int paro_Id { get; set; }
        public int pant_Id { get; set; }
        public int role_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime paro_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? paro_FechaModificiacion { get; set; }
        public bool? paro_Estado { get; set; }
    }
}
