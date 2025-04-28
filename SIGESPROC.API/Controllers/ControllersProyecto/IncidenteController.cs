using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ProyectoService;
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
    public class IncidenteController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public IncidenteController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar/{id}")]
        public IActionResult ListarIncidentes(int id)
        {
            var response = _proyectoService.ListarIncidentes(id);
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarIncidente(int id)
        {
            var response = _proyectoService.BuscarIncidente(id);
            return Ok(response.Data);
        }


        [HttpGet("IncidentesPorActicvidadPorEtapa/{id}")]
        public IActionResult IncidentesPorActividadPorEtapa(int id)
        {
            var response = _proyectoService.IncidentesPorActicvidadPorEtapa(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(IncidentesViewModel incidentesViewModel)
        {
            var modelo = _mapper.Map<IncidentesViewModel, tbIncidentes>(incidentesViewModel);
            var response = _proyectoService.InsertarIncidente(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(IncidentesViewModel incidentesViewModel)
        {
            var modelo = _mapper.Map<IncidentesViewModel, tbIncidentes>(incidentesViewModel);
            var response = _proyectoService.ActualizarIncidente(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarIncidente(id);
            return Ok(response);
        }


        [HttpGet("ListarProyectosIncidente")]
        public IActionResult ListarProyectosConIncidentes()
        {
            var response = _proyectoService.ListarProyectosConIncidentes();
            return Ok(response.Data);
        }


        [HttpGet("ListarIncidentesPorProyecto/{proy_Id}")]
        public IActionResult ListarIncidentesPorProyecto(int proy_Id)
        {
            var response = _proyectoService.ListarIncidentesPorProyecto(proy_Id);
            return Ok(response.Data);
        }

    }
}
