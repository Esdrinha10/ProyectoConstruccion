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
using Microsoft.Extensions.Configuration;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoBienRaizController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _s3Client;
        // Constructor para inyectar las dependencias del servicio y del mapeador.
        public DocumentoBienRaizController(BienRaizService bienRaizService, IMapper mapper, IConfiguration configuration)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
            _configuration = configuration;
            var awsOptions = _configuration.GetSection("AWS");
            _s3Client = new AmazonS3Client(
                awsOptions["AccessKey"],
                awsOptions["SecretKey"],
               Amazon.RegionEndpoint.USEast2
            );
        }
        /// <summary>
        /// Obtiene una lista de documentos de bienes raíces.
        /// </summary>
        /// <returns>Devuelve una lista de documentos de bienes raíces con un código de estado 200 OK.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarDocumentosBienesRaices()
        {
            var response = _bienRaizService.ListarDocumentoBienRaizs();
            return Ok(response.Data);
        }
        /// <summary>
        /// Obtiene una lista de todos los tipos de documentos asociados a bienes raíces.
        /// </summary>
        /// <remarks>
        /// Este método maneja las solicitudes HTTP GET a la ruta "ListarTipoDocumento". 
        /// </remarks>
        /// <returns>
        /// La respuesta incluye un código 200 OK si la operación es exitosa.
        /// </returns>
        /// <response code="200">devuelve el listado de los tipo de documentos si la operacion fue un exito.</response>
        /// <response code="500">Devuelve un código 500 en caso de error interno del servidor.</response>
        [HttpGet("ListarTipoDocumento")]
        public IActionResult ListarTipoDocumentosBienesRaices()
        {
            var response = _bienRaizService.ListarTipoDocumentoBienRaiz();
            return Ok(response.Data);
        }


        /// <summary>
        /// Busca un documento de bienesraíces por su ID.
        /// </summary>
        /// <param name="id">El ID del documento de bienes raíces que se desea buscar.</param>
        /// <returns>Al final va a retornar todo los documentos asociados a ese bienriaz,con un codigo 200 OK.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarDocumentosBienRaiz(int id)
        {
            var response = _bienRaizService.BuscarDocumentoBienRaiz(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca un documentos asociados a un terreno específico por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se buscan los documentos.</param>
        /// <returns>Una lista de documentos asociados al terreno con el ID especificado,que la respuesta sera un codigo 200 OK</returns>
        [HttpGet("BuscarDocumentosPorTerreno/{id}")]
        public IActionResult BuscarDocumentosPorTerreno(int id)
        {
            var response = _bienRaizService.BuscarDocumentoPorTerreno(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// lista todo los documentos en formato PDF asociados a un bienraíz específico por su ID.
        /// </summary>
        /// <param name="id">El ID del bien raíz para el cual se listan los documentos PDF.</param>
        /// <returns>La lista de documentos PDF con un código 200 OK.</returns>
        [HttpGet("ListarPDF/{id}")]
        public IActionResult ListarPDF(int id)
        {
            var response = _bienRaizService.ListarPDF(id);
            return Ok(response.Data);
        }


        /// <summary>
        /// Obtiene una lista de imágenes asociadas a un bienraíz específico por su ID.
        /// </summary>
        /// <param name="id">El ID del bien raíz para el cual se listan las imágenes.</param>
        /// <returns>La lista de imágenes con un código de estado 200 OK.</returns>
        [HttpGet("ListarImagen/{id}")]
        public IActionResult ListarImagen(int id)
        {
            var response = _bienRaizService.ListarImagen(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Obtiene una lista de documentos en formato Word para un bienraíz específico por su ID.
        /// </summary>
        /// <param name="id">El ID del bien raíz para el cual se listan los documentos Word.</param>
        /// <returns>La lista de documentos Word con un código de estado 200 OK.</returns>
        [HttpGet("ListarWord/{id}")]
        public IActionResult ListarWord(int id)
        {
            var response = _bienRaizService.ListarWord(id);
            return Ok(response.Data);
        }


        /// <summary>
        /// Obtiene una lista de otros tipos de documentos asociados a un bienraíz específico por su ID.
        /// </summary>
        /// <param name="id">El ID del bien raíz para el cual se listan los otros documentos.</param>
        /// <returns>La lista de otros documentos con un código de estado 200 OK.</returns>
        [HttpGet("ListarOtros/{id}")]
        public IActionResult ListarOtros(int id)
        {
            var response = _bienRaizService.ListarOtros(id);
            return Ok(response.Data);
        }
        /// <summary>
        /// Obtiene una lista de documentos en formato Excel asociados a un bienraíz específico por su ID.
        /// </summary>
        /// <param name="id">El ID del bienraíz para el cual se listan los documentos Excel.</param>
        /// <returns>La lista de documentos Excel con un código de estado 200 OK.</returns>
        [HttpGet("ListarExcel/{id}")]
        public IActionResult ListarExcel(int id)
        {
            var response = _bienRaizService.ListarExcel(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta un nuevo documento de bienes raíces o terrenos en la base de datos.
        /// </summary>
        /// <param name="DocumentoBienRaizViewModel">Los datos del documento que se va a insertar, proporcionados en un ViewModel.</param>
        /// <returns>El resultado de la operación de inserción con un código de estado 200 OK.</returns>
        [HttpPost("Insertar")]
        public virtual IActionResult Create(DocumentoBienRaizViewModel DocumentoBienRaizViewModel)
        {       
            var modelo = new tbDocumentosBienRaiz()
            {
                dobt_DescipcionDocumento = DocumentoBienRaizViewModel.dobt_DescipcionDocumento,
                tido_Id = DocumentoBienRaizViewModel.tido_Id,
                dobt_Imagen = DocumentoBienRaizViewModel.dobt_Imagen,
                usua_Creacion = DocumentoBienRaizViewModel.usua_Creacion,
                dobt_FechaCreacion = DateTime.Now,
                dobt_Terreno_O_BienRaizId = DocumentoBienRaizViewModel.dobt_Terreno_O_BienRaizId,
                dobt_Terreno_O_BienRaizbit = DocumentoBienRaizViewModel.dobt_Terreno_O_BienRaizbit,
            };
            var response = _bienRaizService.InsertarDocumentoBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un documento de bienes raíces o terrenos existente en la base de datos.
        /// </summary>
        /// <param name="DocumentoBienRaizViewModel">Los datos actualizados del documento, proporcionados en un ViewModel.</param>
        /// <returns>El resultado de la operación de actualización con un código de estado 200 OK.</returns>
        [HttpPut("Actualizar")]
        public virtual IActionResult Update(DocumentoBienRaizViewModel DocumentoBienRaizViewModel)
        {            

            var modelo = new tbDocumentosBienRaiz()
            {
                dobt_Id = DocumentoBienRaizViewModel.dobt_Id,
                dobt_DescipcionDocumento = DocumentoBienRaizViewModel.dobt_DescipcionDocumento,
                tido_Id = DocumentoBienRaizViewModel.tido_Id,
                dobt_Imagen = DocumentoBienRaizViewModel.dobt_Imagen,
                usua_Modificacion = DocumentoBienRaizViewModel.usua_Modificacion,
                dobt_FechaModificacion = DateTime.Now,
                dobt_Terreno_O_BienRaizId = DocumentoBienRaizViewModel.dobt_Terreno_O_BienRaizId,
                dobt_Terreno_O_BienRaizbit = DocumentoBienRaizViewModel.dobt_Terreno_O_BienRaizbit,
            };
            var response = _bienRaizService.ActualizarDocumentoBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina  documentos de bien raíz basado en su ID.
        /// </summary>
        /// <param name="id">El ID del documento que se desea eliminar.</param>
        /// <returns>El resultado de la operación de eliminación con un código de estado 200 OK.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _bienRaizService.EliminarDocumentoBienRaiz(id);
            return Ok(response);

        }
        /// <summary>
        /// Elimina un documento de terreno asociado en su ID.
        /// </summary>
        /// <param name="id">El ID del documento de terreno que se desea eliminar.</param>
        /// <returns>El resultado de la operación de eliminación.</returns>
        [HttpDelete("EliminarTerreno")]
        public IActionResult Deleteterreno(int id)
        {
            var response = _bienRaizService.EliminarDocumentoTerreno(id);
            return Ok(response);

        }


        /// <summary>
        /// Maneja la carga de archivos mediante una solicitud HTTPPOST.
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
     
        ".png", ".jpeg", ".jpg", ".gif", ".bmp", ".ico", ".tif", ".tiff", ".webp",   // Esto es para la imagenes
        
        ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".rtf", ".csv",// Esto serian los documentos
       
        ".zip", ".rar", ".7z", ".tar.gz", // Aqui por si las dudas tambien acepta archivos comprimidos
    
        ".xml", ".json", ".yaml", ".yml",    //tambien acepta archivos de texto
       
        ".html", ".htm", ".css", ".js", ".php", ".cs", ".java", ".cpp", ".h", ".vb", ".sql" // Y aqui seria otro tipos de documento
    };   
            var fileExtension = Path.GetExtension(file.FileName).ToLower();   
            var audioVideoExtensions = new HashSet<string> {// Aca yo defino un conjunto de extensiones de archivo de audio y video que no están permitidos.
        ".mp3", ".wav", ".ogg", ".mp4", ".avi", ".mov", ".mkv", ".flv", ".wmv"
    };
            if (audioVideoExtensions.Contains(fileExtension))
            {
                return BadRequest("Extensión de archivo no permitida.");
            }
            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");     
            if (!Directory.Exists(uploadsFolderPath)) //En este si la carpeta de Imagenes/Documentos no existe, la creo.
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }   
            var filePath = Path.Combine(uploadsFolderPath, file.FileName); 
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create)) 
                {  
                    await file.CopyToAsync(stream); 
                } 
                return Ok(new { message = "Éxito" });
            }
            catch (Exception e)
            {           
                return StatusCode(500, $"Error general: {e.Message}"); 
            }
        }

        /// <summary>
        /// Obtiene un archivo PDF relacionado con un terreno específico mediante su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se obtiene el archivo PDF.</param>
        /// <returns>El archivo PDF asociado con el terreno</returns>
        [HttpGet("ListarTerrenoPDF/{id}")]
        public IActionResult ListarTerrenoPDF(int id)
        {
            var response = _bienRaizService.ListarTerrenoPDF(id);
            return Ok(response.Data); 
        }



        /// <summary>
        /// Obtiene la imagen asociada a un terreno específico mediante su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se obtiene la imagen.</param>
        /// <returns>La imagen asociada al terreno</returns>
        [HttpGet("ListarTerrenoImagen/{id}")]
        public IActionResult ListarTerrenoImagen(int id)
        {
            var response = _bienRaizService.ListarTerrenoImagen(id); 
            return Ok(response.Data);  
        }

        /// <summary>
        /// Obtiene el archivo Excel asociado a un terreno específico mediante su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se obtiene el archivo Excel.</param>
        /// <returns>El archivo Excel asociado al terreno</returns>
        [HttpGet("ListarTerrenoExcel/{id}")]
        public IActionResult ListarTerrenoExcel(int id)
        {
            var response = _bienRaizService.ListarTerrenoExcel(id);
            return Ok(response.Data);

        }

        /// <summary>
        /// Obtiene el archivo Word asociado a un terreno específico mediante su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se obtiene el archivo Word.</param>
        /// <returns>El archivo Word asociado al terreno</returns>
        [HttpGet("ListarTerrenoWord/{id}")]
        public IActionResult ListarTerrenoWord(int id)
        {
            var response = _bienRaizService.ListarTerrenoWord(id);
            return Ok(response.Data);
        }


        /// <summary>
        /// Obtiene otros tipos de archivos asociados a un terreno específico mediante su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se obtienen los archivos.</param>
        /// <returns>Otros tipos de archivos/Documentos asociados al terreno</returns>
        [HttpGet("ListarTerrenoOtros/{id}")]
        public IActionResult ListarTerrenoOtro(int id)
        {
            var response = _bienRaizService.ListarTerrenoOtros(id); 
            return Ok(response.Data);
        }
    }
}
