using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
    public class MantenimientoViewModel
    {
   
        public int mant_Id { get; set; }
        public string? mant_DNI { get; set; }
        public string mant_NombreCompleto { get; set; }
        public decimal? mant_Telefono { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime mant_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? mant_FechaModificacion { get; set; }
        public bool? mant_Estado { get; set; }
        [NotMapped]
        public string codigo { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string cliente { get; set; }
    }
}
