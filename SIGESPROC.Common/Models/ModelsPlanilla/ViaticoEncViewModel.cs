using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class ViaticoEncViewModel
    {
        public int codigo { get; set; }
        public string Empleado { get; set; }
        public string Proyecto { get; set; }
        

        public int vien_Id { get; set; }
        public bool vien_SaberProyeto { get; set; }
        public decimal vien_MontoEstimado { get; set; }
        public decimal vien_TotalGastado { get; set; }
        public DateTime vien_FechaEmicion { get; set; }
        public int empl_Id { get; set; }
        public int Proy_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime vien_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? vien_FechaModificacion { get; set; }
        [NotMapped]
        public bool? usuarioEsAdm { get; set; }
        [NotMapped]
        public decimal vien_TotalReconocido { get; set; }

    }
}
