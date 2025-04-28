using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public ClienteController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarClientes()
        {
            var response = _generalService.ListarClientes();
            return Ok(response.Data);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarClientes(int id)
        {
            var response = _generalService.BuscarClientes(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ClienteViewModel ClienteViewModel)
        {
            var modelo = new tbClientes()
            {

             
                clie_DNI = ClienteViewModel.clie_DNI,
                clie_Nombre = ClienteViewModel.clie_Nombre,
                clie_Apellido = ClienteViewModel.clie_Apellido,
                clie_CorreoElectronico = ClienteViewModel.clie_CorreoElectronico,
                clie_Telefono = ClienteViewModel.clie_Telefono,
                clie_FechaNacimiento = ClienteViewModel.clie_FechaNacimiento,
                clie_Sexo = ClienteViewModel.clie_Sexo,
                clie_DireccionExacta = ClienteViewModel.clie_DireccionExacta,
                ciud_Id = ClienteViewModel.ciud_Id,
                civi_Id = ClienteViewModel.civi_Id,
                usua_Creacion = ClienteViewModel.usua_Creacion,
                clie_FechaCreacion = DateTime.Now,
                clie_Tipo = ClienteViewModel.clie_Tipo
            };
            var response = _generalService.InsertarClientes(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(ClienteViewModel ClienteViewModel)
        {
            var modelo = new tbClientes()
            {
                clie_Id = ClienteViewModel.clie_Id,
                clie_DNI = ClienteViewModel.clie_DNI,
                clie_Nombre = ClienteViewModel.clie_Nombre,
                clie_Apellido = ClienteViewModel.clie_Apellido,
                clie_CorreoElectronico = ClienteViewModel.clie_CorreoElectronico,
                clie_Telefono = ClienteViewModel.clie_Telefono,
                clie_FechaNacimiento = ClienteViewModel.clie_FechaNacimiento,
                clie_Sexo = ClienteViewModel.clie_Sexo,
                clie_DireccionExacta = ClienteViewModel.clie_DireccionExacta,
                ciud_Id = ClienteViewModel.ciud_Id,
                civi_Id = ClienteViewModel.civi_Id,
                usua_Modificacion = ClienteViewModel.usua_Modificacion,
                clie_FechaModificacion = DateTime.Now,
                clie_Tipo = ClienteViewModel.clie_Tipo
            };
            var response = _generalService.ActualizarClientes(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarClientes(id);
            return Ok(response);
        }
    }
}
