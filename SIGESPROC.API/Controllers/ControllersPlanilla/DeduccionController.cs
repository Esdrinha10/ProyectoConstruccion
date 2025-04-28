using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;

using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersPlanilla
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeduccionController : Controller
    {

        private readonly DeduccionService _deduccionService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="deduccionService">Servicio que maneja la lógica de negocio relacionada con las deducciones.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public DeduccionController(DeduccionService deduccionService, IMapper mapper)
        {
            _deduccionService = deduccionService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de todas las deducciones en el sistema.
        /// </summary>
        /// <returns>La lista de deducciones.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarDeducciones()
        {
            var response = _deduccionService.ListarDeduccion();

            return Ok(response.Data);
        }
        /// <summary>
        /// Busca una deducción específica por su ID.
        /// </summary>
        /// <param name="id">ID de la deducción a buscar.</param>
        /// <returns>La deducción encontrada.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarDeducciones(int? id)
        {
            var response = _deduccionService.BuscarDeduccion(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Inserta una nueva deducción en el sistema.
        /// </summary>
        /// <param name="deduccionViewModel">Modelo de vista de la deducción a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(DeduccionViewModel deduccionViewModel)
        {
            var modelo = _mapper.Map<DeduccionViewModel, tbDeducciones>(deduccionViewModel);
            var response = _deduccionService.InsertarDeduccion(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Obtiene una lista de todas las deducciones que contiene un empleado.
        /// </summary>
        /// <param name="empl_Id">ID del banco a buscar.</param>
        /// <returns>La lista de las deducciones.</returns>
        [HttpGet("BuscarDeduccionPorEmpleado/{empl_Id}")]
        public IActionResult BuscarDeduccionPorEmpleado(int empl_Id)
        {
            var response = _deduccionService.BuscarDeduccionPorEmpleado(empl_Id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Obtiene una lista de todas las deducciones que contiene un empleado.
        /// </summary>
        /// <param name="id">ID del banco a buscar.</param>
        /// <returns>La lista de las deducciones.</returns>
        [HttpGet("ListarDeduccionPorEmpleado/{id}")]
        public IActionResult ListarDeduccionPorEmpleado(int id)
        {
            var response = _deduccionService.ListarDeduccionPorEmpleado(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Asigna o remueve una deducción a un empleado.
        /// </summary>
        /// <param name="deduccionViewModel">Modelo de vista de la deducción a insertar al empleado según el empl_Id incluido en el modelo.</param>
        /// <returns>Resultado de la operación de inserción o eliminación.</returns>
        [HttpPut("ActualizarDeduccionesDelEmpleado")]
        public IActionResult ActualizarDeduccionesDelEmpleado(DeduccionPorEmpleadoViewModel deduccionPorEmpleadoViewModel)
        {
            var response = _deduccionService.DeduccionPorEmpleado(deduccionPorEmpleadoViewModel);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza una deducción existente en el sistema.
        /// </summary>
        /// <param name="deduccionViewModel">Modelo de vista de la deducción a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(DeduccionViewModel deduccionViewModel)
        {
            var modelo = _mapper.Map<DeduccionViewModel, tbDeducciones>(deduccionViewModel);
            var response = _deduccionService.ActualizarDeduccion(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina una deducción especificado por su ID.
        /// </summary>
        /// <param name="id">ID de la deducción a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _deduccionService.EliminarDeduccion(id);
            return Ok(response);
        }
    }
}

