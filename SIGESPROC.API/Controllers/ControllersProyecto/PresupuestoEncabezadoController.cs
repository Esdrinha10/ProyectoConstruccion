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
    /// Controlador para gestionar el presupuesto de en un proyecto.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los presupuestos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoEncabezadoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;


        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para presupuesto.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public PresupuestoEncabezadoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los presupuesto encabezado.
        /// </summary>
        /// <param name="id">ID de la etapa del proyecto.</param>
        /// <returns>Lista de actividades por etapa.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarPresupuestosEncabezados()
        {
            var response = _proyectoService.ListarPresupuestosEncabezado();
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un presupuesto especificado por su ID.
        /// </summary>
        /// <param name="id">ID del presupuesto a buscar.</param>
        /// <returns>La actividad encontrada.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPresupuestoEncabezado(int id)
        {
            var response = _proyectoService.BuscarPresupuestoEncabezado(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta un presupuesto encabezado.
        /// </summary>
        /// <param name="item">Modelo de vista del presupuesto a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(PresupuestoEncabezadoViewModel item)
        {

            var model = _mapper.Map<tbPresupuestosEncabezado>(item);

            var result = _proyectoService.InsertarPresupuestoEncabezado(model);

            return Ok(result);

        }

        /// <summary>
        /// Actualiza un presupuesto existente.
        /// </summary>
        /// <param name="item">Modelo de vista de presupuesto a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(PresupuestoEncabezadoViewModel item)
        {
            var model = _mapper.Map<tbPresupuestosEncabezado>(item);

            var result = _proyectoService.ActualizarPresupuestosEncabezado(model);

            return Ok(result);
        }


        /// <summary>
        /// Rechaza un presupuesto específicado por el ID.
        /// </summary>
        /// <param name="item">Modelo de vista del presupuesto a rechazar.</param>
        /// <returns>Resultado de la operación de Rechazado.</returns>
        [HttpPut("Rechazado")]
        public IActionResult Rechazado(PresupuestoEncabezadoViewModel item)
        {
            var model = _mapper.Map<tbPresupuestosEncabezado>(item);

            var result = _proyectoService.RechazadoPresupuestosEncabezado(model);

            return Ok(result);
        }

        /// <summary>
        /// aprueba un presupuesto específicado por el ID del presupuesto y el proyecto.
        /// </summary>
        /// <param name="pren_Id">ID del presupuesto.</param>
        /// <param name="proy_Id">ID del proyecto.</param>
        /// <returns>Resultado de la operación de Aprobado.</returns>
        [HttpDelete("Aprobado")]
        public IActionResult Aprobado(int? pren_Id, int? proy_Id)
        {
            var response = _proyectoService.AprobadoPresupuestosEncabezado(pren_Id, proy_Id);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un presupuesto especificado por su ID.
        /// </summary>
        /// <param name="id">ID del presupuesto a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarPresupuestoEncabezado(id);
            return Ok(response);
        }
    }
}
