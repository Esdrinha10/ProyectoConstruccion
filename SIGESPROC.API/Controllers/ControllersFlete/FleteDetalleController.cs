using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
using SIGESPROC.Common.Models.ModelsFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersFlete
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleteDetalleController : Controller
    {
        private readonly FleteService _fleteControlCalidadService;
        private readonly IMapper _mapper;

        // Constructor de la clase que inicializa los servicios necesarios
        public FleteDetalleController(FleteService fleteControlCalidadService, IMapper mapper)
        {
            _fleteControlCalidadService = fleteControlCalidadService;
            _mapper = mapper;
        }
        // Método para buscar un detalle de flete por su ID
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarFleteDetalle(int id)
        {
            var response = _fleteControlCalidadService.BuscarFleteDetalle(id); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }


        [HttpGet("BuscarDetalles/{id}")]
        public IActionResult BuscarFleteDetalles(int id)
        {
            var response = _fleteControlCalidadService.BuscarFleteDetalles(id); // Llama al servicio para buscar el detalle del flete
            return Ok(response.Data); // Retorna un resultado exitoso con el detalle del flete encontrado
        }

        // Método para insertar un nuevo detalle de flete
        [HttpPost("Insertar")]
        public IActionResult Create(FleteDetalleViewModel FletViewModel)
        {
            // Mapea los datos del ViewModel al modelo de entidad
            var modelo = new tbFletesDetalle()
            {
                flde_Cantidad = FletViewModel.flde_Cantidad,
                flen_Id = FletViewModel.flen_Id,
                inpp_Id = FletViewModel.inpp_Id,
                usua_Creacion = FletViewModel.usua_Creacion,
                flde_FechaCreacion = DateTime.Now,
                // Asigna la fecha de creación actual,
                flde_TipodeCarga = FletViewModel.flde_TipodeCarga

            };
            var response = _fleteControlCalidadService.InsertarFleteDetalle(modelo); // Llama al servicio para insertar el detalle del flete
            return Ok(response); // Retorna el resultado del servicio
        }

        // Método para actualizar un detalle de flete existente
        [HttpPut("Actualizar")]
        public IActionResult Update(FleteDetalleViewModel FletViewModel)
        {
            // Mapea los datos del ViewModel al modelo de entidad
            var modelo = new tbFletesDetalle()
            {
                flde_Id = FletViewModel.flde_Id,
                flde_Cantidad = FletViewModel.flde_Cantidad,
                flen_Id = FletViewModel.flen_Id,
                usua_Modificacion = FletViewModel.usua_Modificacion,
                inpp_Id = FletViewModel.inpp_Id,
                flde_llegada = FletViewModel.flde_llegada,
                flde_FechaModificacion = DateTime.Now // Asigna la fecha de modificación actual
            };
            var response = _fleteControlCalidadService.ActualizarFleteDetalle(modelo); // Llama al servicio para actualizar el detalle del flete
            return Ok(response); // Retorna el resultado del servicio
        }



        [HttpGet("ListarInsumosPorActividadEtapa")]
        public IActionResult ListarInsumoPorActividadPorEtapa()
        {
            var response = _fleteControlCalidadService.ListarInsumoPorProveedor();
            return Ok(response.Data);
        }


        [HttpGet("BuscarInsumosPorActividadEtapa/{id}")]
        public IActionResult BuscarInsumoProveedor(int id)
        {
            var response = _fleteControlCalidadService.BuscarInsumoPorActividadEtap(id);
            return Ok(response.Data);
        }


        [HttpGet("BuscarEquiposPorActividadEtapa/{id}")]
        public IActionResult BuscarEquipoProveedor(int id)
        {
            var response = _fleteControlCalidadService.BuscarEquipoPorActividadEtap(id);
            return Ok(response.Data);
        }


        // Método para eliminar un detalle de flete por su ID
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _fleteControlCalidadService.EliminarFleteDetalle(id); // Llama al servicio para eliminar el detalle del flete por su ID
            return Ok(response); // Retorna el resultado del servicio
        }
    }
}