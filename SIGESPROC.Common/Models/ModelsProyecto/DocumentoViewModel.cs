using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
  public class DocumentoViewModel
    {
        public int docu_Id { get; set; }
        public string docu_Tipo { get; set; }
        public string docu_Descripcion { get; set; }
        public string docu_Ruta { get; set; }
        public DateTime docu_Fecha { get; set; }
        public int? empl_Id { get; set; }
        public int proy_Id { get; set; }
        public int usua_Creacion { get; set; }
        public DateTime docu_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? docu_FechaModificacion { get; set; }
        public bool? docu_Estado { get; set; }

        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string empl_NombreCompleto { get; set; }
        [NotMapped]
        public string docu_TipoDescripcion { get; set; }
        [NotMapped]
        public string usuaCreacion { get; set; }
        [NotMapped]
        public string usuaModificacion { get; set; }
        [NotMapped]
        public int row { get; set; }

    }
}
