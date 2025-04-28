using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ImagenesPorIncidenciasViewModel
    {
        public int imin_Id { get; set; }
        public string imin_Imagen { get; set; }
        public int? inac_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? imin_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? imin_FechaModificacion { get; set; }
    }
}
