using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ControlDeCalidadViewModel
    {
        public int coca_Id { get; set; }
        public string coca_Descripcion { get; set; }
        public DateTime coca_Fecha { get; set; }
        public string coca_Resultado { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime coca_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? coca_FechaModificacion { get; set; }
        public bool? coca_Estado { get; set; }
        public int? acet_Id { get; set; }
        public int proy_Id { get; set; }
        public decimal? coca_CantidadTrabajada { get; set; }
        public decimal? coca_MetrosTrabajados { get; set; }
    }
}
