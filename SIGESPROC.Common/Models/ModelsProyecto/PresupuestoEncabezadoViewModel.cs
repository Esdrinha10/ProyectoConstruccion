using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class PresupuestoEncabezadoViewModel
    {
        public int pren_Id { get; set; }
        public string pren_Titulo { get; set; }
        public string? pren_Descripcion { get; set; }
        public DateTime pren_Fecha { get; set; }
        public DateTime pren_FechaFinalizacion { get; set; }
        public decimal pren_PorcentajeGanancia { get; set; }
        public string? pren_Observacion { get; set; }
        public bool pren_Maquinaria { get; set; }
        public decimal? pren_Impuesto { get; set; }

        public int empl_Id { get; set; }
        public int clie_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime pren_FechaCreacion { get; set; }
        [NotMapped]
        public string cliente { get; set; }
        [NotMapped]
        public string empleado { get; set; }
        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string empl_DNI { get; set; }
        [NotMapped]
        public string clie_DNI { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? pren_FechaModificacion { get; set; }
        public string? pren_Estado { get; set; }
        public int? proy_Id { get; set; }
    }
}
