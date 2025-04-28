using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        // Servicio de insumos para manejar la lógica de negocio
        private readonly InsumoService _insumoService;

        // Mapper para convertir entre modelos de vista y entidades
        private readonly IMapper _mapper;

        // Constructor del controlador, con inyección de dependencias
        public MaterialController(InsumoService insumoService, IMapper mapper)
        {
            _mapper = mapper;
            _insumoService = insumoService;
        }

        /// <summary>
        /// Endpoint para eliminar un material por su ID.
        /// </summary>
        /// <param name="id">ID del material a eliminar</param>
        /// <returns>Resultado de la operación de eliminación</returns>
        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        {
            var result = _insumoService.EliminarMaterial(id);
            return Ok(result);
        }

        /// <summary>
        /// Endpoint para buscar un material por su ID.
        /// </summary>
        /// <param name="id">ID del material a buscar</param>
        /// <returns>El material encontrado</returns>
        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(int? id)
        {
            var material = _insumoService.BuscarMaterial(id);
            return Ok(material);
        }

        /// <summary>
        /// Endpoint para insertar un nuevo material.
        /// </summary>
        /// <param name="item">Modelo de vista del material a insertar</param>
        /// <returns>Resultado de la operación de inserción</returns>
        [HttpPost("Insertar")]
        public IActionResult Insertar(MaterialViewModel item)
        {
            var model = _mapper.Map<tbMateriales>(item);
            var result = _insumoService.InsertarMaterial(model);
            return Ok(result);
        }

        /// <summary>
        /// Endpoint para listar todos los materiales.
        /// </summary>
        /// <returns>Lista de materiales</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _insumoService.ListarMateriales();

            return Ok(list);
        }

        /// <summary>
        /// Endpoint para actualizar un material existente.
        /// </summary>
        /// <param name="item">Modelo de vista del material a actualizar</param>
        /// <returns>Resultado de la operación de actualización</returns>
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(MaterialViewModel item)
        {
            var model = _mapper.Map<tbMateriales>(item);
            var result = _insumoService.ActualizarMaterial(model);
            return Ok(result);
        }
    }
}
