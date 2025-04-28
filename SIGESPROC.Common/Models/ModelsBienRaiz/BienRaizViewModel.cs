using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
   public class BienRaizViewModel
    {
        public int bien_Id { get; set; }
        public string bien_Desripcion { get; set; }
        public int? pcon_Id { get; set; }
        public int usua_Creacion { get; set; }
        public string bien_Imagen { get; set; }
        [NotMapped]
        public string bien_Identificador { get; set; }

        [NotMapped]
        public int terr_Id { get; set; }
        [NotMapped]
        public int proy_Id { get; set; }
        [NotMapped]
        public string terr_Descripcion { get; set; }
        [NotMapped]
        public string terr_Direccion { get; set; }
        [NotMapped]
        public string terr_Area { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string proy_Descripcion { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }

        [NotMapped]
        public string descripcion { get; set; }

        public DateTime bien_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? bien_FechaModificacion { get; set; }
        public bool? bien_Estado { get; set; }
        public decimal? bien_Precio { get; set; }

        [NotMapped]
        public int DocumentoId { get; set; }
        [NotMapped]
        public string DescripcionDocumento { get; set; }
        [NotMapped]
        public DateTime? DocumentoFechaCreacion { get; set; }
        [NotMapped]
        public int TipoDocumentoId { get; set; }
        [NotMapped]
        public string TipoDocumentoDescripcion { get; set; }
        [NotMapped]
        public int Codigo2 { get; set; }
        [NotMapped]
        public int Codigo { get; set; }
        [NotMapped]
        public string DocumentoImagen { get; set; }





    }
}
