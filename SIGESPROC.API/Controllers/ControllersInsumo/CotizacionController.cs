using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGESPROC.DataAccess;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SIGESPROC.API.Controllers.ControllersInsumo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor para inicializar los servicios requeridos.
        /// </summary>
        /// <param name="insumoService">Servicio que maneja la lógica de negocio relacionada con insumos, maquinaria y equipos de seguridad y cotizaciones.</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades.</param>
        public CotizacionController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene una lista de todas las cotizaciones en el sistema.
        /// </summary>
        /// <returns>La lista de cotizaciones.</returns>
        [HttpGet("Listar")]
        public IActionResult ListarCotizacion()
        {
           
            var response = _insumoService.ListarCotizacion();


            return Ok(response.Data);

        }



        /// <summary>
        /// Obtiene una lista de cotizaciones asociadas a un proveedor específico.
        /// </summary>
        /// <param name="id">ID del proveedor cuyas cotizaciones se desean listar.</param>
        /// <returns>La lista de cotizaciones del proveedor.</returns>
        [HttpGet("ListarPorProveedor/{id}")]
        public IActionResult ListarCotizacionPorProveedor(int id)
        {
            var response = _insumoService.ListarCotizacionPorProveedor(id);


            return Ok(response.Data);
 
        }

        /// <summary>
        /// Busca y obtiene los artículos de una cotización específica utilizando el ID del proveedor y el ID de la cotización.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Los artículos de la cotización ya sea Maquinaria,Insumos o Equipos de seguridad.</returns>
        [HttpGet("ListarArticulos/{id},{coti}")]
        public IActionResult ListarArticulos(int id, int coti)
        {
            var response = _insumoService.BuscarCotizacion(id, coti);

              return Ok(response.Data);

        }

        /// <summary>
        /// Busca y obtiene los artículos asociados a una cotización específica utilizando el ID de la cotización.
        /// </summary>
        /// <param name="id">ID de la cotización.</param>
        /// <returns>Los artículos asociados a la cotización ya sean insumos, maquinarias o equipos de seguridaad de una cotizacion.</returns>
        [HttpGet("ListarArticulosPorCotizacion/{id}")]
        public IActionResult ListarArticulosPorCotizacion(int id)
        {
            var response = _insumoService.BuscarCotizacion(id);

       
              return Ok(response.Data);
      
        }



        /// <summary>
        /// Inserta una nueva cotización o actualiza una existente con sus respectivos detalles.
        /// </summary>
        /// <param name="CotizacionViewModel">Lista de modelos de vista de cotización que incluye los detalles de la cotización.</param>
        /// <returns>Resultado de la operación de inserción o actualización.</returns>
        [HttpPost("Insertar")]
        public IActionResult Create(List<CotizacionViewModel> CotizacionViewModel)
        {
            var coti = 0;

            foreach (var cotizacionViewModel in CotizacionViewModel)
            {
                if (cotizacionViewModel.coti_Id != 0)
                {
                    coti = cotizacionViewModel.coti_Id;
                }
            }

            if (coti == 0)
            {
                var modelo = new tbCotizaciones()
                {
                    prov_Id = CotizacionViewModel[0].prov_Id,
                    coti_Fecha = CotizacionViewModel[0].coti_Fecha,
                    empl_Id = CotizacionViewModel[0].empl_Id,
                    coti_Incluido = CotizacionViewModel[0].coti_Incluido,
                    usua_Creacion = CotizacionViewModel[0].usua_Creacion,
                    coti_FechaCreacion = DateTime.Now,
                    coti_CompraDirecta = CotizacionViewModel[0].coti_CompraDirecta,
                };

                var response = _insumoService.InsertarCotizacion(modelo);
                var coti_Id = response.Data;

                foreach (var cotizacionViewModel in CotizacionViewModel)
                {
                    var modelo2 = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = cotizacionViewModel.code_Cantidad,
                        code_PrecioCompra = cotizacionViewModel.code_PrecioCompra,
                        coti_Id = coti_Id.CodeStatus,
                        cime_Id = cotizacionViewModel.cime_Id,
                        cime_InsumoOMaquinariaOEquipoSeguridad = cotizacionViewModel.cime_InsumoOMaquinariaOEquipoSeguridad,
                        usua_Creacion = cotizacionViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = cotizacionViewModel.code_Renta
                    };

                    if (cotizacionViewModel.check != false)
                    {
                        _insumoService.InsertarCotizacionDetalle(modelo2);
                    }
                }

                var responses = _insumoService.BuscarCotizacion(coti_Id.CodeStatus);
                var lista = responses.Data as List<tbCotizaciones>;

                // Obtener los codeIds y ordenarlos de manera ascendente
                var codeIds = lista.Select(x => x.code_Id).OrderBy(x => x).ToList();
                string codeIdsString = string.Join(",", codeIds);

                response.Message = codeIdsString;
                return Ok(response);
            }
            else
            {
                foreach (var cotizacionViewModel in CotizacionViewModel)
                {
                    var modelo2 = new tbCotizacionesDetalle()
                    {
                        code_Cantidad = cotizacionViewModel.code_Cantidad,
                        code_PrecioCompra = cotizacionViewModel.code_PrecioCompra,
                        coti_Id = cotizacionViewModel.coti_Id,
                        cime_Id = cotizacionViewModel.cime_Id,
                        cime_InsumoOMaquinariaOEquipoSeguridad = cotizacionViewModel.cime_InsumoOMaquinariaOEquipoSeguridad,
                        usua_Creacion = cotizacionViewModel.usua_Creacion,
                        code_FechaCreacion = DateTime.Now,
                        code_Renta = cotizacionViewModel.code_Renta
                    };

                    if (cotizacionViewModel.check != false)
                    {
                        var response = _insumoService.InsertarCotizacionDetalle(modelo2);
                    }
                    else
                    {
                        var response = _insumoService.EliminarCotizacionDetalle(modelo2);
                    }
                }

                var responses = _insumoService.BuscarCotizacion(CotizacionViewModel[0].coti_Id);
                var lista = responses.Data as List<tbCotizaciones>;

                // Obtener los codeIds y ordenarlos de manera ascendente
                var codeIds = lista.Select(x => x.code_Id).OrderBy(x => x).ToList();
                string codeIdsString = string.Join(",", codeIds);

                responses.Message = codeIdsString;
                return Ok(responses);
            }
        }



        /// <summary>
        /// Finaliza una cotización específica por su ID.
        /// </summary>
        /// <param name="id">ID de la cotización a finalizar.</param>
        /// <returns>Resultado de la operación de finalizacion.</returns>
        [HttpDelete("Finalizar")]
        public IActionResult Finalizar(int id)
        {
            var response = _insumoService.FinalizarCotizacion(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }


        /// <summary>
        /// Finaliza una cotización específica por su ID.
        /// </summary>
        /// <param name="id">ID de la cotización a finalizar.</param>
        /// <returns>Resultado de la operación de finalizacion.</returns>
        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(int id)
        {
            var response = _insumoService.EliminarCotizacion(id);
            if (response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return Problem();
            }
        }






    }
}
