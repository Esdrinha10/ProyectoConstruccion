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
    public class CargoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public CargoController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCargos()
        {
            var response = _generalService.ListarCargos();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCargo(int id)
        {
            var response = _generalService.BuscarCargo(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(CargoViewModel CargoViewModel)
        {
            var modelo = new tbCargos()
            {

                carg_Descripcion = CargoViewModel.carg_Descripcion,
                usua_Creacion = CargoViewModel.usua_Creacion,
                carg_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarCargo(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(CargoViewModel CargoViewModel)
        {
            var modelo = new tbCargos()
            {                  
                carg_Id = CargoViewModel.carg_Id,
                carg_Descripcion = CargoViewModel.carg_Descripcion,
                usua_Modificacion = CargoViewModel.usua_Modificacion,
                carg_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarCargo(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarCargo(id);
            return Ok(response);
        }
    }
}
