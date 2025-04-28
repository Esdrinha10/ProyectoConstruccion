using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
   public class Reporte2ViewModel
    {
        //reporte insumos ultimo precio
        public string codigoUltimoPrecio { get; set; }
        public string CantidadCompraUltimoPrecio { get; set; }
        public string PrecioCompra_CompraUltimoPrecio { get; set; }
        public string PrecioCotizacionUltimoPrecio { get; set; }
        public string UnidadMedidaCompraUltimoPrecio { get; set; }
        public string ArticuloCompraUltimoPrecio { get; set; }
        public string FechaCompraUltimoPrecio { get; set; }
        public string ImpuestoCompraUltimoPrecio { get; set; }
        public string CotizacionProveedorCompraUltimoPrecio { get; set; }
        public string TipoArticuloCompraUltimoPrecio { get; set; }


        //Reporte de fletes TransportadosPorActividad
        public string codigo_flete { get; set; }
        public string flde_Cantidad { get; set; }
        public string InsumosFletesporActividad { get; set; }
        public string actividad_Descripcion { get; set; }
        public string proveedor_Descripcion { get; set; }

        public string flete_Observacion { get; set; }
        public string materiales_Descripcion { get; set; }
        public string equipos_Nombre { get; set; }

        public string unme_Nombre { get; set; }
        public string bodega_Descripcion { get; set; }
        public string flete_Stock { get; set; }
        public string FechaCreacion_flete { get; set; }
        public string FechaModificacion_flete { get; set; }

        ///reporte Proceso de venta
        public string btrp_PrecioVenta_Inicio { get; set; }
        public string btrp_PrecioVenta_Final { get; set; }
        public string btrp_FechaPuestaVenta { get; set; }

        public string btrp_FechaVendida { get; set; }
        public string bien_Descripcion { get; set; }
        public string terr_Descripcion { get; set; }
        public string terr_Area { get; set; }
        public string terr_PecioCompra { get; set; }
        public string agen_DNI { get; set; }
        public string agen_Nombre { get; set; }
        public string agen_Apellido { get; set; }
        public string clie_DNI { get; set; }
        public string clie_Nombre { get; set; }
        public string clie_Apellido { get; set; }


        ///repoprte fletes Estadistica de llegada 
        public string EncargadoLlegada { get; set; }
        public string SupervisorSalidaLlegada { get; set; }
        public string SupervisorLlegadaLlegada { get; set; }
        public string FechaHoraSalidaLlegada { get; set; }
        public string FechaHoraLlegadaLlegada { get; set; }
        public string FechaHoraEstablecidaDeLlegada { get; set; }
        public string DiferenciaenHorasLlegada { get; set; }
        public string EstadoLlegadaLlegada { get; set; }
        public string SalidaProyectoLlegada { get; set; }
        public string DestinoProyectoLlegada { get; set; }
        public string EstadoLlegada { get; set; }

        //Reporte de articulos 
        public string Categoria { get; set; }
        public string Articulo { get; set; }
        public string Actividad { get; set; }
        public string Etapa { get; set; }
        public string Proyecto { get; set; }
        public string codigo { get; set; }
        public decimal total { get; set; }
    }
}
