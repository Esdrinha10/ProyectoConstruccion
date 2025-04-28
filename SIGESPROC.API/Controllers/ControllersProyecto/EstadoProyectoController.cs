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
    [Route("api/[controller]")]//nombra la ruta con el nombre del controlador
    [ApiController]
    public class EstadoProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;




        public EstadoProyectoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;//inicializamos el mapper
        }



        [HttpGet("Listar")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult ListarEstadoProyecto()
        {
            var response = _proyectoService.ListarEstadosProyectos();
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        [HttpGet("Buscar/{id}")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult BuscarEstadoProyecto(int id)
        {
            var response = _proyectoService.BuscarEstadoProyecto(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        [HttpPost("Insertar")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult Create(EstadoProyectoViewModel EstadoProyectoViewModel)
        {
            var modelo = new tbEstadosProyectos()//mappeo de viewmodel al entitie de la tabla
            {
                espr_Descripcion = EstadoProyectoViewModel.espr_Descripcion,
               
                usua_Creacion = EstadoProyectoViewModel.usua_Creacion,
                espr_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarEstadoProyecto(modelo);//envio de los datos mapeados al servicio de insertar estado de proyecto y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpPut("Actualizar")]//Nombre de la ruta del controlador de la api, de tipo put
        public IActionResult Update(EstadoProyectoViewModel EstadoProyectoViewModel)
        {
            var modelo = new tbEstadosProyectos()//mappeo de viewmodel al entitie de la tabla
            {
                espr_Id = Convert.ToInt32(EstadoProyectoViewModel.espr_Id),
                espr_Descripcion = EstadoProyectoViewModel.espr_Descripcion,
                usua_Modificacion = EstadoProyectoViewModel.usua_Modificacion,
                espr_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarEstadoProyecto(modelo);//envio de los datos mapeados al servicio de actualizar estado de proyecto y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpDelete("Eliminar")]//Nombre de la ruta del controlador de la api, de tipo delete
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarEstadoProyecto(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }
    }
}
