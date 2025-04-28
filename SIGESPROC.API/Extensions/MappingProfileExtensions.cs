using AutoMapper;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Common.Models.ModelsFlete;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGESPROC.Entities;

namespace SIGESPROC.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            #region Acceso
            CreateMap <UsuarioViewModel, tbUsuarios>().ReverseMap();
            CreateMap<PantallaViewModel, tbPantallas>().ReverseMap();
            CreateMap<RolViewModel, tbRoles>().ReverseMap();
            #endregion

            #region Generales
            CreateMap<NivelViewModel, tbNiveles>().ReverseMap();
            CreateMap<ClienteViewModel, tbClientes>().ReverseMap();
            CreateMap<CiudadViewModel, tbCiudades>().ReverseMap();
            CreateMap<PaisViewModel, tbPaises>().ReverseMap();
            CreateMap<SubCategoriaViewModel, tbSubcategorias>().ReverseMap();
            CreateMap<CategoriaViewModel, tbCategorias>().ReverseMap();
            CreateMap<TasaCambioViewModel, tbTasasCambio>().ReverseMap();
            CreateMap<TipoProyectoViewModel, tbTiposProyecto>().ReverseMap();
            CreateMap<EmpleadoViewModel, tbEmpleados>().ReverseMap();
            CreateMap<EstadoViewModel, tbEstados>().ReverseMap();
            CreateMap<MonedaViewModel, tbMonedas>().ReverseMap();
            CreateMap<EstadoCivilViewModel, tbEstadosCiviles>().ReverseMap();
            CreateMap<CargoViewModel, tbCargos>().ReverseMap();
            CreateMap<ClienteViewModel, tbClientes>().ReverseMap();
            CreateMap<BancoViewModel, tbBancos>().ReverseMap();
            CreateMap<UnidadMedidaViewModel, tbUnidadesMedida>().ReverseMap();
            CreateMap<NotificacionViewModel, tbNotificaciones>().ReverseMap();
            CreateMap<RetrasoViewModel, tbRetrasos>().ReverseMap();
            CreateMap<PagoViewModel, tbPagos>().ReverseMap();
            CreateMap<ImpuestoViewModel, tbImpuestos>().ReverseMap();
            CreateMap<ReporteViewModel, tbTerrenos>().ReverseMap();
            CreateMap<DashboardViewModel, tbTerrenos>().ReverseMap();

            #endregion

            #region Planillas
            CreateMap<tbPlanillaDetalles, PagoPlanillaEmpleadosViewModel>();
            CreateMap<PagoPlanillaEmpleadosViewModel, tbEmpleados>().ReverseMap();
            CreateMap<DeduccionViewModel, tbDeducciones>().ReverseMap();
            CreateMap<FrecuenciaViewModel, tbFrecuencias>().ReverseMap();
            CreateMap<PrestamoViewModel, tbPrestamos>().ReverseMap();
            CreateMap<AbonosPorPrestamosViewModel, tbAbonosPorPrestamos>().ReverseMap();
            CreateMap<CategoriaVaticoViewModel, tbCategoriasViaticos>().ReverseMap();
            CreateMap<DeduccionViewModel, tbDeducciones>().ReverseMap();
            CreateMap<CostoPorActividadViewModel, tbCostoPorActividad>().ReverseMap();
            CreateMap<tbPlanillas, PlanillaViewModel>();
            CreateMap<ViaticoDetViewModel, tbViaticosDetalles>().ReverseMap();
            CreateMap<ViaticoEncViewModel, tbViaticosEncabezados>().ReverseMap();
            CreateMap<ViaticosEnc_Det, ViaticosEnc_Det>().ReverseMap();
            CreateMap<PagoJefeObraPlanillaViewModel, PagoJefeObraPlanillaViewModel>().ReverseMap();
            #endregion

            #region Fletes
            CreateMap<FleteControlCalidadViewModel, tbFletesControlCalidad>().ReverseMap();
            CreateMap<FleteEncabezadoViewModel, tbFletesEncabezado>().ReverseMap();
            CreateMap<FleteDetalleViewModel, tbFletesDetalle>().ReverseMap();

            #endregion

            #region Bienes y Raices
            CreateMap<ProcesosVentasViewModel, tbProcesosVentas>().ReverseMap();
            CreateMap<AgenteBienesRaicesViewModel, tbAgentesBienesRaices>().ReverseMap();
            CreateMap<BienRaizViewModel, tbNiveles>().ReverseMap();
            CreateMap<DocumentoBienRaizViewModel, tbNiveles>().ReverseMap();
            CreateMap<EmpresaBienesRaicesViewModel, tbNiveles>().ReverseMap();
            CreateMap<ProyectoConstruccionBienRaizViewModel, tbProyectosConstruccionBienesRaices>().ReverseMap();
            CreateMap<TerrenoViewModel, tbTerrenos>().ReverseMap();
            CreateMap<ImageneProcesoVentaViewModel, tbImagenesPorProcesosVentas>().ReverseMap();
            CreateMap<TipoDocumentoViewModel, tbTiposDocumentos>().ReverseMap();
            CreateMap<MantenimientoViewModel, tbMantenimientos>().ReverseMap();

            #endregion

            #region Proyectos
            CreateMap<ActividadPorEtapaViewModel, tbActividadesPorEtapas>().ReverseMap();
            CreateMap<ArchivoAdjuntoViewModel, tbImagenesPorGestionesAdicionales>().ReverseMap();
            CreateMap<ImagenesPorIncidenciasViewModel, tbImagenesPorIncidencias>().ReverseMap();
            CreateMap<IncidenciasPorActividadesViewModel, tbIncidenciasPorActividades>().ReverseMap();
            CreateMap<ControlDeCalidadViewModel, tbControlDeCalidadesPorActividades>().ReverseMap();
            CreateMap<ControlDeCalidadPorActividadViewModel, tbControlDeCalidadesPorActividades>().ReverseMap();
            CreateMap<EtapaPorProyectoViewModel, tbEtapasPorProyectos>().ReverseMap();
            CreateMap<GestionAdicionalViewModel, tbGestionesAdicionales>().ReverseMap();
            CreateMap<GestionRiesgoViewModel, tbGestionRiesgos>().ReverseMap();
            CreateMap<ImagenPorControlCalidadViewModel, tbImagenesPorControlesDeCalidades>().ReverseMap();
            CreateMap<DocumentoViewModel, tbDocumentos>().ReverseMap();
            CreateMap<EtapaViewModel, tbEtapas>().ReverseMap();
            CreateMap<EquipoSeguridadViewModel, tbEquiposSeguridad>().ReverseMap();
            CreateMap<EstadoProyectoViewModel, tbEstadosProyectos>().ReverseMap();
            CreateMap<ActividadesViewModel, tbActividades>().ReverseMap();
            CreateMap<AlertaViewModel, tbAlertas>().ReverseMap();
            CreateMap<CategoriaViewModel, tbCategorias>().ReverseMap();
            CreateMap<PresupuestoEncabezadoViewModel, tbPresupuestosEncabezado>().ReverseMap();
            CreateMap<PresupuestoDetalleViewModel, tbPresupuestosDetalle>().ReverseMap();
            CreateMap<PresupuestoPorTasaCambioViewModel, tbPresupuestosPorTasasCambio>().ReverseMap();
            CreateMap<ProyectoViewModel, tbProyectos>().ReverseMap();
            CreateMap<IncidentesViewModel, tbIncidentes>().ReverseMap();
            CreateMap<ActividadesViewModel, tbActividades>().ReverseMap();
            CreateMap<AlertaViewModel, tbAlertas>().ReverseMap();
            CreateMap<InsumoPorActividadViewModel, tbInsumosPorActividades>().ReverseMap();
            CreateMap<NotificacionAlertaPorUsuarioViewModel, tbNotificaciones>().ReverseMap();
            CreateMap<RentaMaquinariaPorActividadViewModel, tbRentaMaquinariasPorActividades>().ReverseMap();
            CreateMap<ReferenciaCeldaViewModel, tbReferenciasCeldas>().ReverseMap();
            CreateMap<tbImagenesPorGestionesAdicionales, ImagenesPorGestionesAdicionalesViewModel>();
            #endregion

            #region Insumos
            CreateMap<tbMaquinarias, MaquinariaViewModel>();
            CreateMap<tbMaquinariasPorProveedores, MaquinariaPorProveedorViewModel>();
        
            CreateMap<BodegaViewModel, tbBodegas>().ReverseMap();
            CreateMap<BodegaPorInsumoViewModel, tbBodegasPorInsumo>().ReverseMap();
            CreateMap<CompraEncabezadoViewModel, tbCotizaciones>().ReverseMap();
            CreateMap<CompraEncabezadoViewModel, tbComprasEncabezado>().ReverseMap();
            CreateMap<CotizacionDetalleViewModel, tbComprasDetalle>().ReverseMap();
            CreateMap<CompraEncabezadoViewModel, tbCotizaciones>().ReverseMap();
            CreateMap<InsumoPorMedidaViewModel, tbInsumosPorMedidas>().ReverseMap();
            CreateMap<InsumoPorProveedorViewModel, tbInsumosPorProveedores>().ReverseMap();
           
            CreateMap<InsumoViewModel, tbInsumos>().ReverseMap();
            CreateMap<MaterialViewModel, tbMateriales>().ReverseMap();
            CreateMap<ProveedorViewModel, tbProveedores>().ReverseMap();
            CreateMap<tbProveedores, ProveedorViewModel>().ReverseMap();
            CreateMap<CompraDetalleViewModel, tbComprasDetalle>();
            CreateMap<CotizacionPorDocumentoViewModel, tbCotizaciones>().ReverseMap();
            #endregion

         
        }
    }
}
