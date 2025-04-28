using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGESPROC.BusinessLogic.Services.ServiceGeneral;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
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
    public class ReporteController : Controller
    {
        private readonly ReporteService _reporteService;
        private readonly  BienRaizService _bienRaizService;
        private readonly InsumoService _insumoService;
        private readonly ProyectoService _proyectoService;
        private readonly GeneralService _generalService;
        private readonly FleteService _fleteService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador PaisController.
        /// </summary>
        /// <param name="generalService">Servicio general para manejar la lógica de negocio relacionada con países</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades</param>
        public ReporteController(ReporteService reporteService, IMapper mapper,BienRaizService bienRaizService,InsumoService insumoService, 
            ProyectoService proyectoService, GeneralService generalService ,FleteService fleteService)
        {
            _reporteService = reporteService;
            _bienRaizService = bienRaizService;
            _insumoService = insumoService;
            _proyectoService = proyectoService;
            _generalService = generalService;
            _fleteService = fleteService;
            _mapper = mapper;
        }

        [HttpGet("ReporteTerrenoFechaCreacion/{FechaInicio},{FechaFinal}")]
        public IActionResult ReporteTerrenoFechaCreacion(string FechaInicio, string FechaFinal)
        {
            var list = _reporteService.ReporteTerrenoFechaCreacion(FechaInicio, FechaFinal);
            return Ok(list.Data);
        }
        [HttpGet("ReporteTerrenosPorEstadoProyecto/{FechaInicio},{FechaFinal},{tipo}")]
        public IActionResult ReporteTerrenosPorEstadoProyecto(string FechaInicio, string FechaFinal,bool tipo)
        {
            var list = _reporteService.ReporteTerrenosPorEstadoProyecto(FechaInicio, FechaFinal, tipo);
            return Ok(list.Data);
        }
        [HttpGet("ReporteVentasPorEmpresa/{empresa}")]
        public IActionResult ReporteVentasPorEmpresa(int empresa)
        {
            var list = _reporteService.ReporteVentasPorEmpresa(empresa);
            return Ok(list.Data);
        }

        [HttpGet("DropDownEmpresa")]
        public IActionResult Empresa()
        {
            var list = _bienRaizService.ListarEmpresaBienRaizs();
            var drop = list.Data as List<tbEmpresasBienesRaices>;
            var rol = drop.Select(x => new
            {
                Text = x.embr_Nombre,
                Value = x.embr_Id.ToString()
            }).ToList();

            return Ok(rol);
        }
        [HttpGet("DropDownProveedor")]
        public IActionResult Proveedor()
        {
            var list = _insumoService.ListarProveedores();
            var drop = list.Data as List<tbProveedores>;
            var rol = drop.Select(x => new
            {
                Text = x.prov_Descripcion,
                Value = x.prov_Id.ToString()
            }).ToList();

            return Ok(rol);
        }
        [HttpGet("DropDownProyecto")]
        public IActionResult Proyecto()
        {
            var list = _proyectoService.ListarProyectos();
            var drop = list.Data as List<tbProyectos>;

           
            var rol = drop
                .Where(x => x.proy_Estado == true) 
                .Select(x => new
                {
                    Text = x.proy_Nombre,
                    Value = x.proy_Id.ToString()
                })
                .ToList();

            return Ok(rol);
        }
        [HttpGet("DropDownFletes")]
        public IActionResult Fletes()
        {
            var list = _fleteService.ListarFletes();
            var drop = list.Data as List<tbFletesEncabezado>;

            var rol = drop
                .Where(x => x.flde_llegada == false)
                .Select(x => new
                {
                    Text = $"#{x.flen_Id}" + "-" + x.Encargado ,
                    Value = x.flen_Id.ToString()
                })
                .ToList();

            return Ok(rol);
        }

        [HttpGet("DropDownTasaCambio")]
        public IActionResult TasaCambio()
        {
            var list = _generalService.ListarTasasCambios();
            var drop = list.Data as List<tbTasasCambio>;
            var rol = drop.Select(x => new
            {
                Text = "LPS -> " + x.moneda_B, 
                Value = x.taca_Id.ToString()
            }).ToList();

            return Ok(rol);
        }
        [HttpGet("DropCompra")]
        public IActionResult Compra()
        {
            var list = _insumoService.ListarCompraEncabezado();
            var drop = list.Data as List<tbComprasEncabezado>;
            var rol = drop.Select(x => new
            {
                Text = $"#{x.coen_numeroCompra}",
                Value = x.coen_Id.ToString()
            }).ToList();

            return Ok(rol);
        }
        [HttpGet("DropActividades")]
        public IActionResult Actividades()
        {
            var list = _proyectoService.ListarActividades();
            var drop = list.Data as List<tbActividades>;
            var rol = drop.Select(x => new
            {
                Text = x.acti_Descripcion,
                Value = x.acti_Id.ToString()
            }).ToList();

            return Ok(rol);
        }

        [HttpGet("DropEtapa")]
        public IActionResult Etapa(int id)
        {
            var list = _proyectoService.ListarEtapasPorProyectos(id);
            var drop = list.Data as List<tbEtapasPorProyectos>;
            var rol = drop.Select(x => new
            {
                Text = x.etap_Descripcion,
                Value = x.etap_Id.ToString()
            }).ToList();

            return Ok(rol);
        }


        [HttpGet("ReporteEmpleadoPorEstado/{estado}")]
        public IActionResult ReporteEmpleadoPorEstado(bool estado)
        {
            var list = _reporteService.ReporteEmpleadoPorEstado(estado);
            return Ok(list.Data);
        }
        [HttpGet("ReporteFletesPorFecha/{fehaInicio},{fechaFin}")]
        public IActionResult ReporteFletesPorFecha(string fehaInicio, string fechaFin)
        {
            var list = _reporteService.ReporteFletesPorFecha(fehaInicio,fechaFin);
            return Ok(list.Data);
        }
        [HttpGet("ReporteHistorialCotizaciones/{fehaInicio},{fechaFin},{id},{todo}")]
        public IActionResult ReporteHistorialCotizaciones(string fehaInicio, string fechaFin, int id, bool todo)
        {
            var list = _reporteService.ReporteHistorialCotizaciones(fehaInicio, fechaFin,id,todo);
            return Ok(list.Data);
        }
        [HttpGet("ReporteComprasRealizadas/{fehaInicio},{fechaFin}")]
        public IActionResult ReporteComprasRealizadas(string fehaInicio, string fechaFin)
        {
            var list = _reporteService.ReporteComprasRealizadas(fehaInicio, fechaFin);
            return Ok(list.Data);
        }
        [HttpGet("ReporteComparacionMonetaria/{proy_Id}")]
        public IActionResult ReporteComparacionMonetaria(int proy_Id)
        {
            var result = _reporteService.ReporteComparacionMonetaria(proy_Id);
                return Ok(result.Data);
        }
        [HttpGet("ReporteCotizacionesPorRangoPrecios/{tipo}/{precio}/{mostrar}")]
        public IActionResult ReporteCotizacionesPorRangoPrecios(int tipo, string precio, bool mostrar)
        {
            var result = _reporteService.ReporteCotizacionesPorRangoPrecios(tipo,precio,mostrar);
            return Ok(result.Data);
        }
        [HttpGet("ReporteInsumosBodega/{fechainicio},{fechafin}")]
        public IActionResult ReporteInsumosBodega(string fechainicio, string fechafin)
        {
            var result = _reporteService.ReporteInsumosBodega(fechainicio, fechafin);
            return Ok(result.Data);
        }
        [HttpGet("ReporteInsumosAProyecto/{fechainicio},{fechafin}")]
        public IActionResult ReporteInsumosAProyecto(string fechainicio, string fechafin)
        {
            var result = _reporteService.ReporteInsumosAProyecto(fechainicio, fechafin);
            return Ok(result.Data);
        }
        [HttpGet("ReporteHistorialPagosPorProyecto/{fechainicio},{fechafin},{proy_id}")]
        public IActionResult ReporteHistorialPagosPorProyecto(string fechainicio, string fechafin, int proy_id)
        {
            var result = _reporteService.ReporteHistorialPagosPorProyecto(fechainicio, fechafin,proy_id);
            return Ok(result.Data);
        }
        [HttpGet("ReporteComparativoProductos/{tipo}")]
        public IActionResult ReporteComparativoProductos(int tipo)
        {
            var result = _reporteService.ReporteComparativoProductos(tipo);
            return Ok(result.Data);
        }
        [HttpGet("ReportecomprasPendientesEnvio/{fechainicio},{fechafin}")]
        public IActionResult ReportecomprasPendientesEnvio(string fechainicio, string fechafin)
        {
            var result = _reporteService.ReportecomprasPendientesEnvio(fechainicio, fechafin);
            return Ok(result.Data);
        }
        [HttpGet("ReporteProgresoActividades/{proy_id},{fechainicio},{fechafin}")]
        public IActionResult ReporteProgresoActividades(int proy_id ,string fechainicio, string fechafin)
        {
            var result = _reporteService.ReporteProgresoActividades(proy_id,fechainicio, fechafin);
            return Ok(result.Data);
        }
        [HttpGet("ReportePorUbicacion/{ubicacion}")]
        public IActionResult ReportePorUbicacion(Boolean ubicacion)
        {
            var result = _reporteService.ReportePorUbicacion(ubicacion);
            return Ok(result.Data);
        }
        [HttpGet("EstadisticasFletes_Comparacion/{flen_Id}")]
        public IActionResult EstadisticasFletes_Comparacion(int flen_Id)
        {
            var result = _reporteService.EstadisticasFletes_Comparacion(flen_Id);
            return Ok(result.Data);
        }
        [HttpGet("ReporteProcesoVenta/{tipo},{estado}")]
        public IActionResult ReporteProcesoVenta(int tipo, bool estado)
        {
            var result = _reporteService.ReporteProcesoVenta(tipo,estado);
            return Ok(result.Data);
        }
        [HttpGet("EstadisticasFletes_Llegada/{FechaInicio},{FechaFin}")]
        public IActionResult EstadisticasFletes_Llegada(string FechaInicio, string FechaFin)
        {
            var result = _reporteService.EstadisticasFletes_Llegada(FechaInicio, FechaFin);
            return Ok(result.Data);
        }
        [HttpGet("ReporteInsumosTransportadosPorActividad/{FechaInicio},{FechaFin},{ActividadId}")]
        public IActionResult ReporteInsumosTransportadosPorActividad(string FechaInicio, string FechaFin,int ActividadId)
        {
            var result = _reporteService.ReporteInsumosTransportadosPorActividad(FechaInicio, FechaFin, ActividadId);
            return Ok(result.Data);
        }
        [HttpGet("ReporteInsumosUltimoPrecio/{numeroCompra}")]
        public IActionResult ReporteInsumosUltimoPrecio(string numeroCompra)
        {
            var result = _reporteService.ReporteInsumosUltimoPrecio(numeroCompra);
            return Ok(result.Data);
        }

        [HttpGet("ReporteArticulosActividades/{id},{eleccion}")]
        public IActionResult ReporteArticulosActividades(int id, int eleccion)
        {
            var result = _reporteService.ReporteArticulosActividades(id, eleccion);
            return Ok(result.Data);
        }
    }
}
