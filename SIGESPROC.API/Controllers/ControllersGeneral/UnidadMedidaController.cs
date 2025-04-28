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
    public class UnidadMedidaController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public UnidadMedidaController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarUnidadesDeMedidas()
        {
            var response = _generalService.ListarUnidadesMedidas();
            return Ok(response.Data);
        }

        [HttpGet("Listar/{id}")]
        public IActionResult ListarSubcategoriasPorCategoria(int id)
        {
            var response = _generalService.ListarInsumosPorMedidas(id);
            return Ok(response.Data);
        }
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarUnidadMedida(int id)
        {
            var response = _generalService.BuscarUnidadMedida(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(UnidadMedidaViewModel UnidadMedidaViewModel)
        {
            var modelo = new tbUnidadesMedida()
            {
                unme_Nombre = UnidadMedidaViewModel.unme_Nombre,
                unme_Nomenclatura = UnidadMedidaViewModel.unme_Nomenclatura,
                usua_Creacion = UnidadMedidaViewModel.usua_Creacion,
                unme_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarUnidadMedida(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(UnidadMedidaViewModel UnidadMedidaViewModel)
        {
            var modelo = new tbUnidadesMedida()
            {
                unme_Id = UnidadMedidaViewModel.unme_Id,
                unme_Nombre = UnidadMedidaViewModel.unme_Nombre,
                unme_Nomenclatura = UnidadMedidaViewModel.unme_Nomenclatura,
                usua_Modificacion = UnidadMedidaViewModel.usua_Modificacion,
                unme_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarUnidadMedida(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarUnidadMedida(id);
            return Ok(response);
        }
    }
}
