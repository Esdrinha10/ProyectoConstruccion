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
    public class ProveedorController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="insumoService">Servicio que maneja la lógica de negocio relacionada con los insumos y proveedores.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public ProveedorController(InsumoService insumoService, IMapper mapper)
        {
            _mapper = mapper;
            _insumoService = insumoService;
        }

        /// <summary>
        /// Elimina un proveedor especificado por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            var result = _insumoService.EliminarProveedor(id);

            return Ok(result);
        }


        /// <summary>
        /// Busca un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor a buscar.</param>
        /// <returns>El proveedor encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int? id)
        {
            var proveedor = _insumoService.BuscarProveedor(id);

            return Ok(proveedor);
        }

        /// <summary>
        /// Inserta un nuevo proveedor en el sistema.
        /// </summary>
        /// <param name="item">Modelo de vista del proveedor a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Insertar(ProveedorViewModel item)
        {
    
            var model = _mapper.Map<tbProveedores>(item);

      
            var result = _insumoService.InsertarProveedor(model);

 
            return Ok(result);
        }


        /// <summary>
        /// Obtiene una lista de todos los proveedores en el sistema.
        /// </summary>
        /// <returns>La lista de proveedores.</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _insumoService.ListarProveedores();
            return Ok(list);
        }
        /// <summary>
        /// Actualiza un proveedor existente en el sistema.
        /// </summary>
        /// <param name="item">Modelo de vista del proveedor a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(ProveedorViewModel item)
        {
            var model = _mapper.Map<tbProveedores>(item);
            var result = _insumoService.ActualizarProveedor(model);
            return Ok(result);
        }


    }
}
