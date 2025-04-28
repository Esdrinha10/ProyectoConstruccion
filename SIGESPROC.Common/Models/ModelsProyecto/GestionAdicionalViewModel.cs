using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class GestionAdicionalViewModel
    {
        public int adic_Id { get; set; }
        public string adic_Descripcion { get; set; }
        public DateTime adic_Fecha { get; set; }
        public decimal adic_PresupuestoAdicional { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime adic_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? adic_FechaModificacion { get; set; }
        public bool? adic_Estado { get; set; }


        [NotMapped]
        public int acet_Id { get; set; }

        [NotMapped]
        public int codigo { get; set;  }

        public string acti_Descripcion { get; set; }
        [NotMapped]
        public int acet_Cantidad { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string etap_Id { get; set; }
        [NotMapped]
        public string etpr_Id { get; set; }
        [NotMapped]
        public string etap_Descripcion { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string proy_Id { get; set; }
        [NotMapped]
        public string proy_Descripcion { get; set; }

        [NotMapped]

        public string adic_UsuarioCreacion { get; set; }
        [NotMapped]

        public string adic_UsuarioModificacion { get; set; }
    }
}
