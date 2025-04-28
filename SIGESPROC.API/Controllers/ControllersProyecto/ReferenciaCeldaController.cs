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
    public class ReferenciaCeldaController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public ReferenciaCeldaController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }
        [HttpPut("Eliminar")]
        public IActionResult Eliminar(ReferenciaCeldaViewModel item)
        {
            var model = _mapper.Map<tbReferenciasCeldas>(item);

            var result = _proyectoService.EliminarReferencia(model);

            return Ok(result);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(ReferenciaCeldaViewModel item)
        {
            var model = _mapper.Map<tbReferenciasCeldas>(item);

            var response = _proyectoService.InsertarReferencia(model);

            return Ok(response);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _proyectoService.ListarReferencias();

            return Ok(response.Data);
        }
    }
}
