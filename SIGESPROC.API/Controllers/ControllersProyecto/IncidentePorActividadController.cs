using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ProyectoService;
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
    public class IncidentePorActividadController : Controller
    {
        private readonly IncidentePorActividadService _proyectoService;
        private readonly IMapper _mapper;

        public IncidentePorActividadController(IncidentePorActividadService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        //[HttpGet("Listar")]
        //public IActionResult ListarIncidentesPorActividad()
        //{
        //    var response = _proyectoService.ListarIncidentesPorActividad();
        //    return Ok(response.Data);
        //}

        [HttpGet("Buscar/{acet_Id}")]
        public IActionResult BuscarIncidentePorActividad(int acet_Id)
        {
            var response = _proyectoService.BuscarIncidentePorActividad(acet_Id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(IncidenciasPorActividadesViewModel incidenciasPorActividadesViewModel)
        {
            var modelo = _mapper.Map<IncidenciasPorActividadesViewModel, tbIncidenciasPorActividades>(incidenciasPorActividadesViewModel);
            var response = _proyectoService.InsertarIncidentePorActividad(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(IncidenciasPorActividadesViewModel incidenciasPorActividadesViewModel)
        {
            var modelo = _mapper.Map<IncidenciasPorActividadesViewModel, tbIncidenciasPorActividades>(incidenciasPorActividadesViewModel);
            var response = _proyectoService.ActualizarIncidentePorActividad(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarIncidentePorActividad(id);
            return Ok(response);
        }
    }
}
