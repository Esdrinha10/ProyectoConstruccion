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
    public class EtapaController : Controller
    {


        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public EtapaController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;//inicializamos el mapper
        }


        [HttpGet("Listar")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult ListarEtapa()
        {
            var response = _proyectoService.ListarEtapas();
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        [HttpGet("Buscar/{id}")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult BuscarEtapa(int id)
        {
            var response = _proyectoService.BuscarEtapa(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }
        [HttpGet("BuscarPorNombre")]
        public IActionResult BuscarEtapaPorNombre(string etap_Descripcion)
        {
            var response = _proyectoService.BuscarEtapaPorNombre(etap_Descripcion);
            return Ok(response.Data);
        }


        [HttpPost("Insertar")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult Create(EtapaViewModel EtapaViewModel)
        {
            var modelo = new tbEtapas()//mappeo de viewmodel al entitie de la tabla
            {
                etap_Descripcion = EtapaViewModel.etap_Descripcion,
                usua_Creacion = EtapaViewModel.usua_Creacion,
                etap_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarEtapa(modelo);//envio de los datos mapeados al servicio de insertar etapa y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpPut("Actualizar")]//Nombre de la ruta del controlador de la api, de tipo put
        public IActionResult Update(EtapaViewModel EtapaViewModel)
        {
            var modelo = new tbEtapas()//mappeo de viewmodel al entitie de la tabla
            {
                etap_Id = Convert.ToInt32(EtapaViewModel.etap_Id),
                etap_Descripcion = EtapaViewModel.etap_Descripcion,
                usua_Modificacion = EtapaViewModel.usua_Modificacion,
                etap_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarEtapa(modelo);//envio de los datos mapeados al servicio de actualizar etapa y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpDelete("Eliminar")]//Nombre de la ruta del controlador de la api, de tipo delete
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarEtapa(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }
    }
}
