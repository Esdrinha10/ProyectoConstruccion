using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador PaisController.
        /// </summary>
        /// <param name="generalService">Servicio general para manejar la lógica de negocio relacionada con países</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades</param>
        public PaisController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint para listar todos los países.
        /// </summary>
        /// <returns>Lista de países</returns>
        [HttpGet("Listar")]
        public IActionResult ListarPaises()
        {
            var response = _generalService.ListarPaises();
            return Ok(response);
        }

        /// <summary>
        /// Endpoint para obtener un dropdown de países.
        /// </summary>
        /// <returns>Datos para el dropdown de países</returns>
        [HttpGet("DropDownPaises")]
        public IActionResult DropDownPaises()
        {
            var response = _generalService.DropDownPaises();
            return Ok(response.Data);
        }

        /// <summary>
        /// Endpoint para buscar un país por su ID.
        /// </summary>
        /// <param name="id">ID del país a buscar</param>
        /// <returns>El país encontrado</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPaises(int id)
        {
            var response = _generalService.BuscarPaises(id);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint para insertar un nuevo país.
        /// </summary>
        /// <param name="PaisViewModel">Modelo de vista del país a insertar</param>
        /// <returns>Resultado de la operación de inserción</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(PaisViewModel PaisViewModel)
        {
            var modelo = new tbPaises()
            {
                pais_Nombre = PaisViewModel.pais_Nombre,
                pais_Codigo = PaisViewModel.pais_Codigo,
                pais_Prefijo = PaisViewModel.pais_Prefijo,
                usua_Creacion = PaisViewModel.usua_Creacion,
                pais_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarPaises(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint para actualizar un país existente.
        /// </summary>
        /// <param name="PaisViewModel">Modelo de vista del país a actualizar</param>
        /// <returns>Resultado de la operación de actualización</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(PaisViewModel PaisViewModel)
        {
            var modelo = new tbPaises()
            {
                pais_Id = Convert.ToInt32(PaisViewModel.pais_Id),
                pais_Nombre = PaisViewModel.pais_Nombre,
                pais_Codigo = PaisViewModel.pais_Codigo,
                pais_Prefijo = PaisViewModel.pais_Prefijo,
                usua_Modificacion = PaisViewModel.usua_Modificacion,
                pais_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarPaises(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint para eliminar un país por su ID.
        /// </summary>
        /// <param name="id">ID del país a eliminar</param>
        /// <returns>Resultado de la operación de eliminación</returns>
        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int? id)
        {
            var response = _generalService.EliminarPaises(id);
            return Ok(response);
        }
    }
}
