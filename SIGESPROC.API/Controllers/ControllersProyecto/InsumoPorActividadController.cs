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
    /// Controlador para gestionar los insumos en un actividad.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los insumos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoPorActividadController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para insumos por actividad.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public InsumoPorActividadController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los insumos de una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Lista de insumos por actividad.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult Listar(int? id)
        {
            var list = _proyectoService.ListarInsumosPorActividad(id);

            return Ok(list);
        }
        [HttpGet("ListarPresupuestos")]
        public IActionResult ListarPresupuestosInsumosPorActividad(int id)
        {
            var response = _proyectoService.ListarPresupuestosInsumosPorActividad(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(InsumoPorActividadViewModel InsumoPorActividadViewModel)
        {
            var modelo = _mapper.Map<InsumoPorActividadViewModel, tbInsumosPorActividades>(InsumoPorActividadViewModel);
            var response = _proyectoService.InsertarInsumoPorActividad(modelo);
            return Ok(response);
        }
        [HttpPut("Actualizar")]
        public IActionResult Update(InsumoPorActividadViewModel InsumoPorActividadViewModel)
        {
            var modelo = _mapper.Map<InsumoPorActividadViewModel, tbInsumosPorActividades>(InsumoPorActividadViewModel);
            var response = _proyectoService.ActualizarInsumoPorActividad(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarInsumoPorActividad(id);
            return Ok(response);
        }


    }
}
