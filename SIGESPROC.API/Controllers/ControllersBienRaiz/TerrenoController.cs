using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerrenoController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;

        public TerrenoController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        /// <summary>
        /// Lista todos los terrenos disponibles.
        /// </summary>
        /// <returns>Lista de terrenos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarTerrenos()
        {
            var response = _bienRaizService.ListarTerrenos();
            return Ok(response.Data);
        }
        /// <summary>
        /// Lista todos los terrenos con sus identificador = 0.
        /// </summary>
        /// <returns>Lista de terrenos con identificador = 0.</returns>
        [HttpGet("ListarIdentificador")]
        public IActionResult ListarTerrenos_Identificador()
        {
            var response = _bienRaizService.ListarTerrenosIdentificador();
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca un terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno que se desea buscar.</param>
        /// <returns>El terreno encontrado por medio del ID proporcionado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarTerreno(int id)
        {
            var response = _bienRaizService.BuscarTerreno(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Obtiene los documentos asociados a un terreno específico por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se desean obtener los documentos.</param>
        /// <returns>Devuelve los documentos asociados al terreno si la operación es exitosa.</returns>
        /// <response code="400">Devuelve un mensaje de error si la operación falla.</response>
        [HttpGet("DocumentoPorTerreno/{id}")]
        public IActionResult DocumentoPorTerreno(int id)
        {
            var response = _bienRaizService.DocumentoPorTerreno(id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        /// <summary>
        /// Inserta un nuevo terreno en el sistema.
        /// </summary>
        /// <param name="terrenoViewModel">El modelo de vista que contiene los datos del terreno a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(TerrenoViewModel terrenoViewModel)
        {
            var modelo = new tbTerrenos() 
            {
                terr_Descripcion = terrenoViewModel.terr_Descripcion,
                terr_Area = terrenoViewModel.terr_Area,
                terr_Estado = false,
                terr_PecioCompra = terrenoViewModel.terr_PecioCompra,
                //terr_PrecioVenta = terrenoViewModel.terr_PrecioVenta,
                terr_LinkUbicacion = terrenoViewModel.terr_LinkUbicacion,
                terr_Imagen = terrenoViewModel.terr_Imagen,
                terr_Longitud = terrenoViewModel.terr_Longitud,
                terr_Latitud = terrenoViewModel.terr_Latitud,
                usua_Creacion = terrenoViewModel.usua_Creacion,
                terr_FechaCreacion = DateTime.Now
            };
            var response = _bienRaizService.InsertarTerreno(modelo); 
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un terreno existente en el sistema.
        /// </summary>
        /// <param name="terrenoViewModel">El modelo de vista que contiene los datos actualizados del terreno.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")] 
        public IActionResult Update(TerrenoViewModel terrenoViewModel)
        {
            var modelo = new tbTerrenos() 
            {
                terr_Id = Convert.ToInt32(terrenoViewModel.terr_Id),
                terr_Descripcion = terrenoViewModel.terr_Descripcion,
                terr_Area = terrenoViewModel.terr_Area,
                terr_Estado = true,
                terr_PecioCompra = terrenoViewModel.terr_PecioCompra,
                //terr_PrecioVenta = terrenoViewModel.terr_PrecioVenta,
                terr_LinkUbicacion = terrenoViewModel.terr_LinkUbicacion,
                terr_Imagen = terrenoViewModel.terr_Imagen,
                terr_Longitud = terrenoViewModel.terr_Longitud,
                terr_Latitud = terrenoViewModel.terr_Latitud,
                usua_Modificacion = terrenoViewModel.usua_Modificacion,
                terr_FechaModificacion = DateTime.Now
            };
            var response = _bienRaizService.ActualizarTerreno(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina un terreno del sistema por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno que se desea eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")] 
        public IActionResult Delete(int id) 
        {
            var response = _bienRaizService.EliminarTerreno(id);
            return Ok(response);
        }

        /// <summary>
        /// Desactiva un identificador de terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del identificador que se desea desactivar(Significa que el terreno no esta en proyecto).</param>
        /// <returns>Resultado de la operación de desactivación.</returns>
        [HttpDelete("Desactivar")] 
        public IActionResult IdentificadorDesactivado(int id)
        {
            var response = _bienRaizService.Desactivaridentificador(id);
            return Ok(response);
        }
    }
}
