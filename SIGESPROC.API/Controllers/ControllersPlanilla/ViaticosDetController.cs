using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViaticosDetController : Controller
    {
        private readonly ViaticoDetalleService _viaticoDetalleService;
        private readonly IMapper _mapper;

        public ViaticosDetController(ViaticoDetalleService viaticoDetalleService, IMapper mapper)
        {
            _viaticoDetalleService = viaticoDetalleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarViaticosDetalles()
        {
            var response = _viaticoDetalleService.ListarViaticosDetalles();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarViaticoDetalle(int id)
        {
            var response = _viaticoDetalleService.BuscarViaticoDetalle(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ViaticoDetViewModel viaticoDetalleViewModel)
        {
            var modelo = new tbViaticosDetalles()
            {
                vide_Descripcion = viaticoDetalleViewModel.vide_Descripcion,
                vide_ImagenFactura = viaticoDetalleViewModel.vide_ImagenFactura,
                vide_MontoGastado = viaticoDetalleViewModel.vide_MontoGastado,
                vien_Id = viaticoDetalleViewModel.vien_Id,
                cavi_Id = viaticoDetalleViewModel.cavi_Id,
                usua_Creacion = viaticoDetalleViewModel.usua_Creacion,
                vide_FechaCreacion = DateTime.Now,
                vide_MontoReconocido = viaticoDetalleViewModel.vide_MontoReconocido
            };
            var response = _viaticoDetalleService.InsertarViaticoDetalle(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ViaticoDetViewModel viaticoDetalleViewModel)
        {
            var modelo = new tbViaticosDetalles()
            {
                vide_Id = viaticoDetalleViewModel.vide_Id,
                vide_Descripcion = viaticoDetalleViewModel.vide_Descripcion,
                vide_ImagenFactura = viaticoDetalleViewModel.vide_ImagenFactura,
                vide_MontoGastado = viaticoDetalleViewModel.vide_MontoGastado,
                vien_Id = viaticoDetalleViewModel.vien_Id,
                cavi_Id = viaticoDetalleViewModel.cavi_Id,
                usua_Modificacion = viaticoDetalleViewModel.usua_Modificacion,
                vide_FechaModificacion = DateTime.Now,
                vide_MontoReconocido = viaticoDetalleViewModel.vide_MontoReconocido
            };
            var response = _viaticoDetalleService.ActualizarViaticoDetalle(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _viaticoDetalleService.EliminarViaticoDetalle(id);
            return Ok(response);
        }
    }
}
