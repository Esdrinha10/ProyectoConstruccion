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
    /// <summary>
    /// Controlador para gestionar los Costo por Actividad.
    /// Proporciona métodos para CRUD y operaciones específicas sobre los costos por actividad.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CostoPorActividadController : Controller
    {
        private readonly CostoPorActividadService _costoPorActividadService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="costoPorActividadService">Servicio que maneja la lógica de negocio para Costo por Actividad.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public CostoPorActividadController(CostoPorActividadService costoPorActividadService, IMapper mapper)
        {
            _costoPorActividadService = costoPorActividadService;
            _mapper = mapper;
        }
        /// <summary>
        /// <returns>Lista de Costo por Actividad.</returns>

        [HttpGet("Listar")]
        public IActionResult ListarNiveles()
        {
            var response = _costoPorActividadService.ListarCostoActividad();

            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un costo por actividad por su Id.
        /// </summary>
        /// <param name="id">Id del costo por actividad a buscar.</param>
        /// <returns>La Bien raiz encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCostoActividad(int? id)
        {
            var response = _costoPorActividadService.BuscarCostoActividad(id);

            return Ok(response.Data);
        }
        /// <summary>
        /// Inserta una nuevo costo por Actividad.
        /// </summary>
        /// <param name="item">Modelo de vista del costo por Actividad a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>

        [HttpPost("Insertar")]

        public IActionResult Create(CostoPorActividadViewModel DedViewModel)
        {

            var modelo = new tbCostoPorActividad()
            {
                unme_Id = DedViewModel.unme_Id,
                acti_Id = DedViewModel.acti_Id,
                copc_Valor = DedViewModel.copc_Valor,
                usua_Creacion = DedViewModel.usua_Creacion,
                copc_FechaCreacion = DateTime.Now
            };
            var response = _costoPorActividadService.InsertarCostoActividad(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un costo por actividad existente.
        /// </summary>
        /// <param name="item">Modelo de vista de costo por actividad a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>

        [HttpPut("Actualizar")]
        public IActionResult Update(CostoPorActividadViewModel DedViewModel)
        {

            var modelo = new tbCostoPorActividad()
            {
                copc_Id = DedViewModel.copc_Id,
                unme_Id = DedViewModel.unme_Id,
                acti_Id = DedViewModel.acti_Id,
                copc_Valor = DedViewModel.copc_Valor,
                usua_Modificacion = DedViewModel.usua_Modificacion,
                copc_FechaModificacion = DateTime.Now
            };
            var response = _costoPorActividadService.ActualizarCostoActividad(modelo);
            return Ok(response);
        }


        /// <summary>
        /// Elimina un costo por actividad especificado por su Id.
        /// </summary>
        /// <param name="id">Id del costo por actividad a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>

        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        {

            var result = _costoPorActividadService.EliminarCostoActividad(id);

            return Ok(result);
        }
    }
}
