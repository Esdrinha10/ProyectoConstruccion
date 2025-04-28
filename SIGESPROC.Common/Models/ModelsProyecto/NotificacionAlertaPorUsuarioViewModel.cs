using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class NotificacionAlertaPorUsuarioViewModel
    {
        public string napu_Ruta { get; set; }
        public int noti_Id { get; set; }
        public string noti_Ruta { get; set; }
        public string noti_Descripcion { get; set; }
        public DateTime noti_Fecha { get; set; }


        public int napu_Id { get; set; }
        public bool napu_AlertaOnoti { get; set; }
        public int napu_AlertaONotiId { get; set; }
        public int usua_Id { get; set; }
        public bool napu_Leida { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime napu_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? napu_FechaModificacion { get; set; }


        public int aler_Id { get; set; }
        public string aler_Descripcion { get; set; }
        public string aler_Ruta { get; set; }
        public DateTime aler_FechaCreacion { get; set; }
        public DateTime aler_Fecha { get; set; }





        public int tokn_Id { get; set; }
        public string fecha { get; set; }

        public string usuaCreacion { get; set; }

        public string napu_Estado { get; set; }
        public string usuaModificacion { get; set; }

        
        public string tokn_JsonToken { get; set; }
    }
}
