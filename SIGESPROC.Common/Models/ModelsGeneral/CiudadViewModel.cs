using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class CiudadViewModel
    {
        public int ciud_Id { get; set; }
        public string ciud_Codigo { get; set; }
        public string ciud_Descripcion { get; set; }
        public int esta_Id { get; set; }
        [NotMapped]
        public string Codigo { get; set; }

        [NotMapped]
        public string esta_Nombre { get; set; }

        [NotMapped]
        public string pais_Id { get; set; }
        [NotMapped]
        public string pais_Nombre { get; set; }

        [NotMapped]
        public string ciud_usua_Creacion { get; set; }
        [NotMapped]
        public string ciud_usua_Modificacion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime ciud_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? ciud_FechaModificiacion { get; set; }
    }
}
