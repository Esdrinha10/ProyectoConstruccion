using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsProyecto
{
    public class ActividadPorEtapaViewModel
    {
        public int acet_Id { get; set; }
        public string acet_Observacion { get; set; }
        public int? acet_Cantidad { get; set; }
        public int espr_Id { get; set; }
        public int? empl_Id { get; set; }
        public DateTime acet_FechaInicio { get; set; }
        public DateTime acet_FechaFin { get; set; }
        public decimal acet_PrecioManoObraEstimado { get; set; }
        public decimal acet_PrecioManoObraFinal { get; set; }
        public int? acti_Id { get; set; }
        public int? unme_Id { get; set; }
        public int? etpr_Id { get; set; }
        public int? usua_Creacion { get; set; }
        public DateTime? acet_FechaCreacion { get; set; }
        public int? usua_Modificacion { get; set; }
        public DateTime? acet_FechaModificacion { get; set; }
        public bool? acet_Estado { get; set; }
        [NotMapped]
        public decimal inpa_CostoInsumos { get; set; }

        [NotMapped]
        public string espr_Descripcion { get; set; }
        [NotMapped]
        public int proy_Id { get; set; }
        [NotMapped]
        public string proy_Descripcion { get; set; }
        [NotMapped]
        public string proy_Nombre { get; set; }
        [NotMapped]
        public string empl_NombreCompleto { get; set; }
        [NotMapped]
        public int etap_Id { get; set; }
        [NotMapped]
        public decimal? acet_CostoInsumos { get; set; }
        [NotMapped]
        public string etap_Descripcion { get; set; }
        [NotMapped]
        public string acti_Descripcion { get; set; }
        [NotMapped]
        public string unme_Nombre { get; set; }
        [NotMapped]
        public string unme_Nomenclatura { get; set; }
        [NotMapped]
        public decimal acet_CostoMaquinaria { get; set; }
        [NotMapped]
        public decimal acet_CostoEquipoSeguridad { get; set; }
        [NotMapped]
        public decimal acet_Progreso { get; set; }
        [NotMapped]
        public int row { get; set; }
        
    }
}
