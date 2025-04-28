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
    public class ImagenPorGestionAdicionalController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public ImagenPorGestionAdicionalController(ProyectoService proyectoService, IMapper mapper)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;
        }


        [HttpGet("Listar/{adic_Id}")]
        public IActionResult ListarImagenesPorGestionAdicional(int adic_Id)
        {
            var response = _proyectoService.ListarImagenesPorGestionesAdicionales(adic_Id);
            return Ok(response.Data);
        }


        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            var result = _proyectoService.EliminarArchivoAdjunto(id);

            return Ok(result);
        }

        //[HttpPost("Listar/{adic_Id}")]
        //public IActionResult Buscar(int adic_Id)
        //{
        //    var material = _proyectoService.BuscarArchivoAdjunto(adic_Id);

        //    return Ok(material);
        //}

        [HttpPost("Insertar")]
        public IActionResult Insertar(ArchivoAdjuntoViewModel item)
        {
            var modelo2 = new tbImagenesPorGestionesAdicionales()
            {
                Imge_Imagen = item.Imge_Imagen,
                adic_Id = item.adic_Id,
                usua_Creacion = item.usua_Creacion,
                Imge_FechaCreacion = DateTime.Now
            };
            var adic_Id = _proyectoService.InsertarArchivoAdjunto(modelo2);
            return Ok(adic_Id);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar(ArchivoAdjuntoViewModel item)
        {
            var modelo2 = new tbImagenesPorGestionesAdicionales()
            {
                Imge_Id = Convert.ToInt32(item.Imge_Id),
                Imge_Imagen = item.Imge_Imagen,
                adic_Id = item.adic_Id,
                usua_Modificacion = item.usua_Modificacion,
                Imge_FechaCreacion = DateTime.Now
            };
            var adic_Id = _proyectoService.ActualizarArchivoAdjunto(modelo2);
            return Ok(adic_Id);
        }
    }
}
