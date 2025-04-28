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
    /// Controlador para gestionar las operaciones sobre los encabezados de compra.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompraEncabezadoController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="insumoService">Servicio que maneja la lógica de negocio para encabezados de compra.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public CompraEncabezadoController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los encabezados de compra.
        /// </summary>
        /// <returns>Una lista de encabezados de compra.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarCompraEncabezado()
        {
            var response = _insumoService.ListarCompraEncabezado();
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Lista los métodos de pago disponibles.
        /// </summary>
        /// <returns>Una lista de métodos de pago.</returns>
        [HttpGet("ListarPagos")]
        public IActionResult ListarMetodosPago()
        {
            var response = _insumoService.ListarMetodosPago();
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Lista los encabezados de compra en un rango de fechas específico.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una lista de encabezados de compra en el rango de fechas especificado.</returns>
        [HttpGet("ListarFechas")]
        public IActionResult ListarFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var response = _insumoService.FindFechas(fechaInicio, fechaFin);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Busca un encabezado de compra por el ID de cotización.
        /// </summary>
        /// <param name="coti_Id">ID de la cotización.</param>
        /// <returns>El encabezado de compra asociado a la cotización.</returns>
        [HttpGet("BuscarPorCotizacion/{coti_Id}")]
        public IActionResult BuscarPorCotizacion(int coti_Id)
        {
            var response = _insumoService.FindByCotizacionId(coti_Id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Busca un detalle de cotización por el ID de compra.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra.</param>
        /// <returns>El detalle de cotización asociado al encabezado de compra.</returns>
        [HttpGet("BuscarPorDetalleCotizacion/{coen_Id}")]
        public IActionResult BuscarPorDetallePorCotizacion(string coen_Id)
        {
            var response = _insumoService.FindByCotizacionCompraDetalleId(coen_Id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Busca un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>El encabezado de compra encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNiveles(int id)
        {
            var response = _insumoService.BuscarCompraEncabezado(id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Inserta un nuevo encabezado de compra.
        /// </summary>
        /// <param name="CompraEncabezadoViewModel">Modelo de vista del encabezado de compra a insertar.</param>
        /// <returns>El resultado de la operación de inserción.</returns>
        [HttpPost("InsertarCompraEncabezado")]
        public IActionResult InsertarCompraEncabezado([FromBody] CompraEncabezadoViewModel CompraEncabezadoViewModel)
        {
            var modeloEncabezado = new tbComprasEncabezado()
            {
                empl_Id = CompraEncabezadoViewModel.empl_Id,
                meto_Id = CompraEncabezadoViewModel.meto_Id,
                usua_Creacion = CompraEncabezadoViewModel.usua_Creacion,
                coen_FechaCreacion = DateTime.Now
            };
            var responseEncabezado = _insumoService.InsertarCompraEncabezado(modeloEncabezado);

            if (responseEncabezado.Data == 0)
            {
                return BadRequest("Error al insertar el encabezado de la compra.");
            }

            return Ok(responseEncabezado);
        }

        /// <summary>
        /// Inserta una nueva compra con detalles.
        /// </summary>
        /// <param name="detalles">Lista de detalles de la compra.</param>
        /// <returns>El resultado de la operación de inserción.</returns>
        [HttpPost("InsertarCompra")]
        public IActionResult Create(List<CompraDetalleViewModel> detalles)
        {
            var coen_Id = "";
            var identi = -1;
            if (detalles.Count > 0)
            {
                var id = 0;
                foreach (var item in detalles)
                {
                    
                    if (item.identificador != identi)
                    {
                       
                        var modelo = new tbComprasEncabezado()
                        {
                            empl_Id = detalles[0].empl_Id,
                            meto_Id = detalles[0].meto_Id,
                            coen_numeroCompra = detalles[0].coen_numeroCompra,
                            usua_Creacion = detalles[0].usua_Creacion,
                            coen_FechaCreacion = DateTime.Now
                        };
                        var response = _insumoService.InsertarCompraEncabezado(modelo);
                        identi = item.identificador;
                        coen_Id += response.Data.CodeStatus + ",";
                        id =Convert.ToInt32(response.Data.CodeStatus);
                    }

                    var modelo2 = new tbComprasDetalle()
                    {
                        code_Id = item.code_Id,
                        coen_Id =Convert.ToInt32(id),
                        codt_cantidad = item.codt_cantidad,
                        codt_preciocompra = item.codt_preciocompra,
                        codt_InsumoOMaquinariaOEquipoSeguridad = item.codt_InsumoOMaquinariaOEquipoSeguridad,
                        codt_Renta = item.codt_Renta,
                        usua_Creacion = item.usua_Creacion,
                        codt_FechaCreacion = DateTime.Now
                    };
                    _insumoService.InsertarCompraDetalle(modelo2);
                }

                    return Ok(new { coen_Id = coen_Id, Message = "Success" });
            }
            return BadRequest("No details provided");
        }

        /// <summary>
        /// Actualiza un encabezado de compra existente.
        /// </summary>
        /// <param name="item">Modelo de vista del encabezado de compra a actualizar.</param>
        /// <returns>El resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(CompraEncabezadoViewModel item)
        {
            var modelo = _mapper.Map<tbComprasEncabezado>(item);

            var response = _insumoService.ActualizarCompraEncabezado(modelo);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }


        /// <summary>
        /// Actualiza un encabezado de compra existente.
        /// </summary>
        /// <param name="item">Modelo de vista del encabezado de compra a actualizar.</param>
        /// <returns>El resultado de la operación de actualización.</returns>
        [HttpPut("ActualizarCompra")]
        public IActionResult UpdateCompra(CompraEncabezadoViewModel item)
        {
            var modelo = _mapper.Map<tbComprasEncabezado>(item);

            var response = _insumoService.ActualizarCompraEncabezadoNumero(modelo);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Elimina un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra a eliminar.</param>
        /// <returns>El resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(string id)
        {
            var response = _insumoService.EliminarCompraEncabezado(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }

        /// <summary>
        /// Elimina una compra completa por su ID de encabezado.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra a eliminar.</param>
        /// <returns>El resultado de la operación de eliminación.</returns>
        [HttpDelete("EliminarCompra/{coen_Id}")]
        public IActionResult EliminarCompra(string coen_Id)
        {
            var response = _insumoService.EliminarCompra(coen_Id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Problem(response.Data);
            }
        }

        /// <summary>
        /// Verifica si un número de compra es único para una cotización dada.
        /// </summary>
        /// <param name="coen_numeroCompra">Número de compra a verificar.</param>
        /// <param name="coti_Id">ID de la cotización asociada.</param>
        /// <returns>Resultado de la verificación (1 si es único, 0 si está duplicado).</returns>
        [HttpGet("VerificarNumeroCompraUnico")]
        public IActionResult VerificarNumeroCompraUnico(string coen_numeroCompra, int prov_Id)
        {
            var response = _insumoService.VerificarNumeroCompraUnico(coen_numeroCompra, prov_Id);
            if (response.Success)
            {
                return Ok(response.Data);  // Data contendrá el valor 0 o 1
            }
            else
            {
                return Problem(response.Data.ToString());  // Error de ejecución
            }
        }

    }
}
