using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class ClienteViewModel
    {
        public int clie_Id { get; set; }
        public string clie_DNI { get; set; }
        public string clie_Nombre { get; set; }
        public string clie_Apellido { get; set; }
        public string clie_CorreoElectronico { get; set; }
        public string clie_Telefono { get; set; }
        public DateTime clie_FechaNacimiento { get; set; }
        public string clie_Sexo { get; set; }
        public string clie_DireccionExacta { get; set; }
     
        public int ciud_Id { get; set; }
        public int civi_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? clie_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? clie_FechaModificacion { get; set; }
        public bool? clie_Estado { get; set; }

        [NotMapped]
        public string Codigo { get; set; }

        [NotMapped]
        public string clie_NombreCompleto { get; set; }

        [NotMapped]
        public string civi_Descripcion { get; set; }


        [NotMapped]
        public string ciud_Descripcion { get; set; }

        [NotMapped]

        public string clie_usua_Creacion { get; set; }
        [NotMapped]

        public string clie_usua_Modificacion { get; set; }


        [NotMapped]

        public string clie_usua_Creacionn { get; set; }
        [NotMapped]

        public string clie_usua_Modificacionn { get; set; }

        [NotMapped]
        public string clie_Tipo { get; set; }

        [NotMapped]
        public string tipoCliente { get; set; }

    }
}
