using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class CompraEncabezadoViewModel
    {
        public int coen_Id { get; set; }
        public bool coen_EnvioBodega { get; set; }
        public int empl_Id { get; set; }
        public int meto_Id { get; set; }
        public DateTime? codt_FechaModificacion { get; set; }
        public string coen_Id_numeroCompra { get; set; }

        public string coen_numeroCompra { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime coen_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? coen_FechaModificacion { get; set; }
        [NotMapped]
        public int codd_Boat_Id { get; set; }
        [NotMapped]
        public int codt_Id { get; set; }

        [NotMapped]
        public DateTime codt_FechaCreacion { get; set; }
        [NotMapped]
        public decimal codt_preciocompra { get; set; }
        [NotMapped]
        public int codt_cantidad { get; set; }
        [NotMapped]
        public int code_Id { get; set; }
        [NotMapped]
        public int coti_Id { get; set; }

        [NotMapped]
        public string CotizacionProveedor { get; set; }

        [NotMapped]
        public string empleado { get; set; }

        [NotMapped]
        public decimal TotalCompra { get; set; }

        [NotMapped]
        public int codigo { get; set; }

        [NotMapped]
        public int coim_Id { get; set; }

        [NotMapped]
        public string Articulo { get; set; }

        [NotMapped]
        public string code_PrecioCompra { get; set; }

        [NotMapped]
        public DateTime coti_Fecha { get; set; }

        [NotMapped]
        public string Categoria { get; set; }

        [NotMapped]
        public int? code_Cantidad { get; set; }

        [NotMapped]
        public string Total { get; set; }

        [NotMapped]
        public int? unme_Id { get; set; }

        [NotMapped]
        public string unidadMedida { get; set; }

        [NotMapped]
        public string unidadNomenclatura { get; set; }

        [NotMapped]
        public string AgregadoACotizacion { get; set; }

        [NotMapped]
        public int cime_InsumoOMaquinariaOEquipoSeguridad { get; set; }

        [NotMapped]
        public int codt_InsumoOMaquinariaOEquipoSeguridad { get; set; }

        [NotMapped]
        public DateTime fechaInicio { get; set; }
        [NotMapped]
        public DateTime fechaFin { get; set; }



        [NotMapped]
        public string usuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModifica { get; set; }
        [NotMapped]
        public int codt_Renta { get; set; }
        [NotMapped]
        public int code_Renta { get; set; }
        [NotMapped]
        public int mapr_DiaHora { get; set; }
        [NotMapped]
        public string tipoRenta { get; set; }
        [NotMapped]
        public string unidadMedidaoRenta { get; set; }
        [NotMapped]
        public int cantidadVerificada { get; set; }
        [NotMapped]
        public int cantidadParcialEnviada { get; set; }
        [NotMapped]
        public string ubicaciones { get; set; }
        [NotMapped]
        public int coti_Impuesto { get; set; }
        [NotMapped]
        public int coti_Incluido { get; set; }
        [NotMapped]

        public string tipoArticulo { get; set; }

    }
}
