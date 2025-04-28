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
    public class PrestamoController : Controller
    {
        private readonly PrestamoService _prestamoService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="prestamoService">Servicio que maneja la lógica de negocio relacionada con los préstamos.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public PrestamoController(PrestamoService prestamoService, IMapper mapper)
        {
            _prestamoService = prestamoService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de todos los préstamos en el sistema.
        /// </summary>
        /// <returns>La lista de préstamos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarPrestamos()
        {
            var response = _prestamoService.ListarPrestamos();
            var responseAbonos = _prestamoService.ListarAbonos();
            List<tbAbonosPorPrestamos> abonos = responseAbonos.Data;

            foreach (var item in abonos)
            {
                item.fecha = item.abpr_Fecha.ToString("dd/MM/yyyy");
            }

            foreach (var item in response.Data)
            {
                var itemAbonos = abonos.Where(abono => abono.pres_Id == item.pres_Id).ToList();
                for (int i = 0; i < itemAbonos.Count; i++)
                {
                    itemAbonos[i].codigo = i + 1;
                }
                item.abonos = itemAbonos;
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un préstamo específico por su ID.
        /// </summary>
        /// <param name="id">ID del préstamo a buscar.</param>
        /// <returns>El préstamo encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPrestamo(int id)
        {
            var response = _prestamoService.BuscarPrestamo(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Inserta un nuevo préstamo en el sistema.
        /// </summary>
        /// <param name="prestamoViewModel">Modelo de vista del préstamo a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(PrestamoViewModel prestamoViewModel)
        {
            var modelo = _mapper.Map<PrestamoViewModel, tbPrestamos>(prestamoViewModel);
            var response = _prestamoService.InsertarPrestamo(modelo);
            return Ok(response);

        }
        /// <summary>
        /// Inserta un nuevo abono a un préstamo en el sistema.
        /// </summary>
        /// <param name="abonoViewModel">Modelo de vista del abono a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("InsertarAbono")]
        public IActionResult CreateAbono(AbonosPorPrestamosViewModel abonoViewModel)
        {
            var modelo = _mapper.Map<AbonosPorPrestamosViewModel, tbAbonosPorPrestamos>(abonoViewModel);
            var response = _prestamoService.InsertarAbono(modelo);
            return Ok(response);

        }
        /// <summary>
        /// Actualiza un préstamo existente en el sistema.
        /// </summary>
        /// <param name="item">Modelo de vista del préstamo a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(PrestamoViewModel prestamoViewModel)
        {
            var modelo = _mapper.Map<PrestamoViewModel, tbPrestamos>(prestamoViewModel);
            var response = _prestamoService.ActualizarPrestamo(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un abono de un préstamo existente en el sistema.
        /// </summary>
        /// <param name="abonoViewModel">Modelo de vista del abono del préstamo a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("ActualizarAbono")]
        public IActionResult UpdateAbono(AbonosPorPrestamosViewModel abonoViewModel)
        {
            var modelo = _mapper.Map<AbonosPorPrestamosViewModel, tbAbonosPorPrestamos>(abonoViewModel);
            var response = _prestamoService.ActualizarAbono(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina un préstamo especificado por su ID.
        /// </summary>
        /// <param name="id">ID del préstamo a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _prestamoService.EliminarPrestamo(id);
            return Ok(response);
        }
    }
}
