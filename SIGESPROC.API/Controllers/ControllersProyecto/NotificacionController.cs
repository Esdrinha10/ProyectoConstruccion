using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllerProyecto
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public NotificacionController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarNotificaciones()
        {
            var response = _proyectoService.ListarNotificaciones();
            return Ok(response.Data);
        }

        [HttpGet("ListarNotificaciones")]
        public IActionResult ListarNotificaciones2()
        {
            var response = _proyectoService.ListarNotificaciones2();
            return Ok(response.Data);
        }


        [HttpGet("ListarTipos")]
        public IActionResult ListarTiposNotificaciones()
        {
            var response = _proyectoService.ListarTiposNotificaciones();
            return Ok(response.Data);
        }

        [HttpGet("Contar")]
        public IActionResult ContarNotificaciones()
        {
            var response = _proyectoService.ContarNotificacion();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNotificacion(int id)
        {
            var response = _proyectoService.BuscarNotificacion(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(NotificacionViewModel NotificacionViewModel)
        {
            var modelo = new tbNotificaciones()
            {
                noti_Descripcion = NotificacionViewModel.noti_Descripcion,
                noti_Fecha = NotificacionViewModel.noti_Fecha,
                noti_Ruta = NotificacionViewModel.noti_Ruta,
                usua_Creacion = NotificacionViewModel.usua_Creacion,
                noti_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarNotificacion(modelo);
            return Ok(response);
        }


        [HttpPost("InsertarNotificaciones")]
        public IActionResult Create(List<NotificacionAlertaPorUsuarioViewModel> detalles)
        {
            var noti_Id = 0;
            if (detalles.Count > 0)
            {
                if (detalles[0].noti_Id == 0)
                {
                    var modelo = new tbNotificaciones()
                    {
                        noti_Descripcion = detalles[0].noti_Descripcion,
                        noti_Fecha = detalles[0].noti_Fecha,
                        noti_Ruta = detalles[0].noti_Ruta,
                        usua_Creacion = detalles[0].usua_Creacion,
                        noti_FechaCreacion = DateTime.Now
                    };
                    var response = _proyectoService.InsertarNotificacion(modelo);
                    noti_Id = response.Data.CodeStatus;
                }
                else
                {
                    noti_Id = detalles[0].noti_Id;
                }

                foreach (var detalle in detalles)
                {
                    var modelo2 = new tbNotificacionesAlertarPorUsuario()
                    {
                        napu_AlertaOnoti = true,
                        napu_AlertaONotiId = noti_Id,
                        usua_Id = detalle.usua_Id,
                        napu_Leida = false,
                        napu_Ruta = detalle.napu_Ruta,
                        usua_Creacion = detalle.usua_Creacion,
                        napu_FechaCreacion = DateTime.Now
                    };
                    _proyectoService.InsertarNotificacionPorUsuario(modelo2);
                }
                return Ok(new { success = true, noti_Id = noti_Id, Message = "Success" });

            }
            return BadRequest("no hay detalles");
        }


        [HttpPut("Actualizar")]
        public IActionResult Update(NotificacionViewModel NotificacionViewModel)
        {
            var modelo = new tbNotificaciones()
            {
                noti_Id = NotificacionViewModel.noti_Id,
                noti_Descripcion = NotificacionViewModel.noti_Descripcion,
                noti_Fecha = NotificacionViewModel.noti_Fecha,
                noti_Tipo = NotificacionViewModel.noti_Tipo,
                napu_Ruta = NotificacionViewModel.napu_Ruta,
                noti_Leida = NotificacionViewModel.noti_Leida,
                tian_Id = NotificacionViewModel.tian_Id,
                usua_Modificacion = NotificacionViewModel.usua_Modificacion,
                noti_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarNotificacion(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarNotificacion(id);
            return Ok(response);
        }
    }
}
