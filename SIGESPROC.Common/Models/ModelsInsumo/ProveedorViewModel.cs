using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class ProveedorViewModel
    {
        public int prov_InsumoOMaquinariaOEquipoSeguridad { get; set; }
        public int prov_Id { get; set; }
        public string prov_Descripcion { get; set; }
        public string prov_Correo { get; set; }
        public string prov_Telefono { get; set; }
        public string prov_SegundoTelefono { get; set; }
        public int? ciud_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime prov_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? prov_FechaModificacion { get; set; }
        public bool? prov_Estado { get; set; }

        [NotMapped]
        public string ciud_Descripcion { get; set; }
        [NotMapped]
        public string frec_Descripcion { get; set; }
        [NotMapped]
        public string empl_DNI { get; set; }
        [NotMapped]
        public string empleado { get; set; }
        [NotMapped]
        public string esta_Nombre { get; set; }

        [NotMapped]
        public string pais_Nombre { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
    }
}
