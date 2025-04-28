using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]//nombra la ruta con el nombre del controlador
    [ApiController]
    public class EquipoSeguridadController : Controller
    {

        private readonly InsumoService _insumoService;
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;


        public EquipoSeguridadController(ProyectoService proyectoService, IMapper mapper, InsumoService insumoService)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;//inicializamos el mapper
            _insumoService = insumoService;
        }


        [HttpGet("Listar")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult ListarEquipoSeguridad()
        {
            var response = _proyectoService.ListarEquipoSeguridad();
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        [HttpGet("Buscar/{id}")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult BuscarEquipoSeguridad(int id)
        {
            var response = _proyectoService.BuscarEquipoSeguridad(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        [HttpGet("BuscarPorProveedor/{prov}")]
        public IActionResult BuscarPorProveedor(int prov)
        {
            var response = _proyectoService.BuscarEquipoPorProveedores(prov);
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult Create(EquipoSeguridadViewModel EquipoSeguridadViewModel)
        {
            var modelo = new tbEquiposSeguridad()//mappeo de viewmodel al entitie de la tabla
            {
                equs_Nombre = EquipoSeguridadViewModel.equs_Nombre,
                equs_Descripcion = EquipoSeguridadViewModel.equs_Descripcion,
                usua_Creacion = EquipoSeguridadViewModel.usua_Creacion,
                equs_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarEquipoSeguridad(modelo);//envio de los datos mapeados al servicio de insertar equipo de seguridad y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpPost("InsertarPorProveedor")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult CreateProveedor(EquipoSeguridadViewModel EquipoSeguridadViewModel)
         {

            if (EquipoSeguridadViewModel.equs_Id == 0)
            {
                var modeloEquipo = new tbEquiposSeguridad()//mappeo de viewmodel al entitie de la tabla
                {
                    equs_Nombre = EquipoSeguridadViewModel.equs_Nombre,
                    equs_Descripcion = EquipoSeguridadViewModel.equs_Nombre,
                    usua_Creacion = EquipoSeguridadViewModel.usua_Creacion,
                    equs_FechaCreacion = DateTime.Now
                };
                var ID = _proyectoService.InsertarEquipoSeguridad(modeloEquipo);//envio de los datos mapeados al servicio de insertar equipo de seguridad y lo setea en una variable
                var equs_Id = ID.Data; //setea una variable con la data de la variable response
                EquipoSeguridadViewModel.equs_Id = equs_Id.CodeStatus;
            }
            var modelo = new tbEquiposSeguridad()//mappeo de viewmodel al entitie de la tabla
            {
                equs_Id = EquipoSeguridadViewModel.equs_Id,
                prov_Id = EquipoSeguridadViewModel.prov_Id,
                eqpp_PrecioCompra = EquipoSeguridadViewModel.eqpp_PrecioCompra,
                usua_Creacion = EquipoSeguridadViewModel.usua_Creacion,
                equs_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarEquipoSeguridadPorProveedor(modelo);//envio de los datos mapeados al servicio de insertar equipo de seguridad y lo setea en una variable

            var eqpp_Id = response.Data;
            if (EquipoSeguridadViewModel.coti_Id != 0)
            {

                var Cotizacion = new tbCotizacionesDetalle()
                {
                    code_Cantidad = 1,
                    code_PrecioCompra = (decimal)EquipoSeguridadViewModel.eqpp_PrecioCompra,
                    coti_Id = EquipoSeguridadViewModel.coti_Id,
                    cime_Id = eqpp_Id.CodeStatus,
                    cime_InsumoOMaquinariaOEquipoSeguridad = 2,
                    usua_Creacion = (int)EquipoSeguridadViewModel.usua_Creacion,
                    code_FechaCreacion = DateTime.Now,
                    code_Renta = 1
                };


                _insumoService.InsertarCotizacionDetalle(Cotizacion);
                response.Data.MessageStatus = "0";
            }
            else
            {
                var modeloCotizacion = new tbCotizaciones()
                {
                    prov_Id = EquipoSeguridadViewModel.prov_Id,
                    coti_Fecha = EquipoSeguridadViewModel.coti_Fecha,
                    empl_Id = EquipoSeguridadViewModel.empl_Id,
                    coti_Incluido = EquipoSeguridadViewModel.coti_Incluido,
                    usua_Creacion = EquipoSeguridadViewModel.usua_Creacion,
                    coti_FechaCreacion = DateTime.Now,
                    coti_CompraDirecta = EquipoSeguridadViewModel.coti_CompraDirecta,
                };

                var coti_Response = _insumoService.InsertarCotizacion(modeloCotizacion);
                var coti_Id = coti_Response.Data;

                var Cotizacion = new tbCotizacionesDetalle()
                {
                    code_Cantidad = 1,
                    code_PrecioCompra = (decimal)EquipoSeguridadViewModel.eqpp_PrecioCompra,
                    coti_Id = coti_Id.CodeStatus,
                    cime_Id = eqpp_Id.CodeStatus,
                    cime_InsumoOMaquinariaOEquipoSeguridad = 2,
                    usua_Creacion = (int)EquipoSeguridadViewModel.usua_Creacion,
                    code_FechaCreacion = DateTime.Now,
                    code_Renta = 1
                };
                _insumoService.InsertarCotizacionDetalle(Cotizacion);


                response.Data.MessageStatus = coti_Id.CodeStatus.ToString();
            }
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpPut("Actualizar")]//Nombre de la ruta del controlador de la api, de tipo put
        public IActionResult Update(EquipoSeguridadViewModel EquipoSeguridadViewModel)
        {
            var modelo = new tbEquiposSeguridad()//mappeo de viewmodel al entitie de la tabla
            {
                equs_Id = Convert.ToInt32(EquipoSeguridadViewModel.equs_Id),
                equs_Nombre = EquipoSeguridadViewModel.equs_Nombre,
                equs_Descripcion = EquipoSeguridadViewModel.equs_Descripcion,
                usua_Modificacion = EquipoSeguridadViewModel.usua_Modificacion,
                equs_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarEquipoSeguridad(modelo);//envio de los datos mapeados al servicio de actualizar equipo de seguridad y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        [HttpDelete("Eliminar")]//Nombre de la ruta del controlador de la api, de tipo delete
        public IActionResult Delete(int id)
        {
            var response = _proyectoService.EliminarEquipoSeguridad(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }





        [HttpGet("ListarEquipoPorProveedor")]
        public IActionResult ListarEquipoPorProveedor()
        {
            var response = _proyectoService.ListarEquiposPorProveedor();
            return Ok(response.Data);
        }


        [HttpGet("BuscarEquipoPorProveedor/{id}")]
        public IActionResult BuscarEquipoProveedor(int id)
        {
            var response = _proyectoService.BuscarEquiposPorProveedor(id);
            return Ok(response.Data);
        }

        [HttpPut("EliminarPorProveedor")]

        public IActionResult EliminarPorProveedor([FromBody] int id)
        {
            var response = _proyectoService.EliminarEquiposPorProveedor(id);
            return Ok(response);
        }
    }
}
