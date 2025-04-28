using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
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
    public class RetrasoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public RetrasoController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
        }


        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarRetraso(int id)
        {
            var response = _proyectoService.BuscarRetraso(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(RetrasoViewModel RetrasoViewModel)
        {
            var modelo = new tbRetrasos()
            {
                retr_Descripcion = RetrasoViewModel.retr_Descripcion,
                retr_Monto = RetrasoViewModel.retr_Monto,
                retr_Fecha = RetrasoViewModel.retr_Fecha,
                Proy_Id = RetrasoViewModel.Proy_Id,
                usua_Creacion = RetrasoViewModel.usua_Creacion,
                retr_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarRetraso(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(RetrasoViewModel RetrasoViewModel)
        {
            var modelo = new tbRetrasos()
            {
                retr_Id = RetrasoViewModel.retr_Id,
                retr_Descripcion = RetrasoViewModel.retr_Descripcion,
                retr_Monto = RetrasoViewModel.retr_Monto,
                retr_Fecha = RetrasoViewModel.retr_Fecha,
                Proy_Id = RetrasoViewModel.Proy_Id,
                usua_Creacion = RetrasoViewModel.usua_Creacion,
                retr_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarRetraso(modelo);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarRetraso(id);
            return Ok(response);
        }
    }
}
