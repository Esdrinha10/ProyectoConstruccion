using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsAcceso
{
    public class UsuarioViewModel
    {
        public int usua_Id { get; set; }
        public string usua_Usuario { get; set; }
        public string usua_Clave { get; set; }
        public bool usua_EsAdministrador { get; set; }
        public int? empl_Id { get; set; }
        public int role_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? usua_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? usua_FechaModificacion { get; set; }
        public bool? usua_Estado { get; set; }
        [NotMapped]
        public string empleadoDNI { get; set; }

        [NotMapped]
        public string role_Descripcion { get; set; }
        [NotMapped]
        public string empleado { get; set; }

        [NotMapped]
        public string codigo { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string nombre_Empleado { get; set; }
        [NotMapped]
        public string empl_CorreoElectronico { get; set; }
        [NotMapped]
        public string empl_Telefono { get; set; }
        [NotMapped]
        public string empl_Imagen { get; set; }
        [NotMapped]
        public string carg_Descripcion { get; set; }

        [NotMapped]
        public DateTime empl_FechaNacimiento { get; set; }
        
        [NotMapped]
        public int? pant_Id { get; set; }

        [NotMapped]
        public string pant_Descripcion { get; set; }
    }
}
