using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
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
    public class MaquinariaPorProveedorController : ControllerBase
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        public MaquinariaPorProveedorController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult ListarMaquinariasPorProveedores()
        {
            var response = _insumoService.ListarMaquinariasPorProveedores();
            return Ok(response.Data);
        }


        [HttpPost("Insertar")]
        public IActionResult Create(MaquinariaPorProveedorViewModel maquinariaPorProveedorViewModel)
        {
            var modelo = new tbMaquinariasPorProveedores()
            {
                mapr_PrecioCompra = maquinariaPorProveedorViewModel.mapr_PrecioCompra,
                maqu_Id = maquinariaPorProveedorViewModel.maqu_Id,
                prov_Id = maquinariaPorProveedorViewModel.prov_Id,
                usua_Creacion = maquinariaPorProveedorViewModel.usua_Creacion,
                mapr_FechaCreacion = DateTime.Now
            };
            var response = _insumoService.InsertarMaquinariaPorProveedor(modelo);
            return Ok(response);
        }


        [HttpGet("Buscar/{prov}")]
        public IActionResult BuscarMaquinariasPorProveedor(int prov)
        {
            var response = _insumoService.BuscarMaquinariasPorProveedores(prov);
            return Ok(response.Data);
        }
        [HttpPut("Actualizar")]
        public IActionResult Update(MaquinariaPorProveedorViewModel maquinariaPorProveedorViewModel)
        {
            var modelo = new tbMaquinariasPorProveedores()
            {
                mapr_Id = Convert.ToInt32(maquinariaPorProveedorViewModel.mapr_Id),
                mapr_PrecioCompra = maquinariaPorProveedorViewModel.mapr_PrecioCompra,
                maqu_Id = maquinariaPorProveedorViewModel.maqu_Id,
                prov_Id = maquinariaPorProveedorViewModel.prov_Id,
                usua_Modificacion = maquinariaPorProveedorViewModel.usua_Creacion,
                mapr_FechaModificacion = DateTime.Now
            };
            var response = _insumoService.ActualizarMaquinariaPorProveedor(modelo);
            return Ok(response);
        }


        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int id)
        {
            var response = _insumoService.EliminarMaquinariaPorProveedor(id);
            return Ok(response);
        }
    }
}
