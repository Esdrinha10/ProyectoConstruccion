using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    /// <summary>
    /// Controlador para gestionar las actividades por etapa en un proyecto.
    /// Proporciona métodos para CRUD y operaciones específicas sobre las actividades.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoProyectoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="generalService">Servicio que maneja la lógica de negocio para tp.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public TipoProyectoController(GeneralService generalService, IMapper mapper)
        {
            _mapper = mapper;
            _generalService = generalService;
        }

        /// <summary>
        /// Elimina un tipo de proyecto especificado por su ID.
        /// </summary>
        /// <param name="id">ID del tipo a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        {
            var result = _generalService.EliminarTipoProyecto(id);

            return Ok(result);
        }

        /// <summary>
        /// Busca un tipo de proyecto especificado por su ID.
        /// </summary>
        /// <param name="id">ID del tipo a buscar.</param>
        /// <returns>El tipo encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int? id)
        {
            var material = _generalService.BuscarTipoProyecto(id);

            return Ok(material);
        }

        /// <summary>
        /// Inserta un nuevo tipo de proyecto.
        /// </summary>
        /// <param name="item">Modelo de vista del tipo a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Insertar(TipoProyectoViewModel item)
        {
            var model = _mapper.Map<tbTiposProyecto>(item);

            var result = _generalService.InsertarTipoProyecto(model);

            return Ok(result);
        }

        /// <summary>
        /// Lista todos los tipos de proyecto.
        /// </summary>
        /// <param name="id">ID del tipo de proyecto.</param>
        /// <returns>Lista de tipos de proyecto.</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalService.ListarTiposProyecto();

            return Ok(list);
        }

        /// <summary>
        /// Actualiza un tipo de proyecto existente.
        /// </summary>
        /// <param name="item">Modelo de vista del tipo a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(TipoProyectoViewModel item)
        {
            var model = _mapper.Map<tbTiposProyecto>(item);

            var result = _generalService.ActualizarTipoProyecto(model);

            return Ok(result);
        }
    }
}
