using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")] //nombra la ruta con el nombre del controlador
    [ApiController]
    public class MaquinariaController : ControllerBase
    {

        private readonly InsumoService _insumoService;  
        private readonly IMapper _mapper; 

        public MaquinariaController (InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;//inicializamos el servicio de insumos
            _mapper = mapper;//inicializamos el mapper
        }


        [HttpGet("Listar")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult ListarMaquinarias() //controlador de tpo IActionResult que devuelve el listado de maquinas
        {
            var response = _insumoService.ListarMaquinarias();//entra al servicio de insumos y realiza la accion de listar maquinaria

            return Ok(response);//retorna el resultado con codigo 200
        }


        [HttpGet("Buscar/{id}")]//Nombre de la ruta del controlador de la api, de tipo get
        public IActionResult BuscarMaquinaria(int id)
        {
            var response = _insumoService.BuscarMaquinaria(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//retorna el resultado de la el response como tipo data
        }


        [HttpPost("Insertar")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult Create(MaquinariaViewModel maquinariaViewModel)
        {
            var modelo = new tbMaquinarias() //mappeo de viewmodel al entitie de la tabla
            {
               
                maqu_Descripcion = maquinariaViewModel.maqu_Descripcion,
                nive_Id = maquinariaViewModel.nive_Id,
                maqu_UltimoPrecioUnitario = Convert.ToDecimal(maquinariaViewModel.maqu_UltimoPrecioUnitario),
                usua_Creacion = maquinariaViewModel.usua_Creacion,
                maqu_FechaCreacion = DateTime.Now
            };

            var response = _insumoService.InsertarMaquinaria(modelo);//envio de los datos mapeados al servicio de insertar maquinaria y lo setea en una variable
            
            if(response.Success == true) //valida que el resultado del response sea correcto
            {
                return Ok(response);//devuelve el codigo 200 y el resultado del response

            }
            else
            {
                return Problem();//devuelve el codigo de error y el mensaje
            }
        }

        [HttpPost("InsertarMaquinaria")]//Nombre de la ruta del controlador de la api, de tipo post
        public IActionResult CreateMaquinaria(MaquinariaViewModel maquinariaViewModel)
        {
            if (maquinariaViewModel.maqu_Id != 0 ) //valida que el id del campo este vacio
            {
                var modelo = new tbMaquinariasPorProveedores() //mapea el viewmodel al entitie de la tabla solo si el id del campo esta vacio
                {
                    mapr_PrecioCompra =Convert.ToDecimal(maquinariaViewModel.maqu_UltimoPrecioUnitario),
                    maqu_Id = maquinariaViewModel.maqu_Id,
                    prov_Id = maquinariaViewModel.prov_Id,
                    usua_Creacion = maquinariaViewModel.usua_Creacion,
                    mapr_FechaCreacion = DateTime.Now,
                    nive_Id = maquinariaViewModel.nive_Id,
                    mapr_DiaHora = maquinariaViewModel.mapr_DiaHora
                };

          


                var response = _insumoService.InsertarMaquinariaPorProveedor(modelo);
                var mapr_Id = response.Data;
                if (maquinariaViewModel.coti_Id != 0)
                {

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)maquinariaViewModel.maqu_UltimoPrecioUnitario,
                        coti_Id = maquinariaViewModel.coti_Id,
                        cime_Id = mapr_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 0,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
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
                        prov_Id = maquinariaViewModel.prov_Id,
                        coti_Fecha = maquinariaViewModel.coti_Fecha,
                        empl_Id = maquinariaViewModel.empl_Id,
                        coti_Incluido = maquinariaViewModel.coti_Incluido,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
                        coti_FechaCreacion = DateTime.Now,
                        coti_CompraDirecta = maquinariaViewModel.coti_CompraDirecta,
                    };

                    var coti_Response = _insumoService.InsertarCotizacion(modeloCotizacion);
                    var coti_Id = coti_Response.Data;

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)maquinariaViewModel.maqu_UltimoPrecioUnitario,
                        coti_Id = coti_Id.CodeStatus,
                        cime_Id = mapr_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 0,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };
                    _insumoService.InsertarCotizacionDetalle(Cotizacion);


                    response.Data.MessageStatus = coti_Id.CodeStatus.ToString();
                }
                //envia el modelo mapeado al servicio y setea el resultado en una variable
                if (response.Success==true)//valida si el resultado del response es exitoso
                { 
                    return Ok(response); //retorna un codigo 200 y la variable response
                }
                else
                {
                    return Problem();
                }
            }
            else //se realiza la siguiente accion si no se cumple
            {
                var modelo = new tbMaquinarias() //mapea el viewmodel al entitie de la tabla solo si el id del campo NO esta vacio
                {

                    maqu_Descripcion = maquinariaViewModel.maqu_Descripcion,
                    nive_Id = maquinariaViewModel.nive_Id,
                    maqu_UltimoPrecioUnitario = Convert.ToDecimal(maquinariaViewModel.maqu_UltimoPrecioUnitario),
                    usua_Creacion = maquinariaViewModel.usua_Creacion,
                    maqu_FechaCreacion = DateTime.Now
                };
                var response = _insumoService.InsertarMaquinaria(modelo); //envia el modelo mapeado al servicio y setea el resultado en una variable
                var maqu_Id = response.Data; //setea una variable con la data de la variable response

                var modelo2 = new tbMaquinariasPorProveedores() //mapea el viewmodel al entitie de la tabla maquinaria por proveedores solo si el id del campo NO esta vacio
                {
                    mapr_PrecioCompra = Convert.ToDecimal(maquinariaViewModel.maqu_UltimoPrecioUnitario),
                    maqu_Id = maqu_Id.CodeStatus,
                    prov_Id = maquinariaViewModel.prov_Id,
                    usua_Creacion = maquinariaViewModel.usua_Creacion,
                    mapr_FechaCreacion = DateTime.Now,
                    nive_Id = maquinariaViewModel.nive_Id,
                    mapr_DiaHora = maquinariaViewModel.mapr_DiaHora
                };
                var responsemapr = _insumoService.InsertarMaquinariaPorProveedor(modelo2); //envia el mapeo del viewmodel al servicio de maquinaria por porveedores
                var mapr_Id = responsemapr.Data;
                if (maquinariaViewModel.coti_Id != 0)
                {

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)maquinariaViewModel.maqu_UltimoPrecioUnitario,
                        coti_Id = maquinariaViewModel.coti_Id,
                        cime_Id = mapr_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 0,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
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
                        prov_Id = maquinariaViewModel.prov_Id,
                        coti_Fecha = maquinariaViewModel.coti_Fecha,
                        empl_Id = maquinariaViewModel.empl_Id,
                        coti_Incluido = maquinariaViewModel.coti_Incluido,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
                        coti_FechaCreacion = DateTime.Now,
                        coti_CompraDirecta = maquinariaViewModel.coti_CompraDirecta,
                    };

                    var coti_Response = _insumoService.InsertarCotizacion(modeloCotizacion);
                    var coti_Id = coti_Response.Data;

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)maquinariaViewModel.maqu_UltimoPrecioUnitario,
                        coti_Id = coti_Id.CodeStatus,
                        cime_Id = mapr_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 0,
                        usua_Creacion = maquinariaViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };
                    _insumoService.InsertarCotizacionDetalle(Cotizacion);


                    response.Data.MessageStatus = coti_Id.CodeStatus.ToString();
                }

                return Ok(response); //retorna el resultado del response de insertar maquinaria
            }
          
        }

        [HttpPut("Actualizar")]//Nombre de la ruta del controlador la api, de tipo put
        public IActionResult Update(MaquinariaViewModel maquinariaViewModel)
        {
            //mapeamos el viewmodel pedido con el entitie de la tabla
            var modelo = new tbMaquinarias()
            {
                maqu_Id = Convert.ToInt32(maquinariaViewModel.maqu_Id),
                maqu_Descripcion = maquinariaViewModel.maqu_Descripcion,
                maqu_UltimoPrecioUnitario  = maquinariaViewModel.maqu_UltimoPrecioUnitario,
                nive_Id = maquinariaViewModel.nive_Id,
                usua_Modificacion = maquinariaViewModel.usua_Modificacion,
                maqu_FechaModificacion = DateTime.Now
            };
            //enviamos el modelo mapeado al servicio de actualizar maquinaria
            var response = _insumoService.ActualizarMaquinaria(modelo);

            if(response.Success == true) //valida si el response es positivo
            {
                return Ok(response);//retorna el codigo 200 y el resultado del response

            }
            else
            {
                return Problem();//retorna el codigo de error si el succes no es true
            }
        }

        [HttpDelete("Eliminar")]//Nombre de la ruta del controlador de la api, de tipo Delete 
        public IActionResult Delete(int id)
        {
            //enviamos el id del campo a borrar al servicio de maquinaria
            var response = _insumoService.EliminarMaquinaria(id);
            if(response.Success == true)
            {
                //retorna el codigo 200 y el resultado del response
                return Ok(response);
            }
            else
            {
                //retorna el codigo del problema si el succes no es verdadero
                return Problem();
            }

        }

    }
}
