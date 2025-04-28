using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class EmpleadoViewModel
    {
        public int empl_Id { get; set; }
        public string empl_DNI { get; set; }
        public string empl_Nombre { get; set; }
        public string empl_Apellido { get; set; }
        public string empl_CorreoElectronico { get; set; }
        public string empl_Telefono { get; set; }
        public string empl_Sexo { get; set; }
        public DateTime empl_FechaNacimiento { get; set; }
        public decimal? empl_Salario { get; set; }
        public decimal empl_Prestaciones { get; set; }
        public decimal empl_OtrasRemuneraciones { get; set; }
        public int ciud_Id { get; set; }
        [NotMapped]
        public decimal salarioPromedio { get; set; }
        [NotMapped]
        public string deducciones_Ids { get; set; }
        [NotMapped]
        public string deduccionesJSON { get; set; }
        [NotMapped]
        public string ciudad { get; set; }
        [NotMapped]
        public int? esta_Id { get; set; }
        [NotMapped]
        public string estado { get; set; }

        public int civi_Id { get; set; }
        [NotMapped]
        public string estadoCivil { get; set; }

        public int carg_Id { get; set; }
        [NotMapped]
        public string cargo { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? empl_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? empl_FechaModificacion { get; set; }
        public bool? empl_Estado { get; set; }
        public int? frec_Id { get; set; }
        [NotMapped]
        public string frecuencia { get; set; }

        public int? banc_Id { get; set; }
        public string empl_NoBancario { get; set; }
        [NotMapped]
        public string banco { get; set; }

        [NotMapped]
        public string empl_NombreCompleto { get; set; }
        [NotMapped]
        public string empl_Imagen { get; set; }
        public string empl_ObservacionActivar { get; set; }
        public string empl_ObservacionInactivar { get; set; }
    }
}
