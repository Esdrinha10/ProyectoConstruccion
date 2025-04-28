using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionDetalleController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        public CotizacionDetalleController(InsumoService generaleService, IMapper mapper)
        {
            _insumoService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCotizacionDetalles()
        {
            var response = _insumoService.ListarCotizacionDetalles();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCotizacionDetalle(int id)
        {
            var response = _insumoService.BuscarCotizacionDetalle(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(CotizacionDetalleViewModel CotizacionDetalleViewModel)
        {
            var modelo = new tbCotizacionesDetalle()
            {
                code_Cantidad = CotizacionDetalleViewModel.code_Cantidad,
                code_PrecioCompra = CotizacionDetalleViewModel.code_PrecioCompra,
                coti_Id = CotizacionDetalleViewModel.coti_Id,
                cime_Id = CotizacionDetalleViewModel.cime_Id,
                cime_InsumoOMaquinariaOEquipoSeguridad = CotizacionDetalleViewModel.cime_InsumoOMaquinariaOEquipoSeguridad,
                usua_Creacion = CotizacionDetalleViewModel.usua_Creacion,
                code_FechaCreacion = DateTime.Now,
                code_Renta = CotizacionDetalleViewModel.code_Renta
            };
            var response = _insumoService.InsertarCotizacionDetalle(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(CotizacionDetalleViewModel CotizacionDetalleViewModel)
        {
            var modelo = new tbCotizacionesDetalle()
            {
                code_Id = Convert.ToInt32(CotizacionDetalleViewModel.code_Id),
                code_Cantidad = CotizacionDetalleViewModel.code_Cantidad,
                code_PrecioCompra = CotizacionDetalleViewModel.code_PrecioCompra,
                coti_Id = CotizacionDetalleViewModel.coti_Id,
                usua_Modificacion = CotizacionDetalleViewModel.usua_Modificacion,
                code_FechaModificacion = DateTime.Now
            };
            var response = _insumoService.ActualizarCotizacionDetalle(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _insumoService.EliminarCotizacionDetalle(id);
            return Ok(response);
        }
    }
}