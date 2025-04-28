using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGESPROC.BusinessLogic.Services.ServiceGeneral;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGESPROC.BusinessLogic.Services.GeneralService;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {

        private readonly BienRaizService _bienRaizService;
        private readonly InsumoService _insumoService;
        private readonly ProyectoService _proyectoService;
        private readonly GeneralService _generalService;
        private readonly DashboardService _dashboardService;

        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador PaisController.
        /// </summary>
        /// <param name="generalService">Servicio general para manejar la lógica de negocio relacionada con países</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades</param>
        public DashboardController(DashboardService dashboardService, IMapper mapper, BienRaizService bienRaizService, InsumoService insumoService, ProyectoService proyectoService, GeneralService generalService)
        {
            _dashboardService = dashboardService;
            _bienRaizService = bienRaizService;
            _insumoService = insumoService;
            _proyectoService = proyectoService;
            _generalService = generalService;
            _mapper = mapper;
        }


        //Insumos
        [HttpGet("DashboardTop5Proveedores")]
        public IActionResult DashboardTop5Proveedores()
        {
            var response = _dashboardService.DashboardTop5Proveedores(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }
        [HttpGet("DashboardTop5ArticulosCompradoss")]
        public IActionResult Top5ArticulosComprados()
        {
            var response = _dashboardService.DashboardTop5ArticulosCompradoss(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardTop5ArticulosporcadaCompradoss")]
        public IActionResult Top5ArticulosPorcadaComprados()
        {
            var response = _dashboardService.DashboardTop5ArticulosporcadaCompradoss(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }
        [HttpGet("DashboardTotalesComprasMensuales")]
        public IActionResult TotalesComprasMensuales()
        {
            var response = _dashboardService.DashboardTotalesComprasMensuales(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardTotalesComprasPorFecha/{fehaInicio},{fechaFin}")]
        /*
         @param fechaInicio
        @param fechafin
         */
        public IActionResult ReporteFletesPorFecha(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardTotalesComprasPorFecha(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

        [HttpGet("ProveedoresMasComprados/{fehaInicio},{fechaFin}")]
        public IActionResult DashboardCompraProveedoresMasComprados(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.Top5ProveedoresMasComprados(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

        [HttpGet("TopDestinosCompras/{fehaInicio},{fechaFin}")]
        public IActionResult DashboardTopDestinosCompras(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.Top5DestinosComprasEnviados(fehaInicio,  fechaFin);
            return Ok(list.Data);
        }

        //fletes
        [HttpGet("DashboardProyectosRelacionados")]
        public IActionResult DashboardProyectosRelacionados()
        {
            var response = _dashboardService.ProyectosRelacionados(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("ProyectosRelacionadosFletes/{fehaInicio},{fechaFin}")]
        public IActionResult DashboardProyectosRelacionados(string fehaInicio, string fechaFin)
        {
            var response = _dashboardService.ProyectosRelacionados(fehaInicio, fechaFin); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardTop5BodegasDestino")]
        public IActionResult DashboardTop5BodegasDestino()
        {
            var response = _dashboardService.Top5BodegasDestino(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }
        [HttpGet("Top5BodegasDestino/{fechaInicio},{fechaFin}")]
        public IActionResult DashboardTop5BodegasDestinoFecha(string fechaInicio, string fechaFin)
        {
            var response = _dashboardService.Top5BodegasDestino(fechaInicio, fechaFin); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardFletesTasaIncidencias")]
        public IActionResult DashboardFletesTasaIncidencias()
        {
            var response = _dashboardService.FletesTasaIncidencias(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("TasaIncidenciasMesFletes/{fechaInicio},{fechaFin}")]
        public IActionResult DashboardTasaIncidenciasFletes(string fechaInicio, string fechaFin)
        {
            var response = _dashboardService.TasaIncidenciasMesFletes(fechaInicio, fechaFin); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }



        //bienes raices
        [HttpGet("DashboardVentasPorAgente")]
        public IActionResult DashboardVentasPorAgente()
        {
            var response = _dashboardService.VentasPorAgente(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardVentaMensualBienRaiz")]
        public IActionResult DashboardVentasBienRaiz()
        {
            var response = _dashboardService.VentasBienRaiz(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardVentaMensualTerreno")]
        public IActionResult DashboardVentaTerreno()
        {
            var response = _dashboardService.VentasTerrenos(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardTerrenosPorMees")]
        public IActionResult DashboardTerrenosPorMees()
        {
            var response = _dashboardService.TerrenosPorMees(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("TotalesVentasPorAgente/{fehaInicio},{fechaFin}")]
        public IActionResult VentasPorAgente(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardVentasPorAgente(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

        [HttpGet("ProyectosconMayorCostoporDepartamento/{id}")]
        public IActionResult DashboardProyectosconMayorCostoporDepartamento(int id)
        {
            var list = _dashboardService.DashboardProyectosconMayorCostoporDepartamento(id);
            return Ok(list.Data);
        }

        [HttpGet("TotalesTerrenos/{fehaInicio},{fechaFin}")]
        /*
         @param fechaInicio
        @param fechafin
         */
        public IActionResult DashboardTotalTerrenosVendidos (string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardTotalTerrenosVendidos(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

        [HttpGet("TotalesVentaBienesRaices/{fehaInicio},{fechaFin}")]
        /*
         @param fechaInicio
        @param fechafin
         */
        public IActionResult DashboardTotalBienesRaicesVendidas(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardTotalBienesRaicesVendidos(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

        [HttpGet("TotalesVendidosNovendidos/{fehaInicio},{fechaFin}")]
        /*
         @param fechaInicio
        @param fechafin
         */
        public IActionResult DashboardTotalVendidosNovendidos(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardTotalVendidosNovendidos(fehaInicio, fechaFin);
            return Ok(list.Data);
        }
        [HttpGet("DashboardcomparativoBienraiz")]
        public IActionResult DashboardcomparativoBienraiz()
        {
            var response = _dashboardService.comparativoBienraiz(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }


        //proyectos
        [HttpGet("DashboardTop5ProyectosMayorPresupuesto")]
        public IActionResult DashboardTop5ProyectosMayorPresupuesto()
        {
            var response = _dashboardService.Top5ProyectosMayorPresupuesto(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }


        //proyectos
        [HttpGet("DashboardProyectosPorDepartamentos")]
        public IActionResult DashboardProyectosPorDepartamentos()
        {
            var response = _dashboardService.proyectospordepartamentos(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardIncidenciasPorMes")]
        public IActionResult DashboardIncidenciasPorMes()
        {
            var response = _dashboardService.incidenciaspormes(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        [HttpGet("DashboardProyectosPorDepartamentoteDetalle/{id}")]
        public IActionResult DashboardProyectosPorDepartamentoteDetalle(int id)
        {
            var response = _dashboardService.ProyectosPorDepartamentoteDetalle(id); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }


        //planilla


        [HttpGet("DashboardDeudasPorEmpleado/{id}")]
        public IActionResult DashboardDeudasPorEmpleado(int id)
        {
            var response = _dashboardService.DeudasPorEmpleado(id); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }



        [HttpGet("PagosJefesdeObra/{fehaInicio},{fechaFin}")]
        public IActionResult DashboardPagosJefesObras(string fehaInicio, string fechaFin)
        {
            var response = _dashboardService.PagosJefesDeObra(fehaInicio, fechaFin); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }

        [HttpGet("TopBancosMasAcreditados/{fehaInicio},{fechaFin}")]
        public IActionResult BancosMasAcreditados(string fehaInicio, string fechaFin)
        {
            var response = _dashboardService.BancosMasAcreditados(fehaInicio, fechaFin); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }

        [HttpGet("TotalAnual/{fechaactual}")]
        public IActionResult NominaTotalAnual(string fechaactual)
        {
            var response = _dashboardService.PlanillaTotalAnual(fechaactual); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }
        [HttpGet("DashboardTop5Bancos")]
        public IActionResult DashboardTop5Bancos()
        {
            var response = _dashboardService.DashboardTop5Bancos(); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }


        [HttpGet("DashboardPrestamoViaticosMes")]
        public IActionResult DashboardPrestamoViaticosMes()
        {
            var response = _dashboardService.DashboardPrestamoViaticosMes(); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }


        [HttpGet("DashboardPrestamoMes")]
        public IActionResult DashboardPrestamoMes()
        {
            var response = _dashboardService.DashboardPrestamoMes(); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }



        [HttpGet("JefesObra")]
        public IActionResult JefesObra()
        {
            var response = _dashboardService.JefesObra(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }


        [HttpGet("IncidenciasPorfechas/{fehaInicio},{fechaFin}")]
    
        public IActionResult DashboardProyectosIncidenciasPorrangofechas(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardProyectosIncidenciasPorrangofechas(fehaInicio, fechaFin);
            return Ok(list.Data);
        }


        [HttpGet("MayorCostoPorFechas/{fehaInicio},{fechaFin}")]
        public IActionResult DashboardProyectosMayorcostoporRangofechas(string fehaInicio, string fechaFin)
        {
            var list = _dashboardService.DashboardProyectosMayorcostoporRangofechas(fehaInicio, fechaFin);
            return Ok(list.Data);
        }

    }
}
