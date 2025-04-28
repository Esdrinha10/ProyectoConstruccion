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
    public class NotificacionAlertaPorUsuarioController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public NotificacionAlertaPorUsuarioController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("BuscarNotificacion/{id}")]
        public IActionResult BuscarNotificacion(int id)
        {
            var response = _proyectoService.FiltrarNotificaciones(id);
            return Ok(response.Data);
        }


        [HttpGet("BuscarTokenProyecto/{id}")]
        public IActionResult BuscarTokenProyecto(int id)
        {
            var response = _proyectoService.TokenporProyectos(id);
            return Ok(response.Data);
        }

        [HttpGet("Listartokenadministradores")]
        public IActionResult Listartokenadministradores()
        {
            var response = _proyectoService.tokenadmin();
            return Ok(response.Data);
        }
        ///

        [HttpPost("Insertar")]
        public IActionResult Create(NotificacionAlertaPorUsuarioViewModel notificacionAlertaPorUsuarioViewModel)
        {

            var modelo = new tbNotificacionesAlertarPorUsuario()
            {
                usua_Id = notificacionAlertaPorUsuarioViewModel.usua_Id,
                napu_AlertaOnoti =Convert.ToBoolean(notificacionAlertaPorUsuarioViewModel.napu_AlertaOnoti),
                napu_AlertaONotiId =Convert.ToInt32( notificacionAlertaPorUsuarioViewModel.napu_AlertaONotiId),
                usua_Creacion = notificacionAlertaPorUsuarioViewModel.usua_Creacion,
                napu_FechaModificacion = DateTime.Now

            };

            var response = _proyectoService.InsertarNotificacionUsuario(modelo);

            return Ok(response);
        }

        [HttpPost("InsertarToken")]
        public IActionResult Createtoken([FromBody] NotificacionAlertaPorUsuarioViewModel notificacionAlertaPorUsuarioViewModel)
        {
            if (notificacionAlertaPorUsuarioViewModel == null)
            {
                return BadRequest("El modelo de notificación no puede ser nulo.");
            }

            var modelo = new tbNotificacionesAlertarPorUsuario()
            {
                usua_Id = notificacionAlertaPorUsuarioViewModel.usua_Id,
                tokn_JsonToken = notificacionAlertaPorUsuarioViewModel.tokn_JsonToken,
            };

            var response = _proyectoService.InsertarToken(modelo);

            return Ok(response);
        }


        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarNotificacionAlertaPorUsuario(id);
            return Ok(response);
        }

        [HttpGet("Leer/{id}")]
        public IActionResult Leer(int id)
        {
            var response = _proyectoService.LeerNotificacionAlertaPorUsuario(id);
            return Ok(response);
        }



  
        [HttpDelete("EliminarToken")]
        public IActionResult DeleteToken(int id, string token)

        {
            var response = _proyectoService.EliminarToken(id, token);
            return Ok(response);
        }

        //[HttpPost("InsertarToken")]
        //public IActionResult InsertarToken(NotificacionAlertaPorUsuarioViewModel item)
        //{


        //    var modelo = new tbNotificacionesAlertarPorUsuario
        //    {
        //        usua_Id = item.usua_Id,
        //        tokn_JsonToken = item.tokn_JsonToken
        //    };


        //    var response = _proyectoService.InsertarTokens(modelo);
        //    return Ok(response);
        //}

        [HttpGet("ListarTokens")]
        public IActionResult ListarTokens()
        {
            var response = _proyectoService.ListarTokens();
            return Ok(response);
        }

        [HttpGet("ListarTokensPorUsuario/{usua_Id}")]
        public IActionResult ListarTokensPorUsuario(int usua_Id)
        {
            var response = _proyectoService.ListarTokensPorUsuario(usua_Id);



                  return Ok(response);
        }

        //[HttpDelete("EliminarToken")]
        //public IActionResult DeleteToken(int id, string token)
        //{
        //    var response = _proyectoService.EliminarToken(id, token);

        //    return Ok(response);
        //}

        //    return Ok(response);

    }

}
