using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.DataAccess;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="generalService">Servicio que maneja la lógica de negocio relacionada con el esquema general.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public EmpleadoController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de todos los empleados en el sistema.
        /// </summary>
        /// <returns>La lista de bancos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarEmpleados()
        {
            var response = _generalService.ListarEmpleados();
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca un empleado específico por su ID.
        /// </summary>
        /// <param name="id">ID del empleado a buscar.</param>
        /// <returns>El empleado encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarEmpleados(int id)
        {
            var response = _generalService.BuscarEmpleado(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca un empleado específico por su DNI.
        /// </summary>
        /// <param name="id">DNI del empleado a buscar.</param>
        /// <returns>El empleado encontrado.</returns>
        [HttpGet("BuscarPorDNI/{DNI}")]
        public IActionResult BuscarEmpleadosPorDNI(string DNI)
        {
            var response = _generalService.BuscarEmpleadoPorDNI(DNI);
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca la imagen de un empleado específico por su empl_Id.
        /// Acepta que cualquier persona pida la imagen.
        /// </summary>
        /// <param name="empl_Id">Id del empleado.</param>
        /// <returns>La imagen del empleado encontrado.</returns>
        [AllowAnonymous]
        [HttpGet("ObtenerImagen")]
        public async Task<IActionResult> ObtenerImagen(int empl_Id)
        {
            var response = await _generalService.ObtenerImagen(empl_Id);

            if (response.Success)
            {
                var imageResult = (ImageDataResult)response.Data;
                return File(imageResult.ImageData, imageResult.ContentType);
            }
            else
            {
                return Ok(response);
            }
        }
        /// <summary>
        /// Inserta una imagen de un empleado en el sistema.
        /// </summary>
        /// <param name="empleadoViewModel">Modelo de vista del empleado a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(EmpleadoViewModel empleadoViewModel)
        {
            var modelo = _mapper.Map<EmpleadoViewModel, tbEmpleados>(empleadoViewModel);
            var response = _generalService.InsertarEmpleado(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Sube la imagen de un empleado en el sistema.
        /// </summary>
        /// <param name="imagen">La imagen.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost("SubirImagen")]
        public async Task<IActionResult> SubirImagen(IFormFile imagen)
        {
            var response = await _generalService.ActualizarImagenDelEmpleado(imagen);
            return Ok(response);
        }
        /// <summary>
        /// Quita la imagen de un empleado en el sistema.
        /// </summary>
        /// <param name="imagen">La imagen.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost("QuitarImagen")]
        public IActionResult QuitarImagen(int empl_Id)
        {
            var response = _generalService.QuitarImagenDelEmpleado(empl_Id);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un empleado existente en el sistema.
        /// </summary>
        /// <param name="empleadoViewModel">Modelo de vista del empleado a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(EmpleadoViewModel empleadoViewModel)
        {
            var modelo = _mapper.Map<EmpleadoViewModel, tbEmpleados>(empleadoViewModel);
            var response = _generalService.ActualizarEmpleado(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza el estado a 'Desactivado' de un empleado existente en el sistema.
        /// </summary>
        /// <param name="empleadoViewModel">Modelo de vista del empleado a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Desactivar")]
        public IActionResult Desactivar(EmpleadoViewModel empleadoViewModel)
        {
            var modelo = _mapper.Map<EmpleadoViewModel, tbEmpleados>(empleadoViewModel);
            var response = _generalService.DesactivarEmpleado(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza el estado a 'Activo' de un empleado existente en el sistema.
        /// </summary>
        /// <param name="empleadoViewModel">Modelo de vista del empleado a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Activar")]
        public IActionResult Activar(EmpleadoViewModel empleadoViewModel)
        {
            var modelo = _mapper.Map<EmpleadoViewModel, tbEmpleados>(empleadoViewModel);
            var response = _generalService.ActivarEmpleado(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Obtiene una lista del historial de pago de un empleado.
        /// </summary>
        /// <returns>La lista de registros HistorialDePagoViewModel.</returns>
        [HttpGet("HistorialDePago")]
        public IActionResult HistorialDePago(int empl_Id)
        {
            var response = _generalService.HistorialDePago(empl_Id);
            return Ok(response.Data);
        }
    }
}
