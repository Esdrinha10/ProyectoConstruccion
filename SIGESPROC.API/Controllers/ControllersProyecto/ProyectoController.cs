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
    public class ProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public ProyectoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        {
            var result = _proyectoService.EliminarProyecto(id);

            return Ok(result);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] int? id)
        {
            var material = _proyectoService.BuscarProyecto(id);

            return Ok(material);
        }

        [HttpGet("BuscarPorNombre")]
        public IActionResult BuscarPresupuestoEncabezado(string proy_Nombre)
        {
            var response = _proyectoService.BuscarProyectoPorNombre(proy_Nombre);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(ProyectoViewModel item)
        {
            var model = _mapper.Map<tbProyectos>(item);

            var result = _proyectoService.InsertarProyecto(model);

            return Ok(result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _proyectoService.ListarProyectos();

            return Ok(response.Data);
        }
        [HttpGet("ListarActividades")]
        public IActionResult ListarPresupuestosDetalles(int id)
        {
            var response = _proyectoService.ProyectoListarActividades(id);
            return Ok(response.Data);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar(ProyectoViewModel item)
        {
            var model = _mapper.Map<tbProyectos>(item);

            var result = _proyectoService.ActualizarProyecto(model);

            return Ok(result);
        }
    }
}
