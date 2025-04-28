using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class InsumoPorMedidaViewModel
    {
        public int inpm_Id { get; set; }
        public int insu_Id { get; set; }
        public int unme_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime inpm_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? inpm_FechaModificacion { get; set; }
    }
}
