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
    public class ImagenPorControlCalidadController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public ImagenPorControlCalidadController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }

        [HttpGet("Listar/{coca_Id}")]
        public IActionResult ListarImagenesPorControlCalidades(int coca_Id)
        {
            var response = _proyectoService.ListarImagenesPorControlCalidades(coca_Id);
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarImagenPorControlCalidad(int id)
        {
            var response = _proyectoService.BuscarImagenPorControlCalidad(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ImagenPorControlCalidadViewModel modelos)
        {
            
                    var modelo2 = new tbImagenesPorControlesDeCalidades()
                    {
                        icca_Imagen = modelos.icca_Imagen,
                        coca_Id = modelos.coca_Id,
                        usua_Creacion = modelos.usua_Creacion,
                        icca_FechaCreacion = DateTime.Now
                    };
                    var coca_Id  =_proyectoService.InsertarImagenPorControlCalidad(modelo2);
                return Ok(coca_Id);          
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ImagenPorControlCalidadViewModel ImagenPorControlCalidadViewModel)
        {
            var modelo = new tbImagenesPorControlesDeCalidades()
            {
                icca_Id = Convert.ToInt32(ImagenPorControlCalidadViewModel.icca_Id),
                icca_Imagen = ImagenPorControlCalidadViewModel.icca_Imagen,
                icca_Descripcion = ImagenPorControlCalidadViewModel.icca_Descripcion,
                coac_Id = Convert.ToInt32(ImagenPorControlCalidadViewModel.coac_Id),
                usua_Modificacion = ImagenPorControlCalidadViewModel.usua_Modificacion,
                icca_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarImagenPorControlCalidad(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarImagenPorControlCalidad(id);
            return Ok(response);
        }
    }
}
