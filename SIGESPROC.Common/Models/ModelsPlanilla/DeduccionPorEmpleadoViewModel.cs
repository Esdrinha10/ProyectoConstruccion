using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{

    public class DeduccionPorEmpleadoViewModel

    {
        public int deem_Id { get; set; }
        public int dedu_Id { get; set; }
        public int empl_Id { get; set; }
        [NotMapped]
        public bool? deem_EsMontoFijo { get; set; }
        [NotMapped]
        public double deem_Porcentaje { get; set; }
        public bool? _checked { get; set; }
        [NotMapped]
        public string? dedu_Descripcion { get; set; }
        [NotMapped]
        public bool? dedu_EsMontoFijo { get; set; }
        [NotMapped]
        public double dedu_Porcentaje { get; set; }
        [NotMapped]
        public string deduccionesJSON { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime deem_FechaCreacion { get; set; }
    }
}
