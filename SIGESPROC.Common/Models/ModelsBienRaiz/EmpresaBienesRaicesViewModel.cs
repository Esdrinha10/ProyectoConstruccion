using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
   public class EmpresaBienesRaicesViewModel
    {
        [NotMapped]
        public int codigo { get; set; }
        public int embr_Id { get; set; }
        public string embr_Nombre { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string embr_ContactoA { get; set; }
        [NotMapped]
        public string embr_ContactoB { get; set; }
        [NotMapped]
        public string embr_TelefonoA { get; set; }
        [NotMapped]
        public string embr_TelefonoB { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime embr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? embr_FechaModificacion { get; set; }
        public bool? embr_Estado { get; set; }
       
    }
}
