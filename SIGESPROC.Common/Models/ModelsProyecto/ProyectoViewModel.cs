using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ProyectoViewModel
    {
        public int proy_Id { get; set; }
        public int tipr_Id { get; set; }
        public string proy_Nombre { get; set; }
        public string proy_Descripcion { get; set; }
        public DateTime proy_FechaInicio { get; set; }
        public DateTime proy_FechaFin { get; set; }
        public string proy_DireccionExacta { get; set; }
        public int espr_Id { get; set; }
        public int clie_Id { get; set; }
        public int? frec_Id { get; set; }
        public int ciud_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? proy_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? proy_FechaModificacion { get; set; }
        public bool? proy_Estado { get; set; }

        [NotMapped]
        public string proyecto { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string esta_Nombre { get; set; }
        [NotMapped]
        public string pais_Nombre { get; set; }
        [NotMapped]
        public string ciud_Descripcion { get; set; }
        [NotMapped]
        public string clie_NombreCompleto { get; set; }
        [NotMapped]
        public string espr_Descripcion { get; set; }
        [NotMapped]
        public int row{ get; set; }
        [NotMapped]
        public string tipr_Descripcion { get; set; }
        [NotMapped]
        public string frecuencia { get; set; }
        [NotMapped]
        public int frec_NumeroDias { get; set; }
        [NotMapped]
        public string proy_Progreso { get; set; }
        [NotMapped]
        public decimal proy_CostoInsumos { get; set; }
        [NotMapped]
        public decimal proy_CostoMaquinaria { get; set; }
        [NotMapped]
        public decimal proy_CostoEquipoSeguridad { get; set; }
        [NotMapped]
        public decimal proy_CostoIncidencias { get; set; }
    }
}
