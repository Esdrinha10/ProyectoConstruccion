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

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public AlertaController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult ListarAlertas()
        {
            var response = _proyectoService.ListarAlertas();
            return Ok(response.Data);
        }


        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarAlerta(int id)
        {
            var response = _proyectoService.BuscarAlerta(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(AlertaViewModel AlertaViewModel)
        {
            var modelo = new tbAlertas()
            {
                aler_Fecha = AlertaViewModel.aler_Fecha,
                aler_Descripcion = AlertaViewModel.aler_Descripcion,
                tian_Id = AlertaViewModel.tian_Id,
                aler_Ruta = AlertaViewModel.aler_Ruta,
                usua_Id = AlertaViewModel.usua_Id,
                usua_Creacion = AlertaViewModel.usua_Creacion,
                aler_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarAlerta(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(AlertaViewModel AlertaViewModel)
        {
            var modelo = new tbAlertas()
            {
                aler_Id = AlertaViewModel.aler_Id,
                aler_Fecha = AlertaViewModel.aler_Fecha,
                aler_Descripcion = AlertaViewModel.aler_Descripcion,
                tian_Id = AlertaViewModel.tian_Id,
                usua_Id = AlertaViewModel.usua_Id,
                aler_Ruta = AlertaViewModel.aler_Ruta,
                usua_Modificacion = AlertaViewModel.usua_Modificacion,
                aler_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarAlerta(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarAlerta(id);
            return Ok(response);
        }

        [HttpPost("InsertarAlertas")]
        public IActionResult Create(List<NotificacionAlertaPorUsuarioViewModel> detalles)
        {
            var aler_Id = 0;
            if (detalles.Count > 0)
            {
                if (detalles[0].aler_Id == 0)
                {
                    var modelo = new tbAlertas()
                    {
                        aler_Descripcion = detalles[0].aler_Descripcion,
                        aler_Fecha = detalles[0].aler_Fecha,
                        aler_Ruta = detalles[0].aler_Ruta,
                        usua_Creacion = detalles[0].usua_Creacion,
                        aler_FechaCreacion = DateTime.Now
                    };
                    var response = _proyectoService.InsertarAlerta(modelo);
                    aler_Id = response.Data.CodeStatus;
                }
                else
                {
                    aler_Id = detalles[0].aler_Id;
                }

                foreach (var detalle in detalles)
                {
                    var modelo2 = new tbNotificacionesAlertarPorUsuario()
                    {
                        napu_AlertaOnoti = false,
                        napu_AlertaONotiId = aler_Id,
                        usua_Id = detalle.usua_Id,
                        napu_Leida = false,
                        napu_Ruta = detalle.napu_Ruta,
                        usua_Creacion = detalle.usua_Creacion,
                        napu_FechaCreacion = DateTime.Now
                    };
                    _proyectoService.InsertarNotificacionPorUsuario2(modelo2);
                }
                return Ok(new { success = true, aler_Id = aler_Id, Message = "Success" });

            }
            return BadRequest("no hay detalles");
        }
    }
}
