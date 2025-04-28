using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class ViaticosEnc_Det
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
        public decimal vien_TotalReconocido { get; set; }
        public int vide_Id { get; set; }
        public string vide_Descripcion { get; set; }
        public string cavi_Descripcion { get; set; }
        public string vide_ImagenFactura { get; set; }
        public string vide_MontoGastado { get; set; }
        public int cavi_Id { get; set; }
        public DateTime vide_FechaCreacion { get; set; }
        public DateTime? vide_FechaModificacion { get; set; }
        public decimal vide_MontoReconocido { get; set; }
    }
}
