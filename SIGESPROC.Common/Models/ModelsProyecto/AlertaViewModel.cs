using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class AlertaViewModel
    {
        public int aler_Id { get; set; }
        public DateTime aler_Fecha { get; set; }
        public string aler_Descripcion { get; set; }
        public int proy_Id { get; set; }
        public int usua_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? aler_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public int tian_Id { get; set; }
        public string aler_Ruta { get; set; }



        public DateTime? aler_FechaModificacion { get; set; }
        public bool? aler_Estado { get; set; }
    }
    
}
