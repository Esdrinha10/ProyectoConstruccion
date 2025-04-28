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
    public class ControlDeCalidadPorActividadController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public ControlDeCalidadPorActividadController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarControlDeCalidadesPorActividades(int id)
        {
            var response = _proyectoService.ListarControlDeCalidadesPorActividades(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ControlDeCalidadPorActividadViewModel ControlDeCalidadPorActividadViewModel)
        {
            var modelo = new tbControlDeCalidadesPorActividades()
            {
                acet_Id = ControlDeCalidadPorActividadViewModel.acet_Id,
                coca_Id = ControlDeCalidadPorActividadViewModel.coca_Id,
                //usua_Creacion = ControlDeCalidadViewModel.usua_Creacion,
                //coca_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarControlDeCalidadPorActividad(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ControlDeCalidadPorActividadViewModel ControlDeCalidadPorActividadViewModel)
        {
            var modelo = new tbControlDeCalidadesPorActividades()
            {
                coac_Id = Convert.ToInt32(ControlDeCalidadPorActividadViewModel.coca_Id),
                acet_Id = ControlDeCalidadPorActividadViewModel.acet_Id,
                coca_Id = ControlDeCalidadPorActividadViewModel.coca_Id,
                //usua_Modificacion = ControlDeCalidadViewModel.usua_Modificacion,
                //coca_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarControlDeCalidadPorActividad(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarControlDeCalidadPorActividad(id);
            return Ok(response);
        }
    }
}
