using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{

    public class DeduccionViewModel

    {
        public int empl_Id { get; set; }
        public int saberSiDeduce { get; set; }
        public int dedu_Id { get; set; }
        public string dedu_Descripcion { get; set; }
        public double dedu_Porcentaje { get; set; }
        public bool dedu_EsMontoFijo { get; set; }
        public int plde_Id { get; set;  }
        public int usua_Creacion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        public DateTime dedu_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        public DateTime? dedu_FechaModificacion { get; set; }
        public decimal empl_Salario { get; set; }
        public decimal totalPorDeduccion { get; set; }
        public decimal totalDeducido { get; set; }
        public decimal sueldoTotal { get; set; }
        public bool? dedu_Estado { get; set; }
    }
}
