using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
using SIGESPROC.Common.Models.ModelsFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using Microsoft.Extensions.Configuration;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using System.IO;



namespace SIGESPROC.API.Controllers.ControllersFlete
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleteEncabezadoController : Controller
    {
        private readonly FleteService _fleteService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _s3Client;
        // Constructor del controlador que recibe el servicio de fletes y el mapeador
        public FleteEncabezadoController(FleteService proyectoService, IMapper mapper
            , IConfiguration configuration)
        {
            _fleteService = proyectoService;
            _mapper = mapper;
            _configuration = configuration;
            var awsOptions = _configuration.GetSection("AWS");
            _s3Client = new AmazonS3Client(
                awsOptions["AccessKey"],
                awsOptions["SecretKey"],
                Amazon.RegionEndpoint.USEast2
            );
        }

        // Método para listar todos los fletes
        [HttpGet("Listar")]
        public IActionResult ListarFlete()
        {
            var response = _fleteService.ListarFletes(); // Llama al servicio para listar los fletes
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        // Método para buscar un flete por su ID
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarFlete(int id)
        {
            var response = _fleteService.BuscarFlete(id); // Llama al servicio para buscar el flete por su ID
            return Ok(response.Data); // Retorna los datos obtenidos en la respuesta
        }

        // Método para insertar un nuevo flete
        [HttpPost("Insertar")]
        public IActionResult Create(FleteEncabezadoViewModel FleteViewModel)
        {
            var modelo = new tbFletesEncabezado()
            {
                flen_FechaHoraSalida = FleteViewModel.flen_FechaHoraSalida,
                flen_FechaHoraEstablecidaDeLlegada = FleteViewModel.flen_FechaHoraEstablecidaDeLlegada,
                emtr_Id = FleteViewModel.emtr_Id,
                emss_Id = FleteViewModel.emss_Id,
                emsl_Id = FleteViewModel.emsl_Id,
                boas_Id = FleteViewModel.boas_Id,
                flen_DestinoProyecto = FleteViewModel.flen_DestinoProyecto,
                flen_SalidaProyecto = FleteViewModel.flen_SalidaProyecto,
                flen_Estado = FleteViewModel.flen_Estado,
                boat_Id = FleteViewModel.boat_Id,
                usua_Creacion = FleteViewModel.usua_Creacion,
                flen_FechaCreacion = DateTime.Now // Establece la fecha de creación al momento actual
            };
            var response = _fleteService.InsertarFlete(modelo); // Llama al servicio para insertar el nuevo flete
            return Ok(response); // Retorna la respuesta del servicio
        }

        // Método para actualizar un flete existente
        [HttpPut("Actualizar")]
        public IActionResult Update(FleteEncabezadoViewModel FleteViewModel)
        {
            try
            {
                // Imprime en consola los datos recibidos en el controlador para depuración
                Console.WriteLine("Recibido en el controlador: " + Newtonsoft.Json.JsonConvert.SerializeObject(FleteViewModel));

                var modelo = new tbFletesEncabezado()
                {
                    flen_Id = FleteViewModel.flen_Id,
                    flen_FechaHoraSalida = FleteViewModel.flen_FechaHoraSalida,
                    flen_FechaHoraEstablecidaDeLlegada = FleteViewModel.flen_FechaHoraEstablecidaDeLlegada,
                    flen_FechaHoraLlegada = FleteViewModel.flen_FechaHoraLlegada,
                    emtr_Id = FleteViewModel.emtr_Id,
                    emss_Id = FleteViewModel.emss_Id,
                    emsl_Id = FleteViewModel.emsl_Id,
                    boas_Id = FleteViewModel.boas_Id,
                    flen_ComprobanteLLegada = FleteViewModel.flen_ComprobanteLLegada,
                    flen_DestinoProyecto = FleteViewModel.flen_DestinoProyecto,
                    flen_SalidaProyecto = FleteViewModel.flen_SalidaProyecto,
                    flen_Estado = FleteViewModel.flen_Estado,
                    boat_Id = FleteViewModel.boat_Id,
                    usua_Modificacion = FleteViewModel.usua_Modificacion,
                    flen_FechaModificacion = DateTime.Now // Establece la fecha de modificación al momento actual
                };

                var response = _fleteService.ActualizarFlete(modelo); // Llama al servicio para actualizar el flete
                return Ok(response); // Retorna la respuesta del servicio
            }
            catch (Exception ex)
            {
                // Imprime en consola el mensaje de error para depuración
                Console.WriteLine("Error en el controlador: " + ex.Message);
                return BadRequest(new { message = ex.Message, details = ex.ToString() }); // Retorna un error con detalles
            }
        }

        [HttpPost("ActualizarFlete")]
        public IActionResult ActualizarFlete(FleteEncabezadoViewModel FleteViewModel)
        {
            try
            {
                Console.WriteLine("Recibido en el controlador: " + Newtonsoft.Json.JsonConvert.SerializeObject(FleteViewModel));

                var modelo = new tbFletesEncabezado()
                {
                    flen_Id = FleteViewModel.flen_Id,
                    flen_FechaHoraSalida = FleteViewModel.flen_FechaHoraSalida,
                    flen_FechaHoraEstablecidaDeLlegada = FleteViewModel.flen_FechaHoraEstablecidaDeLlegada,
                    flen_FechaHoraLlegada = FleteViewModel.flen_FechaHoraLlegada,
                    emtr_Id = FleteViewModel.emtr_Id,
                    emss_Id = FleteViewModel.emss_Id,
                    emsl_Id = FleteViewModel.emsl_Id,
                    boas_Id = FleteViewModel.boas_Id,
                    flen_ComprobanteLLegada = FleteViewModel.flen_ComprobanteLLegada,
                    flen_DestinoProyecto = FleteViewModel.flen_DestinoProyecto,
                    flen_SalidaProyecto = FleteViewModel.flen_SalidaProyecto,
                    flen_Estado = FleteViewModel.flen_Estado,
                    boat_Id = FleteViewModel.boat_Id,
                    usua_Modificacion = FleteViewModel.usua_Modificacion,
                    flen_FechaModificacion = DateTime.Now
                };

                var response = _fleteService.ActualizarFlete(modelo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el controlador: " + ex.Message);
                return BadRequest(new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Método para eliminar un flete por su ID
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _fleteService.EliminarFlete(id); // Llama al servicio para eliminar el flete por su ID
            return Ok(response); // Retorna la respuesta del servicio
        }



        [HttpPost("SubirDocumento")]
        public async Task<IActionResult> SubirDocumento(IFormFile file)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "flete", "documentos");

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


        /// <summary>
        /// Maneja la carga de archivos de comprobante de llegada.
        /// </summary>
        /// <param name="file">El archivo a subir.</param>
        /// <returns>Una respuesta que indica el resultado de la operación de carga.</returns>
        /// <response code="200">Devuelve un mensaje de éxito si el archivo se carga correctamente.</response>
        /// <response code="400">Devuelve un mensaje de error si el archivo no se selecciona o tiene una extensión no permitida.</response>
        /// <response code="500">Devuelve un mensaje de error si ocurre un problema al guardar el archivo.</response>

        [HttpPost("Subir")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Archivo no seleccionado o vacío.");
            }

            var allowedExtensions = new HashSet<string> {
        ".png", ".jpeg", ".jpg", ".gif", ".bmp", ".ico", ".tif", ".tiff", ".webp", // Imágenes
        ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".rtf", ".csv", // Documentos
        ".zip", ".rar", ".7z", ".tar.gz", // Archivos comprimidos
        ".xml", ".json", ".yaml", ".yml", // Archivos de texto
        ".html", ".htm", ".css", ".js", ".php", ".cs", ".java", ".cpp", ".h", ".vb", ".sql" // Otros documentos
    };

            var extension = Path.GetExtension(file.FileName).ToLower(); // Renombré la variable a 'extension'
            var audioVideoExtensions = new HashSet<string> {
        ".mp3", ".wav", ".ogg", ".mp4", ".avi", ".mov", ".mkv", ".flv", ".wmv" // Audio y video no permitidos
    };

            if (audioVideoExtensions.Contains(extension))
            {
                return BadRequest("Extensión de archivo no permitida.");
            }

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName); // Renombré esta variable también para evitar confusiones
            var newFileName = $"{fileNameWithoutExtension}_{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolderPath, newFileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{newFileName}";
                return Ok(new { message = "Éxito", fileUrl = fileUrl });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error general: {e.Message}");
            }
        }



    }
}
