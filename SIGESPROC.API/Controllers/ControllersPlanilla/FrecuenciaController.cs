using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersPlanilla
{
    // Atributo para definir la ruta base del controlador y especificar que es un controlador de API
    [Route("api/[controller]")]
    [ApiController]
    public class FrecuenciaController : Controller
    {
        private readonly FrecuenciaService _frecuenciaService;
        private readonly IMapper _mapper;

        // Constructor de la clase FrecuenciaController que recibe un servicio de frecuencias y un mapper
        public FrecuenciaController(FrecuenciaService frecuenciaService, IMapper mapper)
        {
            _frecuenciaService = frecuenciaService;
            _mapper = mapper;
        }

        // Método para listar todas las frecuencias
        [HttpGet("Listar")]
        public IActionResult ListarNiveles()
        {
            // Llama al servicio para obtener la lista de frecuencias y devuelve los datos en la respuesta
            var response = _frecuenciaService.ListarFrecuencia();
            return Ok(response.Data);
        }

        // Método para buscar una frecuencia por su ID
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarNiveles(int id)
        {
            // Llama al servicio para buscar una frecuencia por su ID y devuelve los datos en la respuesta
            var response = _frecuenciaService.BuscarFrecuencia(id);
            return Ok(response.Data);
        }

        // Método para insertar una nueva frecuencia
        [HttpPost("Insertar")]
        public IActionResult Create(FrecuenciaViewModel FrecViewModel)
        {
            // Crea un nuevo objeto de tipo tbFrecuencias con los datos recibidos en el modelo
            var modelo = new tbFrecuencias()
            {
                frec_Descripcion = FrecViewModel.frec_Descripcion,
                usua_Creacion = FrecViewModel.usua_Creacion,
                frec_NumeroDias = FrecViewModel.frec_NumeroDias,
                frec_FechaCreacion = DateTime.Now // Asigna la fecha actual como fecha de creación
            };
            // Llama al servicio para insertar la nueva frecuencia y devuelve la respuesta
            var response = _frecuenciaService.InsertarFrecuencia(modelo);
            return Ok(response);
        }

        // Método para actualizar una frecuencia existente
        [HttpPut("Actualizar")]
        public IActionResult Update(FrecuenciaViewModel FrecViewModel)
        {
            // Crea un nuevo objeto de tipo tbFrecuencias con los datos recibidos en el modelo
            var modelo = new tbFrecuencias()
            {
                frec_Id = Convert.ToInt32(FrecViewModel.frec_Id), // Convierte el ID de la frecuencia a entero
                frec_Descripcion = FrecViewModel.frec_Descripcion,
                frec_NumeroDias = FrecViewModel.frec_NumeroDias,
                usua_Modificacion = FrecViewModel.usua_Modificacion,
                frec_FechaModificacion = DateTime.Now // Asigna la fecha actual como fecha de modificación
            };
            // Llama al servicio para actualizar la frecuencia existente y devuelve la respuesta
            var response = _frecuenciaService.ActualizarFrecuencia(modelo);
            return Ok(response);
        }

        // Método para eliminar una frecuencia por su ID
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            // Llama al servicio para eliminar una frecuencia por su ID y devuelve la respuesta
            var response = _frecuenciaService.EliminarFrecuencia(id);
            return Ok(response);
        }
    }
}
