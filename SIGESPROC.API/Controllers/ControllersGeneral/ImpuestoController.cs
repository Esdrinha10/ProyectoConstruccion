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
    public class ImpuestoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        // Constructor que inicializa el servicio general y el mapeador
        public ImpuestoController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            // Llamamos al servicio para listar los impuestos
            var response = _generalService.ListarImpuestos();
            return Ok(response.Data);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ImpuestoViewModel bancoViewModel)
        {
            // Mapeamos el modelo de vista al modelo de entidad
            var modelo = _mapper.Map<ImpuestoViewModel, tbImpuestos>(bancoViewModel);

            // Llamamos al servicio para actualizar el impuesto
            var response = _generalService.ActualizarImpuesto(modelo);
            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarBanco(int id)
        {
            // Llamamos al servicio para buscar un impuesto por su ID
            var response = _generalService.BuscarImpuesto(id);
            return Ok(response.Data);
        }
    }
}
