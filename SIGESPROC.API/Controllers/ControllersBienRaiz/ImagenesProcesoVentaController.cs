using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ProcesosVentaService;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{

    /// <summary>
    /// Controlador para gestionar los Imagenes  del proceso de venta.
    /// Proporciona métodos para CRUD y operaciones específicas sobre las Imagenes del proceso de venta.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesProcesoVentaController : Controller
    {
        private readonly ProcesoVentaService _procesoVentaService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="ProcesoVentaService">Servicio que maneja la lógica de negocio para Imagenes proceo de venta.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>

        public ImagenesProcesoVentaController (ProcesoVentaService procesoVentaService, IMapper mapper)
        {
            _procesoVentaService = procesoVentaService;
                _mapper = mapper;
        }
        /// <summary>
        /// Busca una Imagenes proceso de venta  por su Id.
        /// </summary>
        /// <param name="id">Id del Imagenes proceso de venta a buscar.</param>
        /// <returns>La Imagenes proceso de venta encontrado.</returns>

        [HttpGet("Buscar/{id}")]
        public IActionResult ListarImagenesProcesoVenta(int id)
        {
            var result = _procesoVentaService.ListarImagenProcesosVenta(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Inserta una nueva Imagenes proceso de venta.
        /// </summary>
        /// <param name="item">Modelo de vista del Imagenes proceso de venta a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>


        [HttpPost("Insertar")]
        public virtual IActionResult Create(List<ImageneProcesoVentaViewModel> imagenesViewModel)
        {
            var imagenes = imagenesViewModel.Select(modelo => new tbImagenesPorProcesosVentas()
            {
                btrp_Id = modelo.btrp_Id,
                impr_Imagen = modelo.impr_Imagen,
                usua_Creacion = modelo.usua_Creacion,
                impr_FechaCreacion = DateTime.Now
            }).ToList();

            var response = _procesoVentaService.InsertarImagenesProcesoVenta(imagenes);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza una Imagenes proceso de venta existente.
        /// </summary>
        /// <param name="item">Modelo de vista de las Imagenes proceso de venta a actualizar.</param>
        /// <returns>Resultado de la operación de actualización.</returns>

        [HttpPut("Actualizar")]
        public virtual IActionResult Update(ImageneProcesoVentaViewModel terrenoViewModel)
        {
            var modelo = new tbImagenesPorProcesosVentas()
            {
                impr_Id = Convert.ToInt32(terrenoViewModel.impr_Id),
                btrp_Id = terrenoViewModel.btrp_Id,
                impr_Imagen = terrenoViewModel.impr_Imagen,
                usua_Modificacion = terrenoViewModel.usua_Modificacion,
                impr_FechaModificacion = DateTime.Now
            };
            var response = _procesoVentaService.ActualizarImagenProcesoVenta(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Elimina una Imagene proceso de venta especificada por su Id.
        /// </summary>
        /// <param name="id">Id de las Imagenes proceso de venta a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _procesoVentaService.EliminarImagenProcesoVenta(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        /// <summary>
        /// Busca una Documentos por su Id.
        /// </summary>
        /// <param name="tipo">Identificar si es bien raiz o doumento.</param>
        /// <param name="id">Id documento o bien raiz a buscar.</param>
        /// <returns>Documentos encontrados.</returns>

        [HttpGet("Documento/{tipo}/{id}")]
        public IActionResult ListarDocumentosTerrenos(int tipo, int id)
        {
            var response = _procesoVentaService.BuscarDocumentacionProcesoVenta(tipo, id);
            return Ok(response);
        }



    }
}
