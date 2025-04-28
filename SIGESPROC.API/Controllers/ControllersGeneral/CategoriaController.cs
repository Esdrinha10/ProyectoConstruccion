using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
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
    public class CategoriaController : Controller
    {
        private readonly GeneralService _generalService ;
        private readonly IMapper _mapper;

        public CategoriaController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }
        [HttpGet("Listar")]
        public IActionResult ListarContrato()
        {
            var response = _generalService.ListarCategorias();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarContrato(int id)
        {
            var response = _generalService.BuscarCategoria(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            var modelo = _mapper.Map<CategoriaViewModel, tbCategorias>(categoriaViewModel);
            var response = _generalService.InsertarCategoria(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(CategoriaViewModel categoriaViewModel)
        {
            var modelo = _mapper.Map<CategoriaViewModel, tbCategorias>(categoriaViewModel);
            var response = _generalService.ActualizarCategoria(modelo);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int? id)
        {
            var result = _generalService.EliminarCategoria(id);
            return Ok(result);
        }
    }
}
