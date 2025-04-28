using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ProcesosVentaService;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    // Define la ruta base para el controlador y especifica que es un controlador de API
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoVentaController : Controller
    {
        // Inyección de dependencias para los servicios y AutoMapper
        private readonly BienRaizService _bienRaizService;
        private readonly ProcesoVentaService _procesoVentaService;
        private readonly IMapper _mapper;

        // Constructor que inicializa los servicios y AutoMapper
        public ProcesoVentaController(BienRaizService bienRaizService, ProcesoVentaService procesoVentaService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _procesoVentaService = procesoVentaService;
            _mapper = mapper;
        }

        // Endpoint de tipo HttpGet para listar todos los procesos de venta
        [HttpGet("Listar")]
        public IActionResult ListarProcesosVenta()
        {
            var response = _procesoVentaService.ListarProcesosVenta(); // Llama al servicio para obtener la lista de procesos de venta
            return Ok(response.Data); // Retorna un código 200 con la data obtenida
        }

        // Endpoint de tipo HttpGet que busca un proceso de venta por su ID, tipo y otro ID adicional
        [HttpGet("Buscar/{id}/{tipo}/{id2}")]
        public IActionResult BuscarProcesoVenta(int id, int tipo, int id2)
        {
            var result = _procesoVentaService.BuscarProcesoVenta(id, tipo, id2); // Llama al servicio para buscar un proceso de venta específico
            if (result.Success)
            {
                return Ok(result.Data); // Si la operación es exitosa, retorna un código 200 con la data obtenida
            }
            return BadRequest(result.Message); // Si falla, retorna un código 400 con el mensaje de error
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarClienteVenta(int id)
        {
            var result = _procesoVentaService.BuscarClienteVendido(id); // Llama al servicio para buscar un proceso de venta específico
            if (result.Success)
            {
                return Ok(result.Data); // Si la operación es exitosa, retorna un código 200 con la data obtenida
            }
            return BadRequest(result.Message); // Si falla, retorna un código 400 con el mensaje de error
        }

        // Endpoint de tipo HttpPost para insertar un nuevo proceso de venta
        [HttpPost("Insertar")]
        public virtual IActionResult Create(ProcesosVentasViewModel procesosVentasViewModel)
        {
            var modelo = _mapper.Map<ProcesosVentasViewModel, tbProcesosVentas>(procesosVentasViewModel); // Mapea el ViewModel a la entidad correspondiente
            var response = _procesoVentaService.InsertarProcesoVenta(modelo); // Llama al servicio para insertar el proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpPut para actualizar un proceso de venta existente
        [HttpPut("Actualizar")]
        public virtual IActionResult Update(ProcesosVentasViewModel procesosVentasViewModel)
        {
            var modelo = _mapper.Map<ProcesosVentasViewModel, tbProcesosVentas>(procesosVentasViewModel); // Mapea el ViewModel a la entidad correspondiente
            var response = _procesoVentaService.ActualizarProcesoVenta(modelo); // Llama al servicio para actualizar el proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpPut para actualizar el estado de venta de un proceso
        [HttpPut("Vender")]
        public IActionResult VenderUpdate(ProcesosVentasViewModel procesosVentasViewModel)
        {
            var modelo = _mapper.Map<ProcesosVentasViewModel, tbProcesosVentas>(procesosVentasViewModel); // Mapea el ViewModel a la entidad correspondiente
            var response = _procesoVentaService.ActualizarvenderProcesoVenta(modelo); // Llama al servicio para actualizar el estado de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpDelete para eliminar un proceso de venta por su ID
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _procesoVentaService.EliminarProcesoVenta(id); // Llama al servicio para eliminar el proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpDelete para marcar un proceso de venta como vendido
        [HttpDelete("Vendido")]
        public IActionResult Vendido(int id)
        {
            var response = _procesoVentaService.VendidoProcesoVenta(id); // Llama al servicio para marcar como vendido el proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }
    }
}
