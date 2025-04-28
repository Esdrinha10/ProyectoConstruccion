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
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con los detalles de compra.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompraDetalleController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="insumoService">Servicio de lógica de negocios para detalles de compra.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public CompraDetalleController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los detalles de compra disponibles.
        /// </summary>
        /// <returns>Una respuesta con la lista de detalles de compra.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarCompraDetalle()
        {
            var response = _insumoService.ListarCompraDetalle();
            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Lista los detalles de compra para un destino específico.
        /// </summary>
        /// <param name="id">ID del detalle de compra.</param>
        /// <returns>Una respuesta con la lista de detalles de compra para el destino.</returns>
        [HttpGet("ListarDestino/{id}")]
        public IActionResult ListarCompraDetalleDestino(int id)
        {
            var response = _insumoService.ListarCompraDetalleDestino(id);
            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Lista los detalles de compra para un destino de maquinaria específico.
        /// </summary>
        /// <param name="id">ID del detalle de compra de maquinaria.</param>
        /// <returns>Una respuesta con la lista de detalles de compra para el destino de maquinaria.</returns>
        [HttpGet("ListarDestinoMaquinaria/{id}")]
        public IActionResult ListarCompraDetalleDestinoMaquinaria(int id)
        {
            var response = _insumoService.ListarCompraDetalleDestinoMaquinaria(id);
            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Busca un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra.</param>
        /// <returns>Una respuesta con el detalle de compra encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCompraDetalle(int id)
        {
            var response = _insumoService.BuscarCompraDetalle(id);
            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Busca los detalles de compra asociados a un encabezado de compra específico.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>Una respuesta con la lista de detalles de compra.</returns>
        [HttpGet("FiltroDetalleEncabezado/{id}")]
        public IActionResult BuscarCompraDetalleEncabezado(int id)
        {
            var response = _insumoService.BuscarCompraDetalleEncabezado(id);
            if (response.Success == true)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Lista las actividades por etapas relacionadas con un ID de compra.
        /// </summary>
        /// <param name="id">ID del proyecto o etapa.</param>
        /// <returns>Una respuesta con la lista de actividades por etapas.</returns>
        [HttpGet("ListarActividadesPorEtapaFill/{id}")]
        public IActionResult ListarActividadesPorEtapa(int id)
        {
            var response = _insumoService.ListarActividadesPorEtapas(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un detalle de compra con destino por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino.</param>
        /// <returns>Una respuesta con el detalle de compra con destino encontrado.</returns>
        [HttpGet("BuscarDestino/{id}")]
        public IActionResult BuscarCompraDetalleDestino(int id)
        {
            var response = _insumoService.BuscarCompraDetalleDestino(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra a insertar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("Insertar")]
        public IActionResult InsertarCompraDetalle(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.InsertarCompraDetalle(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra asociado a un destino.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con destino a insertar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("InsertarDestino")]
        public IActionResult InsertarCompraDetalleDestino(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.InsertarCompraDetalleDestino(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino exacto.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con destino exacto a insertar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("InsertarDestinoExacto")]
        public IActionResult InsertarCompraDetalleDestinoExacto(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.InsertarCompraDetalleDestinoExacto(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra asociado a un proyecto por defecto.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con proyecto a insertar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("InsertarDestinoPorProyecto")]
        public IActionResult InsertarCompraDetalleDestinoPorProyectoDefecto(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.InsertarCompraDetalleDestinoPorProyectoPorDefecto(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, response.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino exacto asociado a un proyecto.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con destino exacto a insertar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("InsertarDestinoProyectoExacto")]
        public IActionResult InsertarCompraDetalleDestinoProyectoExacto(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.InsertarCompraDetalleDestinoPorProyecto(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Elimina un detalle de compra de maquinaria por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra de maquinaria a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpDelete("EliminarDestinoMaquinaria/{id}")]
        public IActionResult EliminarCompraDetalleDireccionMaquinaria(int id)
        {
            var response = _insumoService.EliminarCompraDetalleDestinoMaquinaria(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino por defecto.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con destino a actualizar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPut("ActualizarDestinoDefecto")]
        public IActionResult ActualizarCompraDetalleDestinoDefecto(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.ActualizarCompraDetalleDestinoDefecto(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra en la base de datos.
        /// </summary>
        /// <param name="items">Lista de modelos de vista que contienen los datos de los detalles de compra a actualizar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPut("Actualizar")]
        public IActionResult ActualizarCompraDetalle(List<CompraDetalleViewModel> items)
        {
            foreach (var item in items)
            {
                var modelo = _mapper.Map<tbComprasDetalle>(item);
                var response = _insumoService.ActualizarCompraDetalle(modelo);
                if (!response.Success)
                {
                    return Problem();
                }
            }
            return Ok(new { Success = true });
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino.
        /// </summary>
        /// <param name="item">Modelo de vista que contiene los datos del detalle de compra con destino a actualizar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPut("ActualizarDestino")]
        public IActionResult ActualizarCompraDetalleDestino(CompraDetalleViewModel item)
        {
            var modelo = _mapper.Map<tbComprasDetalle>(item);
            var response = _insumoService.ActualizarCompraDetalleDestino(modelo);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Elimina un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpDelete("Eliminar/{id}")]
        public IActionResult EliminarCompraDetalle(int id)
        {
            var response = _insumoService.EliminarCompraDetalle(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Elimina un detalle de compra con destino por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpDelete("EliminarDestino/{id}")]
        public IActionResult EliminarCompraDetalleDestino(int id)
        {
            var response = _insumoService.EliminarCompraDetalleDestino(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }
    }
}
