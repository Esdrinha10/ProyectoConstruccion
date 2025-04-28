using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsInsumo
{
    public class CompraDetalleViewModel
    {
        public int codt_Id { get; set; }
        public int coen_Id { get; set; }
        public int? code_Id { get; set; }
        public string coen_numeroCompra { get; set; }
        public int codt_InsumoOMaquinariaOEquipoSeguridad { get; set; }
        public int? codt_cantidad { get; set; }
        public decimal? codt_preciocompra { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime? codt_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? codt_FechaModificacion { get; set; }

        public int codm_Id { get; set; }
        public string codm_HorasRenta { get; set; }
        public int acet_Id { get; set; }
        public int codm_Cantidad { get; set; }

        [NotMapped]
        public int codd_Boat_Id { get; set; }
        [NotMapped]
        public int empl_Id { get; set; }

        [NotMapped]
        public int meto_Id { get; set; }
        

        public int codd_Id { get; set; }
        public int codd_Cantidad { get; set; }

        public bool? codd_ProyectoOBodega { get; set; }
        public int codd_BoPr_Id { get; set; }

        [NotMapped]
        public int cantidadParcialEnviada { get; set; }
        [NotMapped]
        public string acti_Descripcion { get; set; }

        [NotMapped]
        public string proy_Descripcion { get; set; }

        [NotMapped]
        public string etap_Descripcion { get; set; }

        [NotMapped]
        public string proy_Nombre { get; set; }
        public int codt_Renta { get; set; }

        public int code_Renta { get; set; }
        public int mapr_DiaHora { get; set; }

        public string tipoRenta { get; set; }

        public int identificador { get; set; }

        public string unidadMedida { get; set; }

        public string unidadMedidaoRenta { get; set; }

        public int coti_Impuesto { get; set; }
        public int coti_Incluido { get; set; }
    }
}
