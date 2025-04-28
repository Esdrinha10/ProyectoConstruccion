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


    public class PresupuestoPorTasaCambioController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="proyectoService">Servicio que maneja la lógica de negocio para presupuesto.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public PresupuestoPorTasaCambioController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas las tasas de cambio de presupuesto.
        /// </summary>
        /// <param name="id">ID del presupuesto encabezado.</param>
        /// <returns>Lista de tasas de cambio del presupuesto.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult ListarPresupuestosPorTasasCambio(int id)
        {
            var response = _proyectoService.ListarPresupuestosPorTasasCambio(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta una tasa de cambio de presupuesto.
        /// </summary>
        /// <param name="item">Modelo de vista de tasa de cambio del presupuesto a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(PresupuestoPorTasaCambioViewModel PresupuestoPorTasaCambioViewModel)
        {
            var modelo = new tbPresupuestosPorTasasCambio()
            {
                pren_Id = PresupuestoPorTasaCambioViewModel.pren_Id,
                taca_Id = PresupuestoPorTasaCambioViewModel.taca_Id,
                usua_Creacion = PresupuestoPorTasaCambioViewModel.usua_Creacion,
                pptc_FechaCreacion = DateTime.Now
            };

            var response = _proyectoService.InsertarPresupuestoPorTasaCambio(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza una tasa de cambio de presupuesto existente.
        /// </summary>
        /// <param name="item">Modelo de vista de tasa de cambio de presupuesto a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(PresupuestoPorTasaCambioViewModel PresupuestoPorTasaCambioViewModel)
        {
            var modelo = new tbPresupuestosPorTasasCambio()
            {
                pptc_Id = PresupuestoPorTasaCambioViewModel.pptc_Id,
                pren_Id = PresupuestoPorTasaCambioViewModel.pren_Id,
                taca_Id = PresupuestoPorTasaCambioViewModel.taca_Id,
                usua_Modificacion = PresupuestoPorTasaCambioViewModel.usua_Modificacion,
            };
            var response = _proyectoService.ActualizarPresupuestoPorTasaCamvbio(modelo);
            return Ok(response);
        }


        /// <summary>
        /// Elimina una tasa de cambio de presupuesto especificado por su ID.
        /// </summary>
        /// <param name="id">ID de la tasa de cambio de presupuesto a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarPresupuestoPorTasaCambio(id);
            return Ok(response);
        }
    }
}
