using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public DocumentoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }


        [HttpGet("Listar/{id}")]
        public IActionResult ListarDocumento(int? id)
        {
            var response = _proyectoService.ListarDocumento(id);

            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarDocumento(int id)
        {
            var response = _proyectoService.BuscarDocumento(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(DocumentoViewModel item)
        {
            var model = _mapper.Map<tbDocumentos>(item);

            var response = _proyectoService.InsertarDocumento(model);

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(DocumentoViewModel item)
        {
            var model = _mapper.Map<tbDocumentos>(item);

            var response = _proyectoService.ActualizarDocumento(model);
            return Ok(response);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarDocumento(id);
            return Ok(response);
        }

        [HttpPost("SubirDocumento")]
        public async Task<IActionResult> SubirDocumento(IFormFile file)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "proyecto", "documentos");

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

