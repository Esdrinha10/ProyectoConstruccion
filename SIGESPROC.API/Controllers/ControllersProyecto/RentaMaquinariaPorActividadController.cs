using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    /// <summary>
    /// Controlador para gestionar la renta de maquinaria en un actividad.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los insumos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RentaMaquinariaPorActividadController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para renta de maquinaria por actividad.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public RentaMaquinariaPorActividadController(ProyectoService proyectoService, IMapper mapper)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(int id)
        {
            var result = _proyectoService.EliminarRentaMaquinariaPorActividad(id);

            return Ok(result);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(RentaMaquinariaPorActividadViewModel item)
        {
            var model = _mapper.Map<tbRentaMaquinariasPorActividades>(item);

            var result = _proyectoService.InsertarRentaMaquinariaPorActividad(model);

            return Ok(result);
        }
        /// <summary>
        /// Lista todos las rentas de maquinaria de una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Lista de renta de maquinaria por actividad.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult Listar(int? id)
        {
            var list = _proyectoService.ListarRentaMaquinariasPorActividad(id);
            return Ok(list);
        }

        [HttpGet("ListarPresupuesto")]
        public IActionResult ListarPresupuesto(int id)
        {
            var list = _proyectoService.ListarPresupuestoRentaMaquinariasPorActividades(id);

            return Ok(list.Data);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar(RentaMaquinariaPorActividadViewModel item)
        {
            var model = _mapper.Map<tbRentaMaquinariasPorActividades>(item);

            var result = _proyectoService.ActualizarRentaMaquinariaPorActividad(model);

            return Ok(result);
        }
    }
}
