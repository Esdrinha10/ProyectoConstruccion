using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.BancoService;
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
    public class BancoController : Controller
    {
        private readonly BancoService _bancoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="bancoService">Servicio que maneja la lógica de negocio relacionada con los bancos.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public BancoController(BancoService bancoService, IMapper mapper)
        {
            _bancoService = bancoService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de todos los bancos en el sistema.
        /// </summary>
        /// <returns>La lista de bancos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarBancos()
        {
            var response = _bancoService.ListarBancos();
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca un banco específico por su ID.
        /// </summary>
        /// <param name="id">ID del banco a buscar.</param>
        /// <returns>El banco encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarBanco(int id)
        {
            var response = _bancoService.BuscarBanco(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Inserta un nuevo banco en el sistema.
        /// </summary>
        /// <param name="bancoViewModel">Modelo de vista de la deducción a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(BancoViewModel bancoViewModel)
        {
            var modelo = _mapper.Map<BancoViewModel, tbBancos>(bancoViewModel);
            var response = _bancoService.InsertarBanco(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un banco existente en el sistema.
        /// </summary>
        /// <param name="bancoViewModel">Modelo de vista del banco a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(BancoViewModel bancoViewModel)
        {
            var modelo = _mapper.Map<BancoViewModel, tbBancos>(bancoViewModel);
            var response = _bancoService.ActualizarBanco(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina un banco especificado por su ID.
        /// </summary>
        /// <param name="id">ID del banco a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _bancoService.EliminarBanco(id);
            return Ok(response);
        }
    }
}
