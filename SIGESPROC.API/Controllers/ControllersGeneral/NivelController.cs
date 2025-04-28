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
    public class NivelController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public NivelController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarNiveles()
        {
            var response = _generalService.ListarNiveles();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNivel(int id)
        {
            var response = _generalService.BuscarNivel(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(NivelViewModel NivelViewModel)
        {
            var modelo = new tbNiveles()
            {
                nive_Descripcion = NivelViewModel.nive_Descripcion,
                usua_Creacion = NivelViewModel.usua_Creacion,
                nive_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarNivel(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(NivelViewModel NivelViewModel)
        {
            var modelo = new tbNiveles()
            {
                nive_Id = Convert.ToInt32(NivelViewModel.nive_Id),
                nive_Descripcion = NivelViewModel.nive_Descripcion,
                usua_Modificacion = NivelViewModel.usua_Modificacion,
                nive_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarNivel(modelo);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int? id)
        {
            var result = _generalService.EliminarNivel(id);
            return Ok(result);
        }
    }
}
