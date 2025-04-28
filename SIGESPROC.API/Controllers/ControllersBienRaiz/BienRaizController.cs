using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    /// <summary>
    /// Controlador para gestionar los bienes Raices.
    /// Proporciona métodos para CRUD y operaciones específicas sobre las Bien Raizes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BienRaizController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="BienRaizService">Servicio que maneja la lógica de negocio para Bienes Raices.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>

        public BienRaizController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        /// <summary>
        /// <returns>Lista de Bienes Raices.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarBienesRaices()
        {
            var response = _bienRaizService.ListarBienesRaices();
            return Ok(response.Data);
        }
        /// <summary>
        /// Lista todos los Documento Por BienRaiz relacionadas a un bien raiz
        /// </summary>
        /// <param name="id">Id del documento.</param>
        /// <returns>Lista de Documento Por BienRaiz.</returns>
        [HttpGet("DocumentoPorBienRaiz/{id}")]
        public IActionResult DocumentoPorBieneRaiz(int id)
        {
            var response = _bienRaizService.DocumentoPorBienRaiz(id);
            if (response.Success == true)
            {
                return Ok(response.Data);

            }
            else
            {
                return Problem(response.Data);

            }
        }

        /// <summary>
        /// Busca un Bien Raiz  por su Id.
        /// </summary>
        /// <param name="id">Id del bien raiz a buscar.</param>
        /// <returns>La Bien raiz encontrado.</returns>

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarBienRaiz(int id)
        {
            var response = _bienRaizService.BuscarBienRaiz(id);

            return Ok(response.Data);
        }


        /// <summary>
        /// Inserta un nuevo Bien Raiz.
        /// </summary>
        /// <param name="item">Modelo de vista del Bien raiz a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>

        [HttpPost("Insertar")]
        public IActionResult Create(BienRaizViewModel BienRaizViewModel)
        {

            var modelo = new tbBienesRaices()
            {
                bien_Desripcion = BienRaizViewModel.bien_Desripcion,
                pcon_Id = BienRaizViewModel.pcon_Id,
                bien_Imagen = BienRaizViewModel.bien_Imagen,
                bien_Precio = BienRaizViewModel.bien_Precio,
                usua_Creacion = BienRaizViewModel.usua_Creacion,
                bien_FechaCreacion = DateTime.Now
                
            };

            var response = _bienRaizService.InsertarBienRaiz(modelo);

            return Ok(response);
        }
        /// <summary>
        /// Actualiza un Bien Raiz existente.
        /// </summary>
        /// <param name="item">Modelo de vista del Bien Raiz a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>

        [HttpPut("Actualizar")]
        public IActionResult Update(BienRaizViewModel BienRaizViewModel)
        {

            var modelo = new tbBienesRaices()
            {
            
                bien_Id = BienRaizViewModel.bien_Id,
                bien_Desripcion = BienRaizViewModel.bien_Desripcion,
                pcon_Id = BienRaizViewModel.pcon_Id,
                bien_Imagen = BienRaizViewModel.bien_Imagen,
                bien_Precio = BienRaizViewModel.bien_Precio,
                usua_Modificacion = BienRaizViewModel.usua_Modificacion,
                bien_FechaModificacion = DateTime.Now
            };

            var response = _bienRaizService.ActualizarBienRaiz(modelo);

            return Ok(response);
        }


        /// <summary>
        /// Elimina un Bien Raiz especificada por su Id.
        /// </summary>
        /// <param name="id">Id del Bien Raiz a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>

        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        { 
            var result = _bienRaizService.EliminarBienRaiz(id);

            return Ok(result);
        }

        [HttpPut("Desactivar")]
        public IActionResult IdentificadorDesactivado([FromBody] int id)
        {
            var response = _bienRaizService.Desactivaridentificadorbienraiz(id);
            return Ok(response);
        }


    }
}
