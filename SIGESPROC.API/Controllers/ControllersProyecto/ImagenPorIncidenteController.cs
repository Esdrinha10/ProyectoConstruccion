using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ImagenPorIncidenteService;
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
    public class ImagenPorIncidenteController : Controller
    {
        private readonly ImagenPorIncidenteService _proyectoService;
        private readonly IMapper _mapper;

        public ImagenPorIncidenteController(ImagenPorIncidenteService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        //[HttpGet("Listar")]
        //public IActionResult ListarImagenesPorIncidente()
        //{
        //    var response = _proyectoService.ListarImagenesPorIncidente();
        //    return Ok(response.Data);
        //}

        [HttpGet("Buscar/{inac_Id}")]
        public IActionResult BuscarImagenPorIncidente(int inac_Id)
        {
            var response = _proyectoService.BuscarImagenPorIncidente(inac_Id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ImagenesPorIncidenciasViewModel imagenesPorIncidenciasViewModel)
        {
            var modelo = _mapper.Map<ImagenesPorIncidenciasViewModel, tbImagenesPorIncidencias>(imagenesPorIncidenciasViewModel);
            var response = _proyectoService.InsertarImagenPorIncidente(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ImagenesPorIncidenciasViewModel imagenesPorIncidenciasViewModel)
        {
            var modelo = _mapper.Map<ImagenesPorIncidenciasViewModel, tbImagenesPorIncidencias>(imagenesPorIncidenciasViewModel);
            var response = _proyectoService.ActualizarImagenPorIncidente(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarImagenPorIncidente(id);
            return Ok(response);
        }
    }
}
