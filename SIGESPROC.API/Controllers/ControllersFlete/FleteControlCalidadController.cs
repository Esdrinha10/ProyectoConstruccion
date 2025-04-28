using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
using SIGESPROC.Common.Models.ModelsFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersFlete
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleteControlCalidadController : Controller
    {
        private readonly FleteControlCalidadService _fleteControlCalidadService;
        private readonly IMapper _mapper;

        public FleteControlCalidadController(FleteControlCalidadService fleteControlCalidadService, IMapper mapper)
        {
            _fleteControlCalidadService = fleteControlCalidadService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarNiveles()
        {
            var response = _fleteControlCalidadService.ListarFleteControlCalidad();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNiveles(int id)
        {
            var response = _fleteControlCalidadService.BuscarFleteControlCalidad(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(FleteControlCalidadViewModel FletViewModel)
        {
            var modelo = new tbFletesControlCalidad()
            {
                flcc_DescripcionIncidencia = FletViewModel.flcc_DescripcionIncidencia,
                flcc_FechaHoraIncidencia = FletViewModel.flcc_FechaHoraIncidencia,
                flen_Id = FletViewModel.flen_Id,
                usua_Creacion = FletViewModel.usua_Creacion,
                flcc_FechaCreacion = DateTime.Now
            };
            var response = _fleteControlCalidadService.InsertarFleteControlCalidad(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(FleteControlCalidadViewModel FletViewModel)
        {
            var modelo = new tbFletesControlCalidad()
            {
                flcc_Id = FletViewModel.flcc_Id,
                flcc_DescripcionIncidencia = FletViewModel.flcc_DescripcionIncidencia,
                flcc_FechaHoraIncidencia = FletViewModel.flcc_FechaHoraIncidencia,
                flen_Id = FletViewModel.flen_Id,
                usua_Modificacion = FletViewModel.usua_Modificacion,
                flcc_FechaModificacion = DateTime.Now
            };
            var response = _fleteControlCalidadService.ActualizarFleteControlCalidad(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _fleteControlCalidadService.EliminarFleteControlCalidad(id);
            return Ok(response);
        }

        [HttpGet("BuscarIncidencias/{id}")]
        public IActionResult BuscarIncidencias(int id)
        {
            var response = _fleteControlCalidadService.BuscarFleteControlCalidadIncidencias(id);
            return Ok(response.Data);
        }

    }
}
