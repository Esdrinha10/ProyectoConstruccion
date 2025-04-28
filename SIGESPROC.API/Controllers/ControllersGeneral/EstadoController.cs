using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public EstadoController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarEstados()
        {
            var response = _generalService.ListarEstados();
            return Ok(response.Data);
        }

        [HttpGet("DropDownEstados")]
        public IActionResult DropDownEstados()
        {
            var response = _generalService.DropDownEstados();
            return Ok(response.Data);
        }

        [HttpPost("EstadoPorPais/{id}")]
        public IActionResult EstadoPorPais(int? id)
        {
            var response = _generalService.EstadoPorPais(id);
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarEstado(int id)
        {
            var response = _generalService.BuscarEstado(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(EstadoViewModel EstadoViewModel)
        {
            var modelo = new tbEstados()
            {

                esta_Codigo = EstadoViewModel.esta_Codigo,
                esta_Nombre = EstadoViewModel.esta_Nombre,
                pais_Id = EstadoViewModel.pais_Id,
                usua_Creacion = EstadoViewModel.usua_Creacion,
                esta_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarEstado(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(EstadoViewModel EstadoViewModel)
        {
            var modelo = new tbEstados()
            {
                esta_Id = EstadoViewModel.esta_Id,
                esta_Codigo = EstadoViewModel.esta_Codigo,
                esta_Nombre = EstadoViewModel.esta_Nombre,
                pais_Id = EstadoViewModel.pais_Id,
                usua_Modificacion = EstadoViewModel.usua_Modificacion,
                esta_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarEstado(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarEstado(id);
            return Ok(response);
        }
    }
}
