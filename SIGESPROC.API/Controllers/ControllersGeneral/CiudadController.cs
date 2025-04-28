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
    public class CiudadController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public CiudadController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCiudades()
        {
            var response = _generalService.ListarCiudades();
            return Ok(response.Data);
        }

        [HttpGet("DropDownCiudades")]

        public IActionResult DropDownCiudades()
        {
            var response = _generalService.ListarCiudades();
            return Ok(response.Data);
        }


        [HttpPost("CiudadPorEstado/{id}")]
        public IActionResult CiudadPorEstado(int? id)
        {
            var response = _generalService.CiudadPorEstado(id);
            return Ok(response.Data);
        }
        



        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCiudades(int id)
        {
            var response = _generalService.BuscarCiudades(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(CiudadViewModel CiudadViewModel)
        {
            var modelo = new tbCiudades()
            {
                ciud_Codigo = CiudadViewModel.ciud_Codigo,
                ciud_Descripcion = CiudadViewModel.ciud_Descripcion,
                esta_Id = CiudadViewModel.esta_Id,
                usua_Creacion = CiudadViewModel.usua_Creacion,
                ciud_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarCiudades(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(CiudadViewModel CiudadViewModel)
        {
            var modelo = new tbCiudades()
            {
                ciud_Id = Convert.ToInt32(CiudadViewModel.ciud_Id),
                ciud_Codigo = CiudadViewModel.ciud_Codigo,
                ciud_Descripcion = CiudadViewModel.ciud_Descripcion,
                esta_Id = CiudadViewModel.esta_Id,
                usua_Modificacion = CiudadViewModel.usua_Modificacion,
                ciud_FechaModificiacion = DateTime.Now
            };
            var response = _generalService.ActualizarCiudades(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete( int id)
        {
            var response = _generalService.EliminarCiudades(id);
            return Ok(response);
        }
    }
}
