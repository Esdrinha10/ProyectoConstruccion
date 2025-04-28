using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ImagenPorControlCalidadViewModel
    {
        public int icca_Id { get; set; }
        public string icca_Imagen { get; set; }
        public string icca_Descripcion { get; set; }
        public int? coac_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime icca_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? icca_FechaModificacion { get; set; }
        public bool? icca_Estado { get; set; }
        public int coca_Id { get; set; }
    }
}
