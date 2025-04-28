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
    /// Controlador para gestionar el detalle de presupuesto de en un proyecto.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los detalles de presupuestos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoDetalleController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para presupuesto.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public PresupuestoDetalleController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los detalles de presupuesto.
        /// </summary>
        /// <param name="id">ID del presupuesto encabezado.</param>
        /// <returns>Lista de detalles del presupuesto.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult ListarPresupuestosDetalles(int id)
        {
            var response = _proyectoService.ListarPresupuestosDetalle(id);
            return Ok(response.Data);
        }


        /// <summary>
        /// Inserta un detalle de presupuesto.
        /// </summary>
        /// <param name="item">Modelo de vista del detalle presupuesto a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(PresupuestoDetalleViewModel item)
        {
            var model = _mapper.Map<tbPresupuestosDetalle>(item);

            var result = _proyectoService.InsertarPresupuestoDetalle(model);

            return Ok(result);
        }

        /// <summary>
        /// Actualiza un detalle de presupuesto existente.
        /// </summary>
        /// <param name="item">Modelo de vista de detalle de presupuesto a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(PresupuestoDetalleViewModel item)
        {
            var model = _mapper.Map<tbPresupuestosDetalle>(item);

            var result = _proyectoService.ActualizarPresupuestosDetalle(model);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un detalle de presupuesto especificado por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de presupuesto a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarPresupuestoDetalle(id);
            return Ok(response);
        }
    }
}
