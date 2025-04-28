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
    public class ProyectoContruccionBienRaizController : Controller
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        // Constructor para inyectar las dependencias del servicio y del mapeador.

        public ProyectoContruccionBienRaizController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }
        /// <summary>
        /// Lista todos los proyectos de construcción de bienes raíces.
        /// </summary>
        /// <returns>Lista de proyectos de construcción de bienes raíces.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarProyectoConstruccionBienRaiz()
        {
            // Llama al servicio para listar
            var response = _bienRaizService.ListarProyectosConstruccionBienesRaices();
            // Devuelve la lista
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un proyecto de construcción de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID del proyecto de construcción que se desea buscar.</param>
        /// <returns>El proyecto de construcción encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarProyectoConstruccionBienRaiz(int id)
        {
            var response = _bienRaizService.BuscarProyectoConstruccionBienRaiz(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Inserta un nuevo proyecto de construcción de bienes raíces.
        /// </summary>
        /// <param name="proyectoConstruccionBienRaizViewModel">Objeto que contiene los datos del proyecto de construcción a insertar.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public virtual IActionResult Create(ProyectoConstruccionBienRaizViewModel proyectoConstruccionBienRaizViewModel)
        {
            var modelo = new tbProyectosConstruccionBienesRaices()
            {
                terr_Id = proyectoConstruccionBienRaizViewModel.terr_Id,
                proy_Id = proyectoConstruccionBienRaizViewModel.proy_Id,
                usua_Creacion = proyectoConstruccionBienRaizViewModel.usua_Creacion,
                pcon_FechaCreacion = DateTime.Now
            };
            var response = _bienRaizService.InsertarProyectoConstruccionBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un proyecto de construcción de bienes raíces existente.
        /// </summary>
        /// <param name="proyectoConstruccionBienRaizViewModel">Objeto que contiene los datos actualizados del proyecto de construcción.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public virtual IActionResult Update(ProyectoConstruccionBienRaizViewModel proyectoConstruccionBienRaizViewModel)
        {
            var modelo = new tbProyectosConstruccionBienesRaices()
            {
                pcon_Id = Convert.ToInt32(proyectoConstruccionBienRaizViewModel.pcon_Id),
                terr_Id = proyectoConstruccionBienRaizViewModel.terr_Id,
                proy_Id = proyectoConstruccionBienRaizViewModel.proy_Id,
                usua_Modificacion = proyectoConstruccionBienRaizViewModel.usua_Modificacion,
                pcon_FechaModificacion = DateTime.Now
            };
            var response = _bienRaizService.ActualizarProyectoConstruccionBienRaiz(modelo);
            return Ok(response);
        }
        /// <summary>
        /// Elimina un proyecto de construcción de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID del proyecto de construcción que se desea eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _bienRaizService.EliminarProyectoConstruccionBienRaiz(id);
            return Ok(response);
        }
    }
}
