    using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionAdicionalController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public GestionAdicionalController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarGestionAdicional()
        {
            var response = _proyectoService.ListarGestionAdicional();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarGestionAdicional(int id)
        {
            var response = _proyectoService.BuscarGestionAdicional(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(GestionAdicionalViewModel GestionAdicionalViewModel)
        {
            var modelo = _mapper.Map<GestionAdicionalViewModel, tbGestionesAdicionales>(GestionAdicionalViewModel);
            var response = _proyectoService.InsertarGestionAdicional(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(GestionAdicionalViewModel GestionAdicionalViewModel)
        {
            var modelo = _mapper.Map<GestionAdicionalViewModel, tbGestionesAdicionales>(GestionAdicionalViewModel);
            var response = _proyectoService.ActualizarGestionAdicional(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarGestionAdicional(id);
            return Ok(response);
        }
    }
}
