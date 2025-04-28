using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceAcceso;
using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersAcceso
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="accesoService">Servicio que maneja la lógica de negocio relacionada con el acceso y los roles.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public RolController(AccesoService accesoService, IMapper mapper)
        {
           
            _accesoService = accesoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos los roles disponibles en el sistema.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarRol()
        {
            var response = _accesoService.ListarRoles();
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un rol específico por su ID.
        /// </summary>
        /// <param name="id">ID del rol a buscar.</param>
        /// <returns>El rol encontrado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarRol(int id)
        {
            var response = _accesoService.BuscarRol(id);
            return Ok(response.Data);
        }


        /// <summary>
        /// Inserta un nuevo rol en el sistema y asigna las pantallas seleccionadas al rol.
        /// </summary>
        /// <param name="RolViewModel">Modelo de vista del rol a insertar, incluyendo las pantallas seleccionadas.</param>
        /// <returns>Resultado de la operación de inserción.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(RolViewModel RolViewModel)
        {
            var modelo = _mapper.Map<tbRoles>(RolViewModel);
            var response = _accesoService.InsertarRol(modelo);
            var role_Id = response.Data;

  
            List<int> pantallasSeleccionadas = RolViewModel.pantallasSeleccionadas;


            foreach (var pantalla in pantallasSeleccionadas)
            {

                var modelo2 = new tbPantallasPorRoles()
                {
                    pant_Id = pantalla,
                    usua_Creacion = RolViewModel.usua_Creacion,
                    role_Id = role_Id.CodeStatus
                };

                _accesoService.InsertarPantallaPorRol(modelo2);
            }

            return Ok(response);
        }

        /// <summary>
        /// Actualiza un rol existente y sus relaciones con pantallas en el sistema.
        /// </summary>
        /// <param name="RolViewModel">Modelo de vista del rol a actualizar, incluyendo las pantallas seleccionadas.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(RolViewModel RolViewModel)
        {
            var modelo = _mapper.Map<tbRoles>(RolViewModel);

            var response = _accesoService.ActualizarRol(modelo);

            _accesoService.EliminarPantallaPorRol(RolViewModel.role_Id);

            List<int> pantallasSeleccionadas = RolViewModel.pantallasSeleccionadas;

            foreach (var pantalla in pantallasSeleccionadas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    pant_Id = pantalla,
                    usua_Creacion = (int)RolViewModel.usua_Modificacion,
                    role_Id = RolViewModel.role_Id
                };

                _accesoService.InsertarPantallaPorRol(modelo2);
            }

            return Ok(response);
        }

        /// <summary>
        /// Elimina un rol especificado por su ID.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _accesoService.EliminarRol(id);

            return Ok(response);
        }
    }
}
