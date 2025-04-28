using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    // Configuración de la ruta base para el controlador y especifica que es un controlador de API.
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : Controller
    {

        // Inyección de dependencias para los servicios y AutoMapper
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;

        // Constructor que inicializa los servicios y AutoMapper
        public MantenimientoController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        // Endpoint de tipo HttpGet para listar todos los clientes pro proceso de venta
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _bienRaizService.ListarClienteBienesRaices(); // Llama al servicio para obtener la lista el cliente del proceso de venta
            return Ok(response.Data); // Retorna un código 200 con la data obtenida
        }

        // Método HttpGet para buscar un cliente por DNI.
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarAgenteBienRaiz(string id)
        {
            var response = _bienRaizService.BuscarClienteBienesRaices(id); // Llama al servicio para buscar un agente específico por su ID.
            return Ok(response.Data); // Retorna un código 200 con la data obtenida.
        }

        [HttpPost("Insertar")]
        public IActionResult Create(MantenimientoViewModel mantenimientoViewModel)
        {
            var modelo = _mapper.Map<MantenimientoViewModel, tbMantenimientos>(mantenimientoViewModel); // Mapea el ViewModel a la entidad correspondiente
            var response = _bienRaizService.InsertarClienteBienesRaices(modelo); // Llama al servicio para insertar el cliente del proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpPut para actualizar un proceso de venta existente
        [HttpPut("Actualizar")]
        public IActionResult Update(MantenimientoViewModel mantenimientoViewModel)
        {
            var modelo = new tbMantenimientos()
            {
                mant_Id = Convert.ToInt32(mantenimientoViewModel.mant_Id),
                mant_DNI = mantenimientoViewModel.mant_DNI,
                mant_NombreCompleto = mantenimientoViewModel.mant_NombreCompleto,
                mant_Telefono = mantenimientoViewModel.mant_Telefono,
                usua_Modificacion = mantenimientoViewModel.usua_Modificacion,
                mant_FechaModificacion = DateTime.Now
            
            };// Mapea el ViewModel a la entidad correspondiente
            var response = _bienRaizService.ActualizarClienteBienesRaices(modelo); // Llama al servicio para actualizar el cliente del proceso de venta 
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }

        // Endpoint de tipo HttpDelete para eliminar un proceso de venta por su ID
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _bienRaizService.EliminarClienteBienesRaices(id); // Llama al servicio para eliminar el proceso de venta
            return Ok(response); // Retorna un código 200 con la respuesta del servicio
        }


    }
}
