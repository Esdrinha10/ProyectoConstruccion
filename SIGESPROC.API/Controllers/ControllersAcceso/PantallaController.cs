using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceAcceso;
using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersAcceso
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantallaController : Controller
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        public PantallaController(AccesoService accesoService, IMapper mapper)
        {
            _mapper = mapper;
            _accesoService = accesoService;
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            var result = _accesoService.EliminarPantalla(id);

            return Ok(result);
        }

        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(int? id)
        {
            var pantalla = _accesoService.BuscarPantalla(id);

            return Ok(pantalla);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(PantallaViewModel item)
        {
            var model = _mapper.Map<tbPantallas>(item);

            var result = _accesoService.InsertarPantalla(model);

            return Ok(result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _accesoService.ListarPantallas();

            return Ok(list);
        }

        [HttpGet("ListarPorRol")]
        public IActionResult ListarPorRol()
        {
            var list = _accesoService.ListarPantallasPorRol();

            return Ok(list.Data);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar(PantallaViewModel item)
        {
            var model = _mapper.Map<tbPantallas>(item);

            var result = _accesoService.ActualizarPantalla(model);

            return Ok(result);
        }
    }
}
