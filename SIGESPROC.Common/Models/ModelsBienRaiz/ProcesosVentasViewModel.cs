using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsBienRaiz
{
    public class ProcesosVentasViewModel
    {
        public int btrp_Id { get; set; }
        public bool btrp_Identificador { get; set; }
        public decimal btrp_PrecioVenta_Inicio { get; set; }
        public decimal btrp_PrecioVenta_Final { get; set; }
        public DateTime btrp_FechaPuestaVenta { get; set; }
        public DateTime btrp_FechaVendida { get; set; }
        public int agen_Id { get; set; }
        public bool btrp_Terreno_O_BienRaizId { get; set; }
        public int? btrp_BienoterrenoId { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime btrp_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? btrp_FechaModificacion { get; set; }
        public bool? btrp_Estado { get; set; }
        public int? mant_Id { get; set; }

        [NotMapped]
        public string agen_NombreCompleto { get; set; }

        [NotMapped]
        public string agen_Telefono { get; set; }

        [NotMapped]
        public string agen_DNI { get; set; }

        [NotMapped]
        public string usuaCreacion { get; set; }

        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public string dobt_DescipcionDocumento { get; set; }
        [NotMapped]
        public int? dobt_Id { get; set; }
        [NotMapped]
        public int? dobt_Terreno_O_BienRaizId { get; set; }
        [NotMapped]
        public bool? dobt_Terreno_O_BienRaizbit { get; set; }
        [NotMapped]
        public string dobt_Imagen { get; set; }
        [NotMapped]
        public int tido_Id { get; set; }
        [NotMapped]
        public string tido_Descripcion { get; set; }

        [NotMapped]
        public string codigo { get; set; }

        public string descripcion { get; set; }

        [NotMapped]
        public string LinkUbicacion { get; set; }
        [NotMapped]
        public string Area { get; set; }

        [NotMapped]
        public string impr_Imagen { get; set; }

        [NotMapped]
        public string imagen { get; set; }

        [NotMapped]
        public string agen_Correo { get; set; }

        [NotMapped]
        public string precioCompra { get; set; }

        [NotMapped]
        public string bien_Precio { get; set; }

        [NotMapped]
        public string mant_DNI { get; set; }
        [NotMapped]
        public string mant_NombreCompleto { get; set; }

        [NotMapped]
        public string mant_Telefono { get; set; }

        [NotMapped]
        public string clie_Id { get; set; }
        //[NotMapped]
        //public string clie_Id { get; set; }

        [NotMapped]
        public string clie_DNI { get; set; }

        [NotMapped]
        public string clie_NombreCompleto { get; set; }

        [NotMapped]
        public string clie_Telefono { get; set; }

    }
}
