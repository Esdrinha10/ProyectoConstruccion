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
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaBienesRaicesController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        // Constructor para inyectar las dependencias del servicio y del mapeador.

        public EmpresaBienesRaicesController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene una lista de todas las empresas asociadas a bienes raíces.
        /// </summary>
        /// <returns>Una lista de todas las empresas.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarEmpresaBienRaizs()
        {
            var response = _bienRaizService.ListarEmpresaBienRaizs();
            return Ok(response.Data);
        }
        /// <summary>
        /// Busca una empresa asociada a bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID de la empresa que se desea buscar.</param>
        /// <returns>Los detalles de la empresa encontrada.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarEmpresaBienRaiz(int id)
        {
            var response = _bienRaizService.BuscarEmpresaBienRaiz(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta una nueva empresa asociada a bienes raíces.
        /// </summary>
        /// <param name="EmpresaBienesRaicesViewModel">Los datos de la nueva empresa que se desea agregar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public virtual IActionResult Create(EmpresaBienesRaicesViewModel EmpresaBienesRaicesViewModel)
        {
            var modelo = new tbEmpresasBienesRaices()
            {
                embr_Nombre = EmpresaBienesRaicesViewModel.embr_Nombre,
                embr_ContactoA = EmpresaBienesRaicesViewModel.embr_ContactoA,
                embr_ContactoB = EmpresaBienesRaicesViewModel.embr_ContactoB,
                embr_TelefonoA = EmpresaBienesRaicesViewModel.embr_TelefonoA,
                embr_TelefonoB = EmpresaBienesRaicesViewModel.embr_TelefonoB,
                usua_Creacion = EmpresaBienesRaicesViewModel.usua_Creacion,
                embr_FechaCreacion = DateTime.Now

            };
            var response = _bienRaizService.InsertarEmpresaBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza la información de una empresa asociada a bienes raíces.
        /// </summary>
        /// <param name="EmpresaBienesRaicesViewModel">El objeto que contiene la información actualizada de la empresa.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public virtual IActionResult Update(EmpresaBienesRaicesViewModel EmpresaBienesRaicesViewModel)
        {
            

            var modelo = new tbEmpresasBienesRaices()
            {
                embr_Id = EmpresaBienesRaicesViewModel.embr_Id,
                embr_Nombre = EmpresaBienesRaicesViewModel.embr_Nombre,
                embr_ContactoA = EmpresaBienesRaicesViewModel.embr_ContactoA,
                embr_ContactoB = EmpresaBienesRaicesViewModel.embr_ContactoB,
                embr_TelefonoA = EmpresaBienesRaicesViewModel.embr_TelefonoA,
                embr_TelefonoB = EmpresaBienesRaicesViewModel.embr_TelefonoB,
                usua_Modificacion = EmpresaBienesRaicesViewModel.usua_Modificacion,
                embr_FechaModificacion = DateTime.Now
            };
           

            var response = _bienRaizService.ActualizarEmpresaBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina una empresa asociada a un bien raíz por su ID.
        /// </summary>
        /// <param name="id">El ID de la empresa que se desea eliminar. Se proporciona en el cuerpo de la solicitud.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int? id)
        {
            var result = _bienRaizService.EliminarEmpresaBienRaiz(id);
            return Ok(result);
        }

    }
}
