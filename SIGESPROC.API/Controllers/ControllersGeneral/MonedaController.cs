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
    public class MonedaController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public MonedaController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene una lista de todas las monedas.
        /// </summary>
        /// <returns>Lista de monedas.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarMonedas()
        {
            var response = _generalService.ListarMonedas();
            return Ok(response.Data);
        }

        /// <summary>
        /// Obtiene el valor de una moneda específica en relación con un tipo de cambio.
        /// </summary>
        /// <param name="mone_Id">ID de la moneda.</param>
        /// <param name="taca_Id">ID del tasa de cambio.</param>
        /// <returns>Valor de la moneda según el tipo de cambio.</returns>
        [HttpGet("ObtenerValorMoneda")]
        public IActionResult ObtenerValorMoneda(int mone_Id, int taca_Id)
        {
            var response = _generalService.ObtenerValorMoneda(mone_Id, taca_Id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca una moneda específica por su ID.
        /// </summary>
        /// <param name="id">ID de la moneda a buscar.</param>
        /// <returns>Detalles de la moneda con el ID especificado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarMoneda(int id)
        {
            var response = _generalService.BuscarMoneda(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Crea una nueva moneda en el sistema.
        /// </summary>
        /// <param name="MonedaViewModel">Datos de la nueva moneda a crear.</param>
        /// <returns>Resultado de la creación de la moneda.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(MonedaViewModel MonedaViewModel)
        {
            var modelo = new tbMonedas()
            {
                mone_Nombre = MonedaViewModel.mone_Nombre,
                mone_Abreviatura = MonedaViewModel.mone_Abreviatura,
                pais_Id = MonedaViewModel.pais_Id,
                usua_Creacion = MonedaViewModel.usua_Creacion,
                mone_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarMoneda(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza la información de una moneda existente.
        /// </summary>
        /// <param name="MonedaViewModel">Datos actualizados de la moneda.</param>
        /// <returns>Resultado de la actualización de la moneda.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(MonedaViewModel MonedaViewModel)
        {
            var modelo = new tbMonedas()
            {
                mone_Id = MonedaViewModel.mone_Id,
                mone_Nombre = MonedaViewModel.mone_Nombre,
                mone_Abreviatura = MonedaViewModel.mone_Abreviatura,
                pais_Id = MonedaViewModel.pais_Id,
                usua_Modificacion = MonedaViewModel.usua_Modificacion,
                mone_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarMoneda(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Elimina una moneda específica por su ID.
        /// </summary>
        /// <param name="id">ID de la moneda a eliminar.</param>
        /// <returns>Resultado de la eliminación de la moneda.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarMoneda(id);
            return Ok(response);
        }
    }
}
