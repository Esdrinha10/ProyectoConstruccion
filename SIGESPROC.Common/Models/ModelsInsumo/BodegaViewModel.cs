using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class BodegaViewModel
    {
        public int bode_Id { get; set; }
        public string bode_Descripcion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime bode_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? bode_FechaModificiacion { get; set; }
        public bool? bode_Estado { get; set; }
        public string bode_Latitud { get; set; }
        public string bode_Longitud { get; set; }
        public string bode_LinkUbicacion { get; set; }

        [NotMapped]
        public bool check { get; set; }

        [NotMapped]
        public int? inpp_Id { get; set; }
        [NotMapped]
        public int? bopi_Stock { get; set; }

        [NotMapped]
        public int codigo { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }

    }
}
