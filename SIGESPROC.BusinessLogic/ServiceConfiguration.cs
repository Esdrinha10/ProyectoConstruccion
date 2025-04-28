using Microsoft.Extensions.DependencyInjection;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.BusinessLogic.Services.ServiceAcceso;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.BusinessLogic.Services.ProyectoService;
using SIGESPROC.BusinessLogic.Services.ServiceGeneral;
using SIGESPROC.DataAccess.Context;
using SIGESPROC.DataAccess.Repositories.RepositoryAcceso;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.DataAccess.Repositories.RepositoryInsumo;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.DataAccess.Repositories.RepositoryFlete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.BusinessLogic.Services.ProcesosVentaService;
using SIGESPROC.BusinessLogic.Services.BancoService;
using SIGESPROC.BusinessLogic.Services.EmpleadoService;


namespace SIGESPROC.BusinessLogic
{
     public static class ServiceConfiguration
     {
        public static void DataAcces(this IServiceCollection service, string connection)
        {

            SIGESPROC.DataAccess.SIGESPROC.BuildConnectionString(connection);

            #region Acceso
            service.AddScoped<UsuarioRepository>();
            service.AddScoped<PantallaRepository>();
            service.AddScoped<RolRepository>();
            service.AddScoped<PantallaPorRolRepository>();
            #endregion

            #region Generales
            service.AddScoped<NivelRepository>();
            service.AddScoped<CategoriaRepository>();
            service.AddScoped<PaisRepository>();
            service.AddScoped<SubCategoriaRepository>();
            service.AddScoped<TipoProyectoRepository>();
            service.AddScoped<TasaCambioRepository>();
            service.AddScoped<UnidadMedidaRepository>();
            service.AddScoped<NivelRepository>();
            service.AddScoped<EmpleadoRepository>();
            service.AddScoped<EstadoRepository>();
            service.AddScoped<MonedaRepository>();
            service.AddScoped<EstadoCivilRepository>();
            service.AddScoped<CargoRepository>();
            service.AddScoped<CiudadRepository>();
            service.AddScoped<ClienteRepository>();
            service.AddScoped<BancoRepository>();
            service.AddScoped<ImpuestoRepository>();
            service.AddScoped<ReporteRepository>();
            service.AddScoped<DashboardRepository>();

            #endregion

            #region Insumos

            service.AddScoped<MaquinariaPorProveedorRepository>();
            service.AddScoped<MaquinariaRepository>();

            service.AddScoped<BodegaRepository>();
            service.AddScoped<BodegaPorInsumoRepository>();
            service.AddScoped<CotizacionRepository>();
            service.AddScoped<CompraEncabezadoRepository>();
            service.AddScoped<CompraDetalleRepository>();
            service.AddScoped<CotizacionDetalleRepository>();
            service.AddScoped<InsumoPorMedidaRepository>();
            service.AddScoped<InsumoPorProveedorRepository>();
  
            service.AddScoped<InsumoRepository>();
            service.AddScoped<MaterialRepository>(); 
            service.AddScoped<CotizacionPorDocumentoRepository>();
            service.AddScoped<ProveedorRepository>();
            #endregion

            #region Proyectos
            service.AddScoped<ActividadPorEtapaRepository>();
            service.AddScoped<ArchivoAdjuntoRepository>();
            service.AddScoped<ImagenPorIncidenteRepository>();
            service.AddScoped<IncidentePorActividadRepository>();
            service.AddScoped<IncidenteRepository>();
            service.AddScoped<NotificacionRepository>();
            service.AddScoped<NotificacionAlertaPorUsuarioRepository>();
            service.AddScoped<PagoRepository>();
            service.AddScoped<RetrasoRepository>();
            service.AddScoped<DocumentoRepository>();
            service.AddScoped<RentaMaquinariaPorActividadRepository>();

            service.AddScoped<InsumoPorActividadRepository>();


            service.AddScoped<EquipoSeguridadRepository>();
            service.AddScoped<EtapaRepository>();
            service.AddScoped<EstadoProyectoRepository>();
        
            service.AddScoped<ControlDeCalidadRepository>();
            service.AddScoped<ControlDeCalidadPorActividadRepository>();
            service.AddScoped<EtapaPorProyectoRepository>();
            service.AddScoped<GestionAdicionalRepository>();
            service.AddScoped<GestionRiesgoRepository>();
            service.AddScoped<ImagenPorControlCalidadRepository>();
            service.AddScoped<DocumentoRepository>();
            service.AddScoped<EquipoSeguridadRepository>();
            service.AddScoped<EstadoProyectoRepository>();
            service.AddScoped<EtapaRepository>();
            service.AddScoped<ActividadRepository>();
            service.AddScoped<AlertaRepository>();
            service.AddScoped<CategoriaRepository>();
            service.AddScoped<PresupuestoEncabezadoRepository>();
            service.AddScoped<PresupuestoDetalleRepository>();
            service.AddScoped<PresupuestoPorTasaCambioRepository>();
            service.AddScoped<ActividadRepository>();
            service.AddScoped<AlertaRepository>();
            service.AddScoped<ProyectoRepository>();
            service.AddScoped<InsumoPorActividadRepository>();
            service.AddScoped<RentaMaquinariaPorActividadRepository>();
            service.AddScoped<EquipoSeguridadPorActividadRepository>();
            service.AddScoped<ReferenciasRepository>();
            #endregion

            #region Fletes
            service.AddScoped<FleteControlCalidadRepository>();
            service.AddScoped<FleteEncabezadoRepository>();
            service.AddScoped<FleteDetalleRepository>();


            #endregion

            #region Bienes y Raices
            service.AddScoped<ProcesoVentaRepository>();
            service.AddScoped<AgenteBienesRaicesRepository>();
            service.AddScoped<BienRaizRepository>();
            service.AddScoped<DocumentoBienRaizRepository>();
            service.AddScoped<EmpresaBienRaizRepository>();
            service.AddScoped<ProyectoConstruccionBienRaizRepository>();
            service.AddScoped<TerrenoRepository>();
            service.AddScoped<ProcesoVentaImagenesRepository>();
            service.AddScoped<TipoDocumentoRepository>();
            service.AddScoped<MantenimientoRepository>();
            #endregion

            #region Planillas

            service.AddScoped<FrecuenciaRepository>();
            service.AddScoped<DeduccionRepository>();
            service.AddScoped<PrestamoRepository>();
            service.AddScoped<CategoriaViaticoRepository>();
            service.AddScoped<DeduccionRepository>();
            service.AddScoped<CostoPorActividadRepository>();
            service.AddScoped<PlanillaRepository>();
            service.AddScoped<ViaticoEncabezadoRepository>();
            service.AddScoped<ViaticoDetalleRepository>();
            service.AddScoped<ViaticoDetEncRepository>();
            service.AddScoped<PlanillaJefeCuadrillaRepository>();

            #endregion
        }
        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<GeneralService>();
            service.AddScoped<BienRaizService>();
            service.AddScoped<IncidentePorActividadService>();
            service.AddScoped<DeduccionService>();
            service.AddScoped<FrecuenciaService>();
            service.AddScoped<PrestamoService>();
            service.AddScoped<FleteControlCalidadService>();
            service.AddScoped<BienRaizService>();
            service.AddScoped<PlanillaService>();
            service.AddScoped<ProyectoService>();
            service.AddScoped<FleteService>();
            service.AddScoped<InsumoService>();
            service.AddScoped<AccesoService>();
            service.AddScoped<BancoService>();
            service.AddScoped<CostoPorActividadService>();
            service.AddScoped<EmpleadoService>();
            service.AddScoped<ViaticoDetalleService>();
            service.AddScoped<ViaticoEncabezadoService>();
            service.AddScoped<TipoDocumentoRepository>();
            service.AddScoped<ProcesoVentaService>();
            service.AddScoped<BienRaizService>();
            service.AddScoped<ReporteService>();
            service.AddScoped<DashboardService>();

        }
    }
  
  
}

   

