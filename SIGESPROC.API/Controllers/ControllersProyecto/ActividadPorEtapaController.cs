using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    /// <summary>
    /// Controlador para gestionar las actividades por etapa en un proyecto.
    /// Proporciona métodos para CRUD y operaciones específicas sobre las actividades.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ActividadPorEtapaController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para actividades por etapa.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public ActividadPorEtapaController(ProyectoService proyectoService, IMapper mapper)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;
        }

        /// <summary>
        /// Elimina una actividad por etapa especificada por su ID.
        /// </summary>
        /// <param name="id">ID de la actividad a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            var result = _proyectoService.EliminarActividadPorEtapa(id);

            return Ok(result);
        }

        /// <summary>
        /// Busca una actividad por etapa especificada por su ID.
        /// </summary>
        /// <param name="id">ID de la actividad a buscar.</param>
        /// <returns>La actividad encontrada.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int? id)
        {
            var material = _proyectoService.BuscarActividadPorEtapa(id);

            return Ok(material);
        }

        /// <summary>
        /// Inserta una nueva actividad por etapa.
        /// </summary>
        /// <param name="item">Modelo de vista de la actividad a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Insertar(ActividadPorEtapaViewModel item)
        {
            var model = _mapper.Map<tbActividadesPorEtapas>(item);

            var result = _proyectoService.InsertarActividadPorEtapa(model);

            return Ok(result);
        }

        /// <summary>
        /// Lista todas las actividades por etapa relacionadas a una etapa de proyecto específica.
        /// </summary>
        /// <param name="id">ID de la etapa del proyecto.</param>
        /// <returns>Lista de actividades por etapa.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult Listar(int? id)
        {
            var list = _proyectoService.ListarActividadesPorEtapa(id);

            return Ok(list);
        }

        [HttpGet("ListarInsumos/{id}")]
        public IActionResult ListarInsumos(int? id)
        {
            var list = _proyectoService.ListarInsumosPorProveedores(id);

            return Ok(list);
        }

        [HttpGet("ListarMaquinarias/{id}")]
        public IActionResult ListarMaquinarias(int? id)
        {
            var list = _proyectoService.ListarMaquinariasPorProveedores(id);

            return Ok(list);
        }

        [HttpGet("ListarEquiposSeguridad")]
        public IActionResult ListarEquiposSeguridad()
        {
            var list = _proyectoService.ListarEquiposSeguridadPorProveedores();

            return Ok(list);
        }


        [HttpGet("ListarActividad")]
        public IActionResult ListarActividad()
        {
            var response = _proyectoService.ListarActividad();
            return Ok(response.Data);
        }

        /// <summary>
        /// Actualiza una actividad por etapa existente.
        /// </summary>
        /// <param name="item">Modelo de vista de la actividad a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(ActividadPorEtapaViewModel item)
        {
            var model = _mapper.Map<tbActividadesPorEtapas>(item);

            var result = _proyectoService.ActualizarActividadPorEtapa(model);

            return Ok(result);
        }

        /// <summary>
        /// Replica las actividades de una etapa de proyecto en otra.
        /// </summary>
        /// <param name="item">Modelo de vista de la etapa del proyecto a replicar.</param>
        /// <returns>Resultado de la operación de replicación.</returns>
        [HttpPost("Replicar")]
        public IActionResult Replicar(EtapaPorProyectoViewModel item)
        {
            var model = _mapper.Map<tbEtapasPorProyectos>(item);

            var result = _proyectoService.ReplicarActividadesPorEtapa(model);

            return Ok(result);
        }

        /// <summary>
        /// Autocompleta la información de una actividad por etapa.
        /// </summary>
        /// <param name="id">ID de la actividad a autocompletar.</param>
        /// <returns>La actividad autocompletada.</returns>
        [HttpGet("AutoCompletar/{id}")]
        public IActionResult AutoCompletar(int? id)
        {
            var result = _proyectoService.AutoCompletarActividadesPorEtapa(id);

            return Ok(result);
        }
    }
}
