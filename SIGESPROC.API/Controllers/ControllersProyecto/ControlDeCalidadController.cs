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
    public class ControlDeCalidadController : Controller
    {

        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public ControlDeCalidadController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarControlDeCalidades()
        {
            var response = _proyectoService.ListarControlDeCalidades();
            return Ok(response.Data);
        }

        [HttpGet("ListarPorActividad/{id}")]
        public IActionResult ListarControlDeCalidadesPorActividad(int id)
        {
            var response = _proyectoService.ListarControlDeCalidadesPorActividad(id);
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarControlDeActividad(int id)
        {
            var response = _proyectoService.BuscarControlDeCalidad(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ControlDeCalidadViewModel ControlDeCalidadViewModel)
        {
            var modelo = new tbControlDeCalidadesPorActividades()
            {
                coca_Descripcion = ControlDeCalidadViewModel.coca_Descripcion,
                coca_Fecha = ControlDeCalidadViewModel.coca_Fecha,
                acet_Id = ControlDeCalidadViewModel.acet_Id,
                coca_CantidadTrabajada = ControlDeCalidadViewModel.coca_CantidadTrabajada,
                usua_Creacion = ControlDeCalidadViewModel.usua_Creacion,
                coca_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarControlDeCalidad(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ControlDeCalidadViewModel ControlDeCalidadViewModel)
        {
            var modelo = new tbControlDeCalidadesPorActividades()
            {
                coca_Id = ControlDeCalidadViewModel.coca_Id,
                coca_Descripcion = ControlDeCalidadViewModel.coca_Descripcion,
                coca_Fecha = ControlDeCalidadViewModel.coca_Fecha,
                acet_Id = ControlDeCalidadViewModel.acet_Id,
                coca_CantidadTrabajada = ControlDeCalidadViewModel.coca_CantidadTrabajada,
                usua_Modificacion = ControlDeCalidadViewModel.usua_Modificacion,
                coca_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarControlDeCalidad(modelo);
            return Ok(response);
        }

        [HttpGet("Aprobar")]
        public IActionResult Aprobar(int id)
        {
            var response = _proyectoService.AprobarControlDeCalidad(id);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarControlDeCalidad(id);
            return Ok(response);
        }

        [HttpGet("ListarProyectos")]
        public IActionResult ListarProyectosControlDeCalidades()
        {
            var response = _proyectoService.ListarProyectosConControlesDeCalidad();
            return Ok(response.Data);
        }

        [HttpGet("ListarControlesPorProyecto/{proy_Id}")]
        public IActionResult ListarControlesDeCalidadPorProyectos(int proy_Id)
        {
            var response = _proyectoService.ListarControlesDeCalidadPorProyectos(proy_Id);
            return Ok(response.Data);
        }


    }
}
