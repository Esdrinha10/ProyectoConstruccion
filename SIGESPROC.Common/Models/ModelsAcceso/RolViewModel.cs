using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsAcceso
{
    public class RolViewModel
    {
        public int role_Id { get; set; }
        public string role_Descripcion { get; set; }
        public List<int> pantallasSeleccionadas { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? role_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? role_FechaModificiacion { get; set; }
        public bool? role_Estado { get; set; }
    }
}
