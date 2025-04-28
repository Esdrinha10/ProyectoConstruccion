using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class NotificacionViewModel
    {
        public int noti_Id { get; set; }
        public string noti_Descripcion { get; set; }
        public DateTime noti_Fecha { get; set; }
        public string noti_Leida { get; set; }
        public string noti_Ruta { get; set; }
        public string noti_Tipo { get; set; }
        public int etpr_Id { get; set; }
        public int usua_Creacion { get; set; }
        public string napu_Ruta { get; set; }
        public int tian_Id { get; set; }
        public string tian_Descripcion { get; set; }
        public DateTime tian_FechaCreacion { get; set; }
        public DateTime tian_FechaModificacion { get; set; }
        public DateTime noti_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? noti_FechaModificacion { get; set; }

        [NotMapped]
        public string usuaNotificacion { get; set; }
    }
}
