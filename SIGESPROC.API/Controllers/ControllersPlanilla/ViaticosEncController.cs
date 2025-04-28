using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersPlanilla
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaticosEncController : Controller
    {

        private readonly ViaticoEncabezadoService _viaticoEncabezadoService;
        private readonly IMapper _mapper;

        public ViaticosEncController(ViaticoEncabezadoService viaticoEncabezadoService, IMapper mapper)
        {
            _viaticoEncabezadoService = viaticoEncabezadoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarViaticosEncabezados(int? usua_Id)
        {
            var response = _viaticoEncabezadoService.ListarViaticosEncabezados(usua_Id);
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarViaticoEncabezado(int id)
        {
            var response = _viaticoEncabezadoService.BuscarViaticoEncabezado(id);
            return Ok(response.Data);
        }

        [HttpGet("BuscarEncDet/{id}")]
        public IActionResult BuscarViaticoEncDet(int id)
        {
            var response = _viaticoEncabezadoService.BuscarViaticoEncDet(id);
            return Ok(response.Data);
        }
        [HttpPost("Insertar")]
        public IActionResult Create(ViaticoEncViewModel viaticoEncabezadoViewModel)
        {
            var modelo = new tbViaticosEncabezados()
            {
                //vien_SaberProyeto = viaticoEncabezadoViewModel.vien_SaberProyeto,
                vien_MontoEstimado = viaticoEncabezadoViewModel.vien_MontoEstimado,
                vien_FechaEmicion = viaticoEncabezadoViewModel.vien_FechaEmicion,
                empl_Id = viaticoEncabezadoViewModel.empl_Id,
                Proy_Id = viaticoEncabezadoViewModel.Proy_Id,
                usua_Creacion = viaticoEncabezadoViewModel.usua_Creacion,
                vien_FechaCreacion = DateTime.Now,
            };
            var response = _viaticoEncabezadoService.InsertarViaticoEncabezado(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ViaticoEncViewModel viaticoEncabezadoViewModel)
        {
            var modelo = new tbViaticosEncabezados()
            {
                vien_Id = viaticoEncabezadoViewModel.vien_Id,
                //vien_SaberProyeto = viaticoEncabezadoViewModel.vien_SaberProyeto,
                vien_MontoEstimado = viaticoEncabezadoViewModel.vien_MontoEstimado,
                //vien_TotalGastado = viaticoEncabezadoViewModel.vien_TotalGastado,
                //vien_FechaEmicion = viaticoEncabezadoViewModel.vien_FechaEmicion,
                empl_Id = viaticoEncabezadoViewModel.empl_Id,
                Proy_Id = viaticoEncabezadoViewModel.Proy_Id,
                usua_Modificacion = viaticoEncabezadoViewModel.usua_Modificacion,
                vien_FechaModificacion = DateTime.Now,
                //vien_TotalReconocido = viaticoEncabezadoViewModel.vien_TotalReconocido
            };
            var response = _viaticoEncabezadoService.ActualizarViaticoEncabezado(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int? id)
        {
            var response = _viaticoEncabezadoService.EliminarViaticoEncabezado(id);
            return Ok(response);
        }
        [HttpDelete("Finalizar/{id}")]
        public IActionResult Finalizar(int? id)
        {
            var response = _viaticoEncabezadoService.FinalizarViaticoEncabezado(id);
            return Ok(response);
        }
    }
}
