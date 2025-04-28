using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
   public class AgenteBienesRaicesViewModel
    {



        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }

        [NotMapped]
        public string embr_Nombre { get; set; }
        public int codigo { get; set; }
        public int agen_Id { get; set; }
        public string agen_DNI { get; set; }
        public string agen_Nombre { get; set; }
        public string agen_Apellido { get; set; }
        public string agen_Telefono { get; set; }
        public string agen_Correo { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime agen_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? agen_FechaModificacion { get; set; }
        public bool? agen_Estado { get; set; }
        public int? embr_Id { get; set; }



    }
}
