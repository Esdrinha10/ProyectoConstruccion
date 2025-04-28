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
    public class PantallaPorRolController : Controller
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        public PantallaPorRolController(AccesoService accesoService, IMapper mapper)
        {
            _accesoService = accesoService;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult ListarPantallaPorRol()
        {
            var response = _accesoService.ListarPantallasPorRoles();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPantallaPorRol(int id)
        {
            var response = _accesoService.BuscarPantallaPorRol(id);
            return Ok(response.Data);
        }

 

        [HttpPost("Insertar")]
        public IActionResult Create(PantallaPorRolViewModel PantallaPorRolViewModel)
        {
            var modelo = new tbPantallasPorRoles()
            {
                role_Id = PantallaPorRolViewModel.role_Id,
                pant_Id = PantallaPorRolViewModel.pant_Id,
                usua_Creacion = PantallaPorRolViewModel.usua_Creacion,
                paro_FechaCreacion = DateTime.Now
            };
            var response = _accesoService.InsertarPantallaPorRol(modelo);
            return Ok(response);
        }


        [HttpPut("Actualizar")]
        public IActionResult Update(PantallaPorRolViewModel PantallaPorRolViewModel)
        {
            var modelo = new tbPantallasPorRoles()
            {
                paro_Id = Convert.ToInt32(PantallaPorRolViewModel.paro_Id),
                role_Id = Convert.ToInt32(PantallaPorRolViewModel.role_Id),
                pant_Id = PantallaPorRolViewModel.pant_Id,
                usua_Modificacion = PantallaPorRolViewModel.usua_Modificacion,
                paro_FechaModificiacion = DateTime.Now
            };
            var response = _accesoService.ActualizarPantallaPorRol(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _accesoService.EliminarPantallaPorRol(id);
            return Ok(response);
        }
    }
}
