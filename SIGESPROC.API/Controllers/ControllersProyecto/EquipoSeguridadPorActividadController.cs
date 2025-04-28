using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    /// <summary>
    /// Controlador para gestionar el equipo de seguridad en un actividad.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los equipos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoSeguridadPorActividadController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para equipos de seguridad por actividad.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public EquipoSeguridadPorActividadController(ProyectoService proyectoService, IMapper mapper)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;
        }

        /// <summary>
        /// Lista todos los equipos de seguridad de una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Lista de equipos de seguridad por actividad.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult Listar(int? id)
        {
            var list = _proyectoService.ListarEquiposSeguridadPorActividad(id);

            return Ok(list);
        }
    }
}
