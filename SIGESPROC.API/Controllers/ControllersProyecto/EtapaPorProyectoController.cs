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
    public class EtapaPorProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public EtapaPorProyectoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar/{id}")]
        public IActionResult ListarEtapasPorProyectos(int id)
        {
            var response = _proyectoService.ListarEtapasPorProyectos(id);
            return Ok(response.Data);
        }

        [HttpPost("Listar")]
        public IActionResult Listar([FromBody] int id)
        {
            var response = _proyectoService.ListarEtapasPorProyectos(id);

            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var response = _proyectoService.BuscarEtapasPorProyectos(id);

            return Ok(response);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(EtapaPorProyectoViewModel EtapaPorProyectoViewModel)
        {
            var modelo = _mapper.Map<tbEtapasPorProyectos>(EtapaPorProyectoViewModel);

            var response = _proyectoService.InsertarEtapaPorProyecto(modelo);

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(EtapaPorProyectoViewModel EtapaPorProyectoViewModel)
        {
            var modelo = _mapper.Map<tbEtapasPorProyectos>(EtapaPorProyectoViewModel);

            var response = _proyectoService.ActualizarEtapaPorProyecto(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarEtapaPorProyecto(id);
            return Ok(response);
        }
    }
}
