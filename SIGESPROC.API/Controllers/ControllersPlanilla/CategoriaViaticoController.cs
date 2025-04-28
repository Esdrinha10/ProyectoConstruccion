using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersPlanilla
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaViaticoController : Controller
    {
        private readonly PlanillaService _planillaService;
        private readonly IMapper _mapper;

        public CategoriaViaticoController(PlanillaService planillaService, IMapper mapper)
        {
            _planillaService = planillaService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCategoriasViaticos()
        {
            var response = _planillaService.ListarCategoriasViaticos();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNCategoriaViatico(int id)
        {
            var response = _planillaService.BuscarCategoriaViatico(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(CategoriaVaticoViewModel categoriaVaticoViewModel)
        {
            var modelo = new tbCategoriasViaticos()
            {
               
                cavi_Descripcion = categoriaVaticoViewModel.cavi_Descripcion,
                usua_Creacion = categoriaVaticoViewModel.usua_Creacion,
                cavi_FechaCreacion = DateTime.Now
            };
            var response = _planillaService.InsertarCategoriaViatico(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(CategoriaVaticoViewModel categoriaVaticoViewModel)
        {
            var modelo = new tbCategoriasViaticos()
            {
                cavi_Id = Convert.ToInt32(categoriaVaticoViewModel.cavi_Id),
                cavi_Descripcion = categoriaVaticoViewModel.cavi_Descripcion,
                usua_Modificacion = categoriaVaticoViewModel.usua_Modificacion,
                cavi_FechaModificacion = DateTime.Now
            };
            var response = _planillaService.ActualizarCategoriaViatico(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _planillaService.EliminarCategoriaViatico(id);
            return Ok(response);
        }
    }
}
