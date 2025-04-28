using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public PagoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _proyectoService.ListarPagos();

            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPago(int id)
        {
            var response = _proyectoService.BuscarPago(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(PagoViewModel pagoViewModel)
        {
            var modelo = new tbPagos()
            {
                pago_Monto = pagoViewModel.pago_Monto,
                pago_Fecha = pagoViewModel.pago_Fecha,
                clie_Id = pagoViewModel.clie_Id,
                proy_Id = pagoViewModel.proy_Id,
                usua_Creacion = pagoViewModel.usua_Creacion,
                pago_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarPago(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(PagoViewModel pagoViewModel)
        {
            var modelo = new tbPagos()
            {
                pago_Id = pagoViewModel.pago_Id,
                pago_Monto = pagoViewModel.pago_Monto,
                pago_Fecha = pagoViewModel.pago_Fecha,
                clie_Id = pagoViewModel.clie_Id,
                usua_Modificacion = pagoViewModel.usua_Modificacion,
                pago_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarPago(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarPago(id);
            return Ok(response);
        }
    }
}
