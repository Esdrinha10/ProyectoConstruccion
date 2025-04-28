using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic;
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
    public class BodegaController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador BodegaController.
        /// </summary>
        /// <param name="insumoService">Servicio de insumos para manejar la lógica de negocio</param>
        /// <param name="mapper">Mapper para convertir entre modelos de vista y entidades</param>
        public BodegaController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint para listar todas las bodegas.
        /// </summary>
        /// <returns>Lista de bodegas</returns>
        [HttpGet("Listar")]
        public IActionResult ListarBodegas()
        {
            var response = _insumoService.ListarBodega();
            return Ok(response.Data);
        }


        [HttpGet("ListarInsumos/{id},{bode}")]
        public IActionResult ListarInsumos(int id, int bode)
        {
            var response = _insumoService.BuscarBodegaInsumos(id, bode);
            if (response.Success == true)
            {
                return Ok(response.Data);

            }
            else
            {
                return Problem(response.Data);

            }
        }

        /// <summary>
        /// Endpoint para buscar una bodega por su ID.
        /// </summary>
        /// <param name="id">ID de la bodega a buscar</param>
        /// <returns>La bodega encontrada</returns>
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarBodega(int id)
        {
            var response = _insumoService.BuscarBodega(id);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint para buscar una los Insumos y Equipos de seguridad de una bodega por el ID de la bodega.
        /// </summary>
        /// <param name="id">ID de la bodega a buscar</param>
        /// <returns>Los insumos y equipos encontrados</returns>
        [HttpGet("BuscarInsumosEquipoSeguridad/{id}")]
        public IActionResult BuscarInsumosEquipoSeguridad(int id)
        {
            var response = _insumoService.BuscarInsumosEquipoSeguridad(id);
            return Ok(response.Data);
        }



        /// <summary>
        /// Endpoint para insertar una nueva bodega.
        /// </summary>
        /// <param name="item">Modelo de vista de la bodega a insertar</param>
        /// <returns>Resultado de la operación de inserción</returns>
        [HttpPost("Insertar")]
        public IActionResult CreateBodega(List<BodegaViewModel> BodegaViewModels)
        {

                var insert = 0;
                foreach (var bodegaViewModel in BodegaViewModels)
                {
                    if (bodegaViewModel.bode_Id != 0)
                    {
                        insert = bodegaViewModel.bode_Id;
                    }
                }

                if(insert == 0)
                {
                var modelo = new tbBodegas()
                {
                    bode_Descripcion = BodegaViewModels[0].bode_Descripcion,
                    bode_Latitud = BodegaViewModels[0].bode_Latitud,
                    bode_Longitud = BodegaViewModels[0].bode_Longitud,
                    bode_LinkUbicacion = BodegaViewModels[0].bode_LinkUbicacion,
                    usua_Creacion = BodegaViewModels[0].usua_Creacion,
                    bode_FechaCreacion = DateTime.Now
                };

                var response = _insumoService.InsertarBodega(modelo);

                return Ok(response);

                }
                else
                {
                var response = new ServiceResult();

                foreach (var bodegaViewModel in BodegaViewModels)
                {
                    var modelo2 = new tbBodegasPorInsumo()
                    {
                        inpp_Id = bodegaViewModel.inpp_Id,
                        bode_Id = bodegaViewModel.bode_Id,
                        bopi_Stock = bodegaViewModel.bopi_Stock,
                        usua_Creacion = bodegaViewModel.usua_Creacion,
                        bopi_FechaCreacion = DateTime.Now
                    };

                    if (bodegaViewModel.check != false)
                    {
                        response = _insumoService.InsertarBodegaPorInsumo(modelo2);
                    }
                }

                return Ok(response);
                }


                
            
        }

        /// <summary>
        /// Endpoint para actualizar una bodega existente.
        /// </summary>
        /// <param name="item">Modelo de vista de la bodega a actualizar</param>
        /// <returns>Resultado de la operación de actualización</returns>
        [HttpPut("Actualizar")]
        public IActionResult Update(List<BodegaViewModel> BodegaViewModels)
        {

            var modelo = new tbBodegas()
            {
                bode_Id = BodegaViewModels[0].bode_Id,
                bode_Descripcion = BodegaViewModels[0].bode_Descripcion,
                bode_Latitud = BodegaViewModels[0].bode_Latitud,
                bode_Longitud = BodegaViewModels[0].bode_Longitud,
                bode_LinkUbicacion = BodegaViewModels[0].bode_LinkUbicacion,
                usua_Modificacion = BodegaViewModels[0].usua_Modificacion,
                bode_FechaModificiacion = DateTime.Now
            };

            var response = _insumoService.ActualizarBodega(modelo);

            foreach (var bodegaViewModel in BodegaViewModels)
            {
                var modelo2 = new tbBodegasPorInsumo()
                {
                    inpp_Id = bodegaViewModel.inpp_Id,
                    bode_Id = BodegaViewModels[0].bode_Id,
                    bopi_Stock = bodegaViewModel.bopi_Stock,
                    usua_Creacion = bodegaViewModel.usua_Creacion,
                    bopi_FechaCreacion = DateTime.Now
                };

                if (bodegaViewModel.check != false)
                {
                    _insumoService.InsertarBodegaPorInsumo(modelo2);
                }
                else
                {
                    _insumoService.EliminarBodegaPorInsumo(modelo2);
                }
            }

            return Ok(response);
        }

        /// <summary>
        /// Endpoint para eliminar una bodega por su ID.
        /// </summary>
        /// <param name="id">ID de la bodega a eliminar</param>
        /// <returns>Resultado de la operación de eliminación</returns>
        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int? id)
        {
            var response = _insumoService.EliminarBodega(id);
            return Ok(response);
        }
    }
}
