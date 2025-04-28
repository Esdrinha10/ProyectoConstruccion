using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaPorInsumoController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        public BodegaPorInsumoController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult ListarBodegasPorInsumos(int id)
        {
            var response = _insumoService.ListarBodegasPorInsumos(id);
            if (response.Success == true)
            {
                return Ok(response.Data);

            }
            else
            {
                return Problem(response.Data);

            }
        }


        [HttpPost("Insertar")]
        public IActionResult Create(BodegaPorInsumoViewModel item)
        {
            var modelo = _mapper.Map<tbBodegasPorInsumo>(item);


            var response = _insumoService.InsertarBodegaPorInsumo(modelo);
            if (response.Success == true)
            {
                return Ok(response);

            }
            else
            {
                return Problem();

            }
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(BodegaPorInsumoViewModel item)
        {
            var modelo = _mapper.Map<tbBodegasPorInsumo>(item);

            var response = _insumoService.ActualizarBodegaPorInsumo(modelo);
            if (response.Success == true)
            {
                return Ok(response);

            }
            else
            {
                return Problem();

            }
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(tbBodegasPorInsumo item)
        {
            var response = _insumoService.EliminarBodegaPorInsumo(item);
            if (response.Success == true)
            {
                return Ok(response);

            }
            else
            {
                return Problem();

            }
        }
    }
}
