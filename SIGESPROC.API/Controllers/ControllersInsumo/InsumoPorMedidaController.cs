using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsGeneral;
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
    public class InsumoPorMedidaController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        public InsumoPorMedidaController(InsumoService generaleService, IMapper mapper)
        {
            _insumoService = generaleService;
            _mapper = mapper;
        }


    

        [HttpPost("Insertar")]
        public IActionResult Create(InsumoPorMedidaViewModel InsumoPorMedidaViewModel)
        {
            var modelo = new tbInsumosPorMedidas()
            {
                insu_Id = InsumoPorMedidaViewModel.insu_Id,
                unme_Id = InsumoPorMedidaViewModel.unme_Id,
                usua_Creacion = InsumoPorMedidaViewModel.usua_Creacion,
                inpm_FechaCreacion = DateTime.Now
            };
            var response = _insumoService.InsertarInsumoPorMedida(modelo);
            return Ok(response);
        }
        [HttpGet("Buscar/{prov},{id}")]
        public IActionResult BuscarMedidasInsumo(int prov, int id)
        {
            var response = _insumoService.BuscarMedidasInsumo(prov, id);
            return Ok(response.Data);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _insumoService.EliminarInsumoPorMedida(id);
            return Ok(response);
        }
    }
}
