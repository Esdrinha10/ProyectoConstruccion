using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
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
    public class InsumoController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;
        private readonly GeneralService _generalService;

        public InsumoController(InsumoService generaleService, IMapper mapper, GeneralService generalServices)
        {
            _insumoService = generaleService;
            _generalService = generalServices;
            _mapper = mapper;
        }


        /// <summary>
        /// Obtiene una lista de todos los insumos.
        /// </summary>
        /// <returns>Lista de insumos.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarInsumo()
        {
            var response = _insumoService.ListarInsumos();
            return Ok(response.Data);
        }

        /// <summary>
        /// Obtiene una lista de insumos (sin utilizar el parámetro ID en el código actual).
        /// </summary>
        /// <returns>Lista de insumos.</returns>
        [HttpGet("Listar/{id}")]
        public IActionResult ListarInsumoPorMedidas()
        {
            var response = _insumoService.ListarInsumos();
            return Ok(response.Data);
        }

        /// <summary>
        /// Busca un insumo específico por su ID.
        /// </summary>
        /// <param name="id">ID del insumo a buscar.</param>
        /// <returns>Detalles del insumo con el ID especificado.</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarInsumo(int id)
        {
            var response = _insumoService.BuscarInsumo(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Muestra la subcategoría asociada a un insumo específico.
        /// </summary>
        /// <param name="id">ID del insumo.</param>
        /// <returns>Detalles de la subcategoría asociada al insumo.</returns>
        [HttpGet("Mostrar/{id}")]
        public IActionResult MostrarSubcategoriaPorInsumo(int id)
        {
            var response = _insumoService.MostrarSubPorCate(id);
            return Ok(response.Data);
        }

        /// <summary>
        /// Obtiene una lista de todas las categorías.
        /// </summary>
        /// <returns>Lista de categorías.</returns>
        [HttpGet("ListarCate")]
        public IActionResult ListarCate()
        {
            var response = _insumoService.ListarCate();
            return Ok(response.Data);
        }
        [HttpGet("ListarMaterial")]
        public IActionResult ListarMaterial()
        {
            var list = _insumoService.ListarMateriales();

            return Ok(list.Data);
        }
        /// <summary>
        /// Crea un nuevo insumo en el sistema.
        /// </summary>
        /// <param name="InsumoViewModel">Datos del nuevo insumo a crear.</param>
        /// <returns>Resultado de la creación del insumo.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(InsumoViewModel InsumoViewModel)
        {
            var modelo = new tbInsumos()
            {
                insu_Descripcion = InsumoViewModel.insu_Descripcion,
                suca_Id = InsumoViewModel.suca_Id,
                insu_UltimoPrecioUnitario = InsumoViewModel.insu_UltimoPrecioUnitario,
                insu_Observacion = InsumoViewModel.insu_Observacion,
                mate_Id = InsumoViewModel.mate_Id,
                usua_Creacion = InsumoViewModel.usua_Creacion,
                insu_FechaCreacion = DateTime.Now
            };
            var response = _insumoService.InsertarInsumo(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Crea un insumo y maneja la creación de materiales, categorías, subcategorías y unidades de medida asociadas si no existen.
        /// </summary>
        /// <param name="InsumoViewModel">Datos del insumo a crear, junto con detalles relacionados.</param>
        /// <returns>Resultado de la creación del insumo.</returns>
        [HttpPost("InsertarInsumo")]
        public IActionResult CreateInsumo(InsumoViewModel InsumoViewModel)
        {
            if (InsumoViewModel.inpp_Observacion == null)
            {
                InsumoViewModel.inpp_Observacion = "N/A";
            }

            if (InsumoViewModel.mate_Id == 0)
            {
                var modelo2 = new tbMateriales()
                {
                    mate_Descripcion = InsumoViewModel.mate_Descripcion,
                    usua_Creacion = InsumoViewModel.usua_Creacion
                };
                var result = _insumoService.InsertarMaterial(modelo2);
                var code = result.Data;
                InsumoViewModel.mate_Id = code.CodeStatus;
            }

            var modelo3 = new tbCategorias()
            {
                cate_Descripcion = InsumoViewModel.cate_Descripcion,
                usua_Creacion = InsumoViewModel.usua_Creacion
            };
            var resultCate = _generalService.InsertarCategoria(modelo3);
            var codeCate = resultCate.Data;
            InsumoViewModel.cate_Id = codeCate.CodeStatus;

            var modeloSub = new tbSubcategorias()
            {
                cate_Id = InsumoViewModel.cate_Id,
                suca_Descripcion = InsumoViewModel.suca_Descripcion,
                usua_Creacion = InsumoViewModel.usua_Creacion,
                suca_FechaCreacion = DateTime.Now
            };
            var resultSub = _insumoService.InsertarSubcategorias(modeloSub);
            var codeSub = resultSub.Data;
            InsumoViewModel.suca_Id = codeSub.CodeStatus;

            if (InsumoViewModel.unme_Id == 0)
            {
                int mitad = InsumoViewModel.unme_Nombre.Length / 2;
                string primeraParte = InsumoViewModel.unme_Nombre.Substring(0, 1);
                string segundaParte = InsumoViewModel.unme_Nombre.Substring(mitad, 1);
                var nomenclatura = new string[] { primeraParte, segundaParte };
                string combinedNomenclatura = string.Join("", nomenclatura);

                var modelo2 = new tbUnidadesMedida()
                {
                    unme_Nombre = InsumoViewModel.unme_Nombre,
                    unme_Nomenclatura = combinedNomenclatura.ToString(),
                    usua_Creacion = InsumoViewModel.usua_Creacion,
                    unme_FechaCreacion = DateTime.Now
                };
                var result = _generalService.InsertarUnidadMedida(modelo2);
                var code = result.Data;
                InsumoViewModel.unme_Id = Convert.ToInt32(code.MessageStatus);
            }

            if (InsumoViewModel.insu_Id != 0)
            {
                var modelo2 = new tbInsumosPorProveedores()
                {
                    insu_Id = InsumoViewModel.insu_Id,
                    prov_Id = InsumoViewModel.prov_Id,
                    inpp_Preciocompra = InsumoViewModel.inpp_Preciocompra,
                    inpp_Observacion = InsumoViewModel.inpp_Observacion,
                    unme_Id = InsumoViewModel.unme_Id,
                    usua_Creacion = InsumoViewModel.usua_Creacion,
                    inpp_FechaCreacion = DateTime.Now,
                    suca_Id = InsumoViewModel.suca_Id,
                    mate_Id = InsumoViewModel.mate_Id
                };
           

                var response = _insumoService.InsertarInsumoPorProveedor(modelo2);
                var inpp_Id = response.Data;

                if (InsumoViewModel.coti_Id != 0)
                {

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)InsumoViewModel.inpp_Preciocompra,
                        coti_Id = InsumoViewModel.coti_Id,
                        cime_Id = inpp_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 1,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };


                    _insumoService.InsertarCotizacionDetalle(Cotizacion);
                    response.Data.MessageStatus = "0";
                }
                else{
                    var modelo = new tbCotizaciones()
                    {
                        prov_Id = InsumoViewModel.prov_Id,
                        coti_Fecha = InsumoViewModel.coti_Fecha,
                        empl_Id = InsumoViewModel.empl_Id,
                        coti_Incluido = InsumoViewModel.coti_Incluido,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        coti_FechaCreacion = DateTime.Now,
                        coti_CompraDirecta = InsumoViewModel.coti_CompraDirecta,
                    };

                    var coti_Response = _insumoService.InsertarCotizacion(modelo);
                    var coti_Id = coti_Response.Data;

                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)InsumoViewModel.inpp_Preciocompra,
                        coti_Id = coti_Id.CodeStatus,
                        cime_Id = inpp_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 1,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };
                    _insumoService.InsertarCotizacionDetalle(Cotizacion);


                    response.Data.MessageStatus = coti_Id.CodeStatus.ToString();
                }

               


             
                return Ok(response);
            }
            else
            {
                var modelo = new tbInsumos()
                {
                    insu_Descripcion = InsumoViewModel.insu_Descripcion,
                    suca_Id = InsumoViewModel.suca_Id,
                    insu_UltimoPrecioUnitario = InsumoViewModel.inpp_Preciocompra,
                    insu_Observacion = InsumoViewModel.insu_Observacion,
                    mate_Id = InsumoViewModel.mate_Id,
                    usua_Creacion = InsumoViewModel.usua_Creacion,
                    insu_FechaCreacion = DateTime.Now,
                };
                var response = _insumoService.InsertarInsumo(modelo);
                var insu_Id = response.Data;

                var modelo2 = new tbInsumosPorProveedores()
                {
                    insu_Id = insu_Id.CodeStatus,
                    prov_Id = InsumoViewModel.prov_Id,
                    inpp_Preciocompra = InsumoViewModel.inpp_Preciocompra,
                    unme_Id = InsumoViewModel.unme_Id,
                    inpp_Observacion = InsumoViewModel.inpp_Observacion,
                    usua_Creacion = InsumoViewModel.usua_Creacion,
                    inpp_FechaCreacion = DateTime.Now,
                    suca_Id = InsumoViewModel.suca_Id,
                    mate_Id = InsumoViewModel.mate_Id
                };
                var status = _insumoService.InsertarInsumoPorProveedor(modelo2);
                var inpp_Id = status.Data;
                if (InsumoViewModel.coti_Id != 0)
                {
                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)InsumoViewModel.inpp_Preciocompra,
                        coti_Id = InsumoViewModel.coti_Id,
                        cime_Id = inpp_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 1,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };


                    _insumoService.InsertarCotizacionDetalle(Cotizacion);
                    response.Data.MessageStatus = "0";
                }else {
                    var modeloCoti = new tbCotizaciones()
                    {
                        prov_Id = InsumoViewModel.prov_Id,
                        coti_Fecha = InsumoViewModel.coti_Fecha,
                        empl_Id = InsumoViewModel.empl_Id,
                        coti_Incluido = InsumoViewModel.coti_Incluido,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        coti_FechaCreacion = DateTime.Now,
                        coti_CompraDirecta = InsumoViewModel.coti_CompraDirecta,
                    };

                    var coti_Response = _insumoService.InsertarCotizacion(modeloCoti);
                    var coti_Id = coti_Response.Data;
                    var Cotizacion = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = 1,
                        code_PrecioCompra = (decimal)InsumoViewModel.inpp_Preciocompra,
                        coti_Id = coti_Id.CodeStatus,
                        cime_Id = inpp_Id.CodeStatus,
                        cime_InsumoOMaquinariaOEquipoSeguridad = 1,
                        usua_Creacion = InsumoViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = 1
                    };
                    _insumoService.InsertarCotizacionDetalle(Cotizacion);

                    response.Data.MessageStatus = coti_Id.CodeStatus.ToString();
                }


                return Ok(response);
            }
        }

        /// <summary>
        /// Actualiza la información de un insumo existente.
        /// </summary>
        /// <param name="InsumoViewModel">Datos actualizados del insumo.</param>
        /// <returns>Resultado de la actualización del insumo.</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(InsumoViewModel InsumoViewModel)
        {
            var modelo = new tbInsumos()
            {
                insu_Id = Convert.ToInt32(InsumoViewModel.insu_Id),
                insu_Descripcion = InsumoViewModel.insu_Descripcion,
                suca_Id = InsumoViewModel.suca_Id,
                insu_UltimoPrecioUnitario = InsumoViewModel.insu_UltimoPrecioUnitario,
                insu_Observacion = InsumoViewModel.insu_Observacion,
                mate_Id = InsumoViewModel.mate_Id,
                usua_Modificacion = InsumoViewModel.usua_Modificacion,
                insu_FechaModificacion = DateTime.Now
            };
            var response = _insumoService.ActualizarInsumo(modelo);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un insumo específico por su ID.
        /// </summary>
        /// <param name="id">ID del insumo a eliminar.</param>
        /// <returns>Resultado de la eliminación del insumo.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _insumoService.EliminarInsumo(id);
            return Ok(response);
        }
    }
}
