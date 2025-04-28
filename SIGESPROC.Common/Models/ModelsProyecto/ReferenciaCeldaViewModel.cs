using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ReferenciaCeldaViewModel
    {
        public int rece_Id { get; set; }
        public string rece_Referencia { get; set; }
        public string rece_Tipo { get; set; }
        public int acet_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? rece_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? rece_FechaModificacion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
    }
}
