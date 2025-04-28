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
    public class GestionRiesgoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public GestionRiesgoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }
        
        [HttpGet("Listar/{id}")]
        public IActionResult Listar(int? id)
        {
            var response = _proyectoService.ListarGestionRiesgos(id);

            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarGestionRiesgo(int id)
        {
            var response = _proyectoService.BuscarGestionRiesgo(id);

            return Ok(response);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(GestionRiesgoViewModel item)
        {
            var model = _mapper.Map<tbGestionRiesgos>(item);

            var response = _proyectoService.InsertarGestionRiesgo(model);

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(GestionRiesgoViewModel item)
        {
            var model = _mapper.Map<tbGestionRiesgos>(item);

            var response = _proyectoService.ActualizarGestionRiesgo(model);

            return Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarGestionRiesgo(id);

            return Ok(response);
        }
    }
}
