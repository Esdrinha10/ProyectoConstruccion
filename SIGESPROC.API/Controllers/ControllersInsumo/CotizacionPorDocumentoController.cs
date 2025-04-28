using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionPorDocumentoController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="insumoService">Servicio que maneja la lógica de negocio relacionada con insumos, maquinaria y equipos de seguridad y cotizaciones.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public CotizacionPorDocumentoController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene una lista de todos los documentos relacionados a una cotizacion en el sistema.
        /// </summary>
        /// <returns>La lista de cotizaciones.</returns>
        [HttpGet("ListarPDF/{id}")]
        public IActionResult ListarPDF(int id)
        {

            var response = _insumoService.ListarCotizacionesPorDocumentoPDF(id);


            return Ok(response.Data);

        }

        [HttpGet("ListarWord/{id}")]
        public IActionResult ListarWord(int id)
        {

            var response = _insumoService.ListarCotizacionesPorDocumentoWord(id);


            return Ok(response.Data);

        }

        [HttpGet("ListarImagenes/{id}")]
        public IActionResult ListarImagenes(int id)
        {

            var response = _insumoService.ListarCotizacionesPorDocumentoImagenes(id);


            return Ok(response.Data);

        }

        /// <summary>
        /// Elimina un documento de una cotizacion especificado por su ID.
        /// </summary>
        /// <param name="id">ID del documento a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpPost("Eliminar")]
        public IActionResult Delete(CotizacionPorDocumentoViewModel cotizacionPorDocumentoViewModel)
        {
            var response = _insumoService.EliminarCotizacionPorDocumento(cotizacionPorDocumentoViewModel.copd_Id);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", cotizacionPorDocumentoViewModel.copd_Documento);

            if (System.IO.File.Exists(fullPath))
            {
                // Elimina el archivo si existe
                System.IO.File.Delete(fullPath);
            }

            return Ok(response);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(CotizacionPorDocumentoViewModel cotizacionPorDocumentoViewModel)
        {
         

                var modelo = new tbCotizaciones()
                {
                    coti_Id = cotizacionPorDocumentoViewModel.coti_Id,
                    copd_Documento = cotizacionPorDocumentoViewModel.copd_Documento,
                    usua_Creacion = cotizacionPorDocumentoViewModel.usua_Creacion,
                    copd_Descripcion = cotizacionPorDocumentoViewModel.copd_Descripcion
                };
                var response =  _insumoService.InsertarCotizacionPorDocumento(modelo);
                return Ok(response);
           
        }

        [HttpPost("SubirDocumento")]
        public async Task<IActionResult> SubirDocumento(IFormFile file)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cotizacion", "documentos");

            // Ensure the directory exists
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, file.FileName);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = Path.GetRelativePath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), filePath);

            return Ok(new { filePath = relativePath });
        }

    }
}
