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
    public class TipoDocumentoController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;

        public TipoDocumentoController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        /// <summary>
        /// Lista todos los Tipos de documentos disponibles.
        /// </summary>
        /// <returns>Lista de Tipos de documentos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarTipoDocumento()
        {
            var response = _bienRaizService.ListarTipoDocumento();
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta un nuevo Tipo de documento en el sistema.
        /// </summary>
        /// <param name="TipoDocumentoViewModel">El modelo de vista que contiene los datos de tipo de documentos a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(TipoDocumentoViewModel TipoDocumentoViewModel)
        {
            var modelo = new tbTiposDocumentos()  
            {
                tido_Descripcion = TipoDocumentoViewModel.tido_Descripcion,
                usua_Creacion = TipoDocumentoViewModel.usua_Creacion,
                tido_FechaCreacion = DateTime.Now,
              
            };
            var response = _bienRaizService.InsertarTipoDocumento(modelo);  
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un tipo de documento existente en el sistema.
        /// </summary>
        /// <param name="TipoDocumentoViewModel">El modelo de vista que contiene los datos actualizados de tipos de documentos.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(TipoDocumentoViewModel TipoDocumentoViewModel)
        {
            var modelo = new tbTiposDocumentos()
            {
                tido_Id = Convert.ToInt32(TipoDocumentoViewModel.tido_Id), 
                tido_Descripcion = TipoDocumentoViewModel.tido_Descripcion,
                usua_Mofificacion = TipoDocumentoViewModel.usua_Mofificacion,
                tido_FechaModificacion = DateTime.Now,
            };
            var response = _bienRaizService.ActualizarTipoDocumento(modelo);
            return Ok(response); 
        }
        /// <summary>
        /// Elimina un tipo de documento del sistema por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo de documento que se desea eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        //[HttpDelete("Eliminar")]
        //public IActionResult Delete(int id)
        //{
        //    var response = _bienRaizService.EliminarTipoDocumento(id); 
        //    return Ok(response);
        //}

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var result = _bienRaizService.EliminarTipoDocumento(id);
            return Ok(result);
        }
    }
}
