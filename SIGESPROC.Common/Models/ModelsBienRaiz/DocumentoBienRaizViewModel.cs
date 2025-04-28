using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
   public class DocumentoBienRaizViewModel
    {
        public int dobt_Id { get; set; }
        public string dobt_DescipcionDocumento { get; set; }
        public string dobt_TipoDocumento { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime dobt_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? dobt_FechaModificacion { get; set; }
        public bool? dobt_Estado { get; set; }
        public int? dobt_Terreno_O_BienRaizId { get; set; }
        public bool? dobt_Terreno_O_BienRaizbit { get; set; }
        [NotMapped]
        public string bien_Desripcion { get; set; }
        [NotMapped]
        public string terr_Descripcion { get; set; }
        [NotMapped]
        public string UsuarioCreacionNombre { get; set; }
        [NotMapped]
        public string UsuarioModificadorNombre { get; set; }
        
        public int tido_Id { get; set; }

        public string dobt_Imagen { get; set; }

        [NotMapped]
        public string tido_Descripcion { get; set; }
    }
}
