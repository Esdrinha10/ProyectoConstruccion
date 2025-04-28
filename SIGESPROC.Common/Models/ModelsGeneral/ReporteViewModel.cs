using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{
    public class ReporteViewModel
    {
       
        ///reporte EstadisticasFletes_Comparacion 
        public string EncargadoComparacion { get; set; }
        public string supervisorComparacion { get; set; }
        public string supervisorllegadoComparacion { get; set; }
        public string fechasalidaComparacion { get; set; }
        public string fechaestablecidaComparacion { get; set; }
        public string fechallegadaComparacion { get; set; }
        public string estadoComparacion { get; set; }
        public string HorasDiferenciaComparacion { get; set; }


        public string TotalFletesProgramadosComparacion { get; set; }
        public string TotalFletesLlegadosComparacion { get; set; }
        public string DiferenciaFletesComparacion { get; set; }
        public string PorcentajeLlegadosComparacion { get; set; }


        public string Salida_CantidadComparacion { get; set; }
        public string Llegada_CantidadComparacion { get; set; }
        public string Insumo_SalidaComparacion { get; set; }
        public string Insumo_LlegadaComparacion { get; set; }

        ///reporte por ubicacion
        public string No_Ubicacion { get; set; }
        public string fechaCotizacionUbicacion { get; set; }
        public string PrecioCompra_CompraUbicacion { get; set; }
        public string ArticuloUbicacion { get; set; }
        public string UltimoPrecioUnitarioUbicacion { get; set; }
        public string UnidadMedidaUbicacion { get; set; }
        public string tipoArticuloUbicacion { get; set; }
        public string ubicacionesUbicacion { get; set; }



        ///////////reporte de progreso de actividad con control de calidad
        public string etapaDescripcion { get; set; }
        public string actividadDescripcion { get; set; }
        public string descripcionControlDeCalidad { get; set; }
        public string PorcentajeControlDeCalidad { get; set; }
        public string porcentajeTotalActividad { get; set; }
        public string porcentajeFaltanteActividad { get; set; }



        ///////   reporte compra pendiente de envio
        public string NoOrdencompraPendientesEnvio { get; set; }
        public string PrecioCompraPendientesEnvio { get; set; }
        public string NocompraPendientesEnvio { get; set; }
        public string unidadMedidaoRentaPendientesEnvio { get; set; }
        public string tipoRentaPendientesEnvio { get; set; }
        public string ArticuloCompraPendientesEnvio { get; set; }
        public string UltimoPrecioUnitarioPendientesEnvio { get; set; }
        public string UnidadMedidaPendientesEnvio { get; set; }
        public string FechaCompraPendientesEnvio { get; set; }
        public string fechaFinCompraPendientesEnvio { get; set; }
        public string fechaInicioCompraPendientesEnvio { get; set; }
        public string CotizacionProveedorPendientesEnvio { get; set; }

        public string cantidadVerificadaPendientesEnvio { get; set; }
        public string ubicacionesPendientesEnvio { get; set; }
        public string tipoArticuloPendientesEnvio { get; set; }




        //reporte de productos cotizado por varios proveedores
        public string codigoCotizacion { get; set; }
        public string ArticuloCotizacion { get; set; }
        public string UltimoPrecioUnitarioCotizacion { get; set; }
        public string unidadMedidaoRentaCotizacion { get; set; }
        public string cantidadCotizacion { get; set; }
        public string preciocompraCotizacionpp { get; set; }
        public string Total { get; set; }
        public string cantidadCotizacionpp { get; set; }
        public string fechacotiCotizacion { get; set; }


        //reporte de historial de pago 
        public string Proyectoplanilla { get; set; }
        public string Empleadoplanilla { get; set; }
        public string NumeroPlanilla { get; set; }
        public string FechaPagoplanilla { get; set; }
        public string SueldoBrutoplanilla { get; set; }
        public string TotalDeduccionesplanilla { get; set; }
        public string TotalPrestamosplanilla { get; set; }
        public string SueldoNetoplanilla { get; set; }
        public string PrestamosDescripcionplanilla { get; set; }
        public string TotalMontoPrestamosplanilla { get; set; }
        public string TotalMontoAbonadoplanilla { get; set; }
        public string TotalMontoEstimadoViaticoplanilla { get; set; }
        public string TotalTotalGastadoViaticoplanilla { get; set; }
        public string TotalMontoGastadoFacturaplanilla { get; set; }
        /////////////////////////////////////////////////////////////

        //RepprteTerrenoFechaCreacion/Reporteterrenoporproyecto
        public int terrenoId { get; set; }
        public string descripcion { get; set; }
        public string area { get; set; }
        public string precioCompra { get; set; }
        public string linkUbicacion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string fechaCreacion { get; set; }
        public string identificador { get; set; }

        ////Reporte de ventas de empresa por agente

        public int ventaId { get; set; }
        public string precioVentaInicio { get; set; }
        public string precioVentaFinal { get; set; }
        public string fechaPuestaVenta { get; set; }
        public string fechaVendida { get; set; }
        public string nombreAgente { get; set; }

        public string nombreEmpresa { get; set; }


        ////Empleado reporte por inactividad
        public int codigo { get; set; }
        public string dNI { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string nacimiento { get; set; }
        public string salario { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string estadoCivil { get; set; }
        public string cargo { get; set; }
        public string banco { get; set; }
        public string noBancario { get; set; }
        public string frecuencia { get; set; }
        public string frec_NumeroDias { get; set; }
        public string empl_NombreCompleto { get; set; }
        ///Fin de reportes empleados por activo/Inactivo
        ///
        ///Reporte fletes por fecha
        public int numeroFlete { get; set; }
        public string Encargado { get; set; }
        public string Supervisorsalida { get; set; }
        public string Supervisorllegada { get; set; }
        public string EstadoFlete { get; set; }
        public string FechaHoraSalida { get; set; }
        public string FechaHoraLlegada { get; set; }
        public string FechaHoraEstablecidaDeLlegada { get; set; }
        public string Salida { get; set; }
        public string DestinoProyecto { get; set; }
        public string Actividad_Etapa { get; set; }
        public string Destino { get; set; }
        public string Cantidad { get; set; }
        public string flde_Llegada { get; set; }
        public string Proveedor { get; set; }
        public string Insumo { get; set; }
        public string Observaciones { get; set; }
        public string fleteDetalleLLegada { get; set; }
        public string TipoCarga { get; set; }
        public string Material { get; set; }
        public string EquipoSeguridad1 { get; set; }
        public string UnidadMedida { get; set; }
        public string Nomenclatura { get; set; }
        public string Bodega { get; set; }
        public string Stock { get; set; }
        //public string PrecioCompra { get; set; } si va es solo que ya existe otro con el mismo nombre
        public string EquipoSeguridad2 { get; set; }
        public string Equiposeguridad3 { get; set; }
        //Fin aca


        ///Reporte de cotizacion historial
        public int NoCotiazacion { get; set; }
        public string FechaCotizacion { get; set; }
        public string EmpleadoCotizacion { get; set; }
        public string ImpuestoCotizacion { get; set; }
        public string CantidadProductos { get; set; }
        public string PrecioCompraCotizacion { get; set; }
        public string ProveedorCotizacion { get; set; }
        public string CorreoProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string SegundoTelefonoProveedor { get; set; }
        ////Fin
        ///

        //Reporte de Compras Realizada en un rango de tiempo
        //public int codigo { get; set; } si va pero ya existe uno arriba
        public string CantidadCompra { get; set; }
        public string PrecioCompra_Compra { get; set; }
        public string unidadMedidaoRentaCompra { get; set; }
        public string tipoRentaCompra { get; set; }
        public string ArticuloCompra { get; set; }
        public string UltimoPrecioUnitarioCompra { get; set; }
        public string UnidadMedidaCompra { get; set; }
        public string FechaCompra { get; set; }
        public string fechaFinCompra { get; set; }
        public string fechaInicioCompra { get; set; }
        public string ImpuestoCompra { get; set; }
        public string CotizacionProveedorCompra { get; set; }

        public string cantidadVerificadaCompra { get; set; }
        public string ubicacionesCompra { get; set; }
        public string tipoArticuloCompra { get; set; }

        public string tipoArticulo { get; set; }
        ///Reporte ReporteComparacionMonetaria
        //pARTE DEL PROYECTO
        public string etapa_comparativo { get; set; }
        public string etapa_TotalCantidad_comparativo { get; set; }
        public string etapa_TotalManoObra_comparativo { get; set; }
        public string etapa_TotalMateriales_comparativo { get; set; }
        public string etapa_TotalSubtotal_comparativo { get; set; }
        public string actividad_comparacion { get; set; }
        public string cantidad_comparativo { get; set; }
        public string manoObraUsada_comparativo { get; set; }
        public string unidadmedida_comparativo { get; set; }
        public string costoMateriales_comparativo { get; set; }
        public string precioUnitario_comparativo { get; set; }
        public string subtotal_comparativo { get; set; }

        //Etapa

 
        ///Presupiestp mas proyecto + cliente
        public string Total_Cantidad_Proyecto { get; set; }
        public string Total_ManoObra_Proyecto { get; set; }
        public string Total_CostoMateriales_Proyecto { get; set; }
        public string Total_Subtotal_Proyecto { get; set; }
        public string Total_Cantidad_Presupuesto { get; set; }
        public string Total_ManoObra_Presupuesto { get; set; }
        public string Total_CostoMateriales_Presupuesto { get; set; }
        public string Total_PrecioMaquinaria_Presupuesto { get; set; }
        public string Total_Ganancia_Presupuesto { get; set; }
        public string Total_Pagos_Proyecto { get; set; }
        public string Total_Global_Proyecto { get; set; }
        public string Total_Global_Presupuesto { get; set; }
        //Datos del presupuesto




        //////////////////Fin

        //////Reporte de productoos rango de precio
        public DateTime CotiFecha { get; set; } 
        public string ProveedorDescripcion { get; set; } 
        public decimal PrecioCompraInsumo { get; set; }
        public decimal PrecioCompraMaquinaria { get; set; }
        public decimal PrecioCompraEquipoSeguridad { get; set; }

        public string DescripcionInsumo { get; set; }
        public string DescripcionMaquinaria { get; set; } 
        public string DescripcionEquipoSeguridad { get; set; } 

  
        public string UnidadMedidaNombre { get; set; } 
        public string UnidadMedidaNomenclatura { get; set; } 

        public string Tipo { get; set; }


        /////reporte de cotizacion insumo por precio

        public string ProveedorDescripcionRangoprecio { get; set; }
        public string PrecioCompraInsumoRangoprecio { get; set; }
        public string PrecioCompraMaquinariaRangoprecio { get; set; }
        public string PrecioCompraEquipoSeguridadRangoprecio { get; set; }

        public string DescripcionInsumoRangoprecio { get; set; }
        public string DescripcionMaquinariaRangoprecio { get; set; }
        public string DescripcionEquipoSeguridadRangoprecio { get; set; }
        public string UnidadMedidaNombreRangoprecio { get; set; }
        public string UnidadMedidaNomenclaturaRangoprecio { get; set; }
        public string TipoRangoprecio { get; set; }
        /////////Fin


        /////////reporte de insumo a bodega
        public string cantidadBodega { get; set; }
        public string unidadMedidaoRentaBodega { get; set; }
        public string tipoRentaBodega { get; set; }
        public string articuloBodega { get; set; }
        public string ultimoPrecioUnitarioBodega { get; set; }
        public string unidadMedidaBodega { get; set; }
        public string fechaFinBodega { get; set; }
        public string fechaIniciobodega { get; set; }
        public string impuestoBodega { get; set; }
        public string CotizacionProveedorBodega { get; set; }
        public string cantidadVerificadaBodega { get; set; }
        public string ubicacionesBodegas { get; set; }
        public string tipoArticuloBodegas { get; set; }
        ///Fin
        /////////reporte de insumo a bodega
        public string cantidadproyecto { get; set; }
        public string numerocompraproyecto { get; set; }
        public string unidadMedidaoRentaproyecto { get; set; }
        public string tipoRentaproyecto { get; set; }
        public string UltimoPrecioUnitarioproyecto { get; set; }
        public string UnidadMedidaproyecto { get; set; }
        public string fechaFinproyecto { get; set; }
        public string fechaInicioproyecto { get; set; }
        public string CotizacionProveedorproyecto { get; set; }
        public string cantidadVerificadaproyecto { get; set; }
        public string ubicacionesproyecto { get; set; }
        public string tipoArticuloproyecto { get; set; }
        ///Fin
    }
}
