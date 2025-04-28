using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoPorProveedorController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        public InsumoPorProveedorController(InsumoService generaleService, IMapper mapper)
        {
            _insumoService = generaleService;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult ListarInsumoPorProveedor()
        {
            var response = _insumoService.ListarInsumoPorProveedor();
            return Ok(response.Data);
        }

        [HttpGet("Listar/{id}")]
        public IActionResult ListarInsumoPorProveedor(int id)
        {
            var response = _insumoService.ListarInsumosPorProveedores(id);
            return Ok(response.Data);
        }


        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarInsumoProveedor(int id)
        {
            var response = _insumoService.BuscarInsumoPorProveedor(id);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(InsumoPorProveedorViewModel InsumoPorProveedorViewModel)
        {
            var modelo = new tbInsumosPorProveedores()
            {
                insu_Id = InsumoPorProveedorViewModel.insu_Id,
                prov_Id = InsumoPorProveedorViewModel.prov_Id,
                inpp_Preciocompra = InsumoPorProveedorViewModel.inpp_Preciocompra,
                usua_Creacion = InsumoPorProveedorViewModel.usua_Creacion,
                inpp_FechaCreacion = DateTime.Now
            };
            var response = _insumoService.InsertarInsumoPorProveedor(modelo);
            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(InsumoPorProveedorViewModel InsumoPorProveedorViewModel)
        {
            var modelo = new tbInsumosPorProveedores()
            {
                inpp_Id = Convert.ToInt32(InsumoPorProveedorViewModel.inpp_Id),
                insu_Id = InsumoPorProveedorViewModel.insu_Id,
                prov_Id = InsumoPorProveedorViewModel.prov_Id,
                inpp_Preciocompra = InsumoPorProveedorViewModel.inpp_Preciocompra,
                usua_Modificacion = InsumoPorProveedorViewModel.usua_Modificacion,
                inpp_FechaModificacion = DateTime.Now
            };
            var response = _insumoService.ActualizarInsumoPorProveedor(modelo);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] int id)
        {
            var response = _insumoService.EliminarInsumoPorProveedor(id);
            return Ok(response);
        }
    
    }
}