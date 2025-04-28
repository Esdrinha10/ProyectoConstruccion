using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
  public  class TerrenoViewModel
    {
        public int terr_Id { get; set; }
        public string terr_Descripcion { get; set; }
        public string terr_Area { get; set; }
        public bool? terr_Estado { get; set; }
        public string terr_PecioCompra { get; set; }
        public string terr_PrecioVenta { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime terr_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? terr_FechaModificacion { get; set; }
        public string terr_LinkUbicacion { get; set; }
        public string terr_Imagen { get; set; }

   
        public string terr_Longitud { get; set; }
  
        public string terr_Latitud { get; set; }

        [NotMapped]
        public string descripcion { get; set; }

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
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int DocumentoImagen { get; set; }
        [NotMapped]
        public string dobt_DescipcionDocumento { get; set; }


        public bool? terr_Identificador { get; set; }

    }
}

