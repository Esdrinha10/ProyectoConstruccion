using SIGESPROC.DataAccess.Repositories.RepositoryInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceInsumo
{
    public class InsumoService
    {
        private readonly BodegaRepository _bodegaRepository;
        private readonly BodegaPorInsumoRepository _bodegaPorInsumoRepository;
        private readonly CotizacionRepository _cotizacionRepository;
        private readonly CompraEncabezadoRepository _compraEncabezadoRepository;
        private readonly CotizacionDetalleRepository _cotizacionDetalleRepository;
        private readonly InsumoPorMedidaRepository _insumoPorMedidaRepository;
        private readonly InsumoPorProveedorRepository _insumoPorProveedorRepository;
       
        private readonly InsumoRepository _insumoRepository;
        private readonly MaterialRepository _materialRepository;
        private readonly ProveedorRepository _proveedorRepository;
        public readonly MaquinariaRepository _maquinariaRepository;
        public readonly MaquinariaPorProveedorRepository _maquinariaPorProveedorRepository;
        private readonly SubCategoriaRepository _subCategoriaRepository;
        private readonly CompraDetalleRepository _compraDetalleRepository;

        private readonly CotizacionPorDocumentoRepository _cotizacionPorDocumentoRepository;


        public InsumoService(
               CotizacionDetalleRepository cotizacionDetalleRepository, 
               CotizacionRepository cotizacionRepository, 
               InsumoPorMedidaRepository insumoPorMedidaRepository, 
               InsumoPorProveedorRepository insumoPorProveedorRepository, 
              
               InsumoRepository insumoRepository,
               MaterialRepository materialRepository, 
               ProveedorRepository proveedorRepository,
               BodegaRepository bodegaRepository,
               BodegaPorInsumoRepository bodegaPorInsumoRepository,
               CompraEncabezadoRepository compraEncabezadoRepository,
               MaquinariaRepository maquinariaRepository,
               MaquinariaPorProveedorRepository maquinariaPorProveedorRepository,
               SubCategoriaRepository subCategoriaRepository,
               CompraDetalleRepository compraDetalleRepository,
               CotizacionPorDocumentoRepository cotizacionPorDocumentoRepository
             )

        {
            _cotizacionDetalleRepository = cotizacionDetalleRepository;
            _cotizacionRepository = cotizacionRepository;
            _insumoPorMedidaRepository = insumoPorMedidaRepository;
            _insumoPorProveedorRepository = insumoPorProveedorRepository;
          
            _insumoRepository = insumoRepository;
            _materialRepository = materialRepository;
            _proveedorRepository = proveedorRepository;
            _bodegaRepository = bodegaRepository;
            _bodegaPorInsumoRepository = bodegaPorInsumoRepository;
            _compraEncabezadoRepository = compraEncabezadoRepository;
          
            _maquinariaRepository = maquinariaRepository;
            _maquinariaPorProveedorRepository = maquinariaPorProveedorRepository;
            _subCategoriaRepository = subCategoriaRepository;
            _compraDetalleRepository = compraDetalleRepository;
            _cotizacionPorDocumentoRepository = cotizacionPorDocumentoRepository;
        }


        #region CotizacionDetalles
        public ServiceResult ListarCotizacionDetalles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionDetalleRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarCotizacionDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _cotizacionDetalleRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Inserta un nuevo detalle de cotización en el sistema.
        /// </summary>
        /// <param name="item">El objeto tbCotizacionesDetalle que contiene los datos del detalle de cotización a insertar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación, incluyendo el código de estado y un mensaje en caso de éxito o error.</returns>
        public ServiceResult InsertarCotizacionDetalle(tbCotizacionesDetalle item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionDetalleRepository.Insert(item);

                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult ActualizarCotizacionDetalle(tbCotizacionesDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _cotizacionDetalleRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCotizacionDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _cotizacionDetalleRepository.Delete(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
          
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un detalle específico de una cotización en el sistema.
        /// </summary>
        /// <param name="tbCotizacionesDetalle">El objeto tbCotizacionesDetalle que contiene los datos del detalle de cotización a eliminar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación, incluyendo el código de estado y un mensaje en caso de éxito o error.</returns>
        public ServiceResult EliminarCotizacionDetalle(tbCotizacionesDetalle tbCotizacionesDetalle)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionDetalleRepository.Delete(tbCotizacionesDetalle);

                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Materiales
        /// <summary>
        /// Elimina un material por su ID.
        /// </summary>
        /// <param name="id">El ID del material a eliminar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult EliminarMaterial(int? id)
        {
            var result = new ServiceResult();

            try
            {
                // Llamamos al método Delete del repositorio para eliminar el material y obtenemos el resultado
                var request = _materialRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un material por su ID.
        /// </summary>
        /// <param name="id">El ID del material a buscar</param>
        /// <returns>Un objeto ServiceResult que contiene el material encontrado</returns>
        public ServiceResult BuscarMaterial(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var material = _materialRepository.Find(id);

                return result.Ok(material);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo material.
        /// </summary>
        /// <param name="item">El objeto tbMateriales a insertar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult InsertarMaterial(tbMateriales item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _materialRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Conflict();
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un material existente.
        /// </summary>
        /// <param name="item">El objeto tbMateriales con los datos actualizados</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult ActualizarMaterial(tbMateriales item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _materialRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos los materiales.
        /// </summary>
        /// <returns>Un objeto ServiceResult que contiene la lista de materiales</returns>
        public ServiceResult ListarMateriales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _materialRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Subcategorias

        // M�todo para listar todas las subcategor�as
        public ServiceResult ListarSubcategorias()
        {
            var result = new ServiceResult();
            try
            {
                var list = _subCategoriaRepository.List(); // Llama al repositorio para obtener la lista de subcategor�as
                return result.Ok(list); // Retorna la lista en caso de �xito
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        // M�todo para listar las subcategor�as por categor�a
        public ServiceResult ListarSubcategorias(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _subCategoriaRepository.ListPorCategoria(id); // Llama al repositorio para obtener la lista de subcategor�as filtradas por categor�a
                return result.Ok(list); // Retorna la lista en caso de �xito
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        // M�todo para buscar una subcategor�a por su ID
        public ServiceResult BuscarSubcategorias(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _subCategoriaRepository.Find(id); // Llama al repositorio para buscar la subcategor�a por su ID
                return result.Ok(map); // Retorna la subcategor�a en caso de �xito
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        // M�todo para insertar una nueva subcategor�a
        public ServiceResult InsertarSubcategorias(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _subCategoriaRepository.Insert(item); // Llama al repositorio para insertar la nueva subcategor�a
                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        // M�todo para actualizar una subcategor�a existente
        public ServiceResult ActualizarSubcategorias(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _subCategoriaRepository.Update(item); // Llama al repositorio para actualizar la subcategor�a existente
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna el resultado en caso de �xito
                }
                else
                {
                    return result.Error(map); // Retorna el resultado con error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        // M�todo para eliminar una subcategor�a por su ID
        public ServiceResult EliminarSubcategorias(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _subCategoriaRepository.Delete(id); // Llama al repositorio para eliminar la subcategor�a por su ID
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error en caso de excepci�n
            }
        }

        #endregion

        #region Insumos
        /// <summary>
        /// Lista todo los insumos.
        /// </summary>
        /// <returns>Una lista de insumos.</returns>
        public ServiceResult ListarInsumos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Lista todo las categoria.
        /// </summary>
        /// <returns>Una lista de categoria.</returns>
        public ServiceResult ListarCate()
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoRepository.ListCate();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        /// <summary>
        /// Busca un Insumo.
        /// </summary>
        /// <param name="id">ID del Insumo.</param>
        /// <returns>El Insumo encontrada o un mensaje de error.</returns>
        public ServiceResult BuscarInsumo(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Muestra la sub categoria.
        /// </summary>
        /// <param name="id">ID de la categoria.</param>
        /// <returns>La sub categoria encontrada o un mensaje de error.</returns>
        public ServiceResult MostrarSubPorCate(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoRepository.FindCate(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo insumo.
        /// </summary>
        /// <param name="item">Entidad de insumo.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult InsertarInsumo(tbInsumos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoRepository.Insert(item);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza un insumo por etapa existente.
        /// </summary>
        /// <param name="item">Entidad de insumo.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarInsumo(tbInsumos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un insumo por etapa específica.
        /// </summary>
        /// <param name="id">ID del insumo a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarInsumo(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoRepository.Delete(id);
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Proveedor
        /// <summary>
        /// Obtiene una lista de todos los proveedores.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de proveedores o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarProveedores()
        {
            var result = new ServiceResult();

            try
            {
                var list = _proveedorRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un proveedor específico.
        /// </summary>
        /// <param name="id">ID del proveedor a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarProveedor(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proveedorRepository.Delete(id);

                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor a buscar.</param>
        /// <returns>Un mensaje de éxito con el proveedor encontrado o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarProveedor(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var proveedor = _proveedorRepository.Find(id);
                return result.Ok(proveedor);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Inserta un nuevo proveedor en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbProveedores que contiene los datos del proveedor a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult InsertarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proveedorRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Ok(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un proveedor existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbProveedores que contiene los datos actualizados del proveedor.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult ActualizarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proveedorRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        #endregion

        #region InsumoPorMedidas

        public ServiceResult InsertarInsumoPorMedida(tbInsumosPorMedidas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorMedidaRepository.Insert(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
                var list = _proveedorRepository.List();

                return result.Ok(list);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult BuscarMedidasInsumo(int prov,int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorMedidaRepository.Buscar(prov,id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarInsumoPorMedida(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorMedidaRepository.Delete(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }

           }    
          
           catch (Exception ex)
           {
                  return result.Error(ex.Message);
           }
          
        }
        #endregion
        
        #region InsumoPorProveedores


        public ServiceResult ListarInsumoPorProveedor()
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoPorProveedorRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarInsumosPorProveedores(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoPorProveedorRepository.Listar(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarInsumoPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorProveedorRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarInsumoPorProveedor(tbInsumosPorProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorProveedorRepository.Insert(item);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarInsumoPorProveedor(tbInsumosPorProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorProveedorRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarInsumoPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoPorProveedorRepository.Delete(id);
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        
        #region Bodegas
        /// <summary>
        /// Lista todas las bodegas.
        /// </summary>
        /// <returns>Un objeto ServiceResult que contiene la lista de bodegas</returns>
        public ServiceResult ListarBodega()
        {
            var result = new ServiceResult();
            try
            {
                var list = _bodegaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarBodegaInsumos(int id, int bode)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaRepository.BuscarBodegaInsumos(id, bode);

                return result.Ok(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta una nueva bodega.
        /// </summary>
        /// <param name="item">El objeto tbBodegas a insertar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult InsertarBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaRepository.Insert(item);

                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza una bodega existente.
        /// </summary>
        /// <param name="item">El objeto tbBodegas con los datos actualizados</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult ActualizarBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _bodegaRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca una bodega por su ID.
        /// </summary>
        /// <param name="id">El ID de la bodega a buscar</param>
        /// <returns>Un objeto ServiceResult que contiene la bodega encontrada</returns>
        public ServiceResult BuscarBodega(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca los Insumos y Equipos de seguridad de una bodega.
        /// </summary>
        /// <param name="id">El ID de la bodega a buscar</param>
        /// <returns>Un objeto ServiceResult que contiene los insumos y equipos encontrados</returns>
        public ServiceResult BuscarInsumosEquipoSeguridad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaRepository.FindInsumosEquiposSeguridad(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una bodega por su ID.
        /// </summary>
        /// <param name="id">El ID de la bodega a eliminar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult EliminarBodega(int? id)
        {
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Delete del repositorio para eliminar la bodega y obtenemos el resultado
                var request = _bodegaRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Bodegas Por Insumos
        public ServiceResult ListarBodegasPorInsumos(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _bodegaPorInsumoRepository.List1(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult InsertarBodegaPorInsumo(tbBodegasPorInsumo item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaPorInsumoRepository.Insert(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ActualizarBodegaPorInsumo(tbBodegasPorInsumo item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaPorInsumoRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map.MessageStatus);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        
        public ServiceResult EliminarBodegaPorInsumo(tbBodegasPorInsumo item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bodegaPorInsumoRepository.Delete(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Cotizaciones
        /// <summary>
        /// Obtiene la lista de todas las cotizaciones disponibles.
        /// </summary>
        /// <returns>Un objeto ServiceResult que contiene la lista de cotizaciones o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarCotizacion()
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }





        /// <summary>
        /// Inserta una nueva cotización en el sistema.
        /// </summary>
        /// <param name="item">El objeto tbCotizaciones que contiene los datos de la cotización a insertar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación, incluyendo el id de la cotizacion y un mensaje en caso de éxito o error.</returns>
        public ServiceResult InsertarCotizacion(tbCotizaciones item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionRepository.Insert(item);

                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



       



        /// <summary>
        /// Obtiene una lista de cotizaciones asociadas a un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">ID del proveedor cuyas cotizaciones se desean listar.</param>
        /// <returns>Un objeto ServiceResult que contiene la lista de cotizaciones o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarCotizacionPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionRepository.ListCotizacionPorProveedor(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Busca los artículos relacionados con una cotización específica utilizando el ID del proveedor y el ID de la cotización.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Un objeto ServiceResult que contiene el mapa de artículos encontrados o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarCotizacion(int id, int coti)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionRepository.BuscarArticulos(id, coti);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca los artículos relacionados con una cotización específica utilizando el ID de la cotización.
        /// </summary>
        /// <param name="id">ID de la cotización.</param>
        /// <returns>Un objeto ServiceResult que contiene el los id de los detalles de esa cotizacion o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarCotizacion(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionRepository.BuscarArticulos(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Finaliza una cotización específica por su ID.
        /// </summary>
        /// <param name="id">ID de la cotización a Finalizar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación.</returns>
        public ServiceResult FinalizarCotizacion(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionRepository.Finalizar(id);

                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una cotización y sus detalles específica por su ID.
        /// </summary>
        /// <param name="id">ID de la cotización a Eliminar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación.</returns>
        public ServiceResult EliminarCotizacion(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionRepository.Delete(id);

                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        #endregion

        #region CotizacionesPorDocumentos







        /// <summary>
        /// Inserta una nueva cotización en el sistema.
        /// </summary>
        /// <param name="name">El nombre del documento a insertar.</param>
        /// <param name="id">El id del documento a donde debe insertarlo.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación, incluyendo el id de la cotizacion y un mensaje en caso de éxito o error.</returns>
        public ServiceResult InsertarCotizacionPorDocumento(tbCotizaciones item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionPorDocumentoRepository.Insert(item);

                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }




        /// <summary>
        /// Obtiene una lista de documentos asociados a una cotizacion específico por su ID.
        /// </summary>
        /// <param name="id">ID de la cotizacion cuyos documentos se desean listar.</param>
        /// <returns>Un objeto ServiceResult que contiene la lista de  los documentos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarCotizacionesPorDocumentoPDF(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionPorDocumentoRepository.ListarPDF(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene una lista de documentos asociados a una cotizacion específico por su ID.
        /// </summary>
        /// <param name="id">ID de la cotizacion cuyos documentos se desean listar.</param>
        /// <returns>Un objeto ServiceResult que contiene la lista de  los documentos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarCotizacionesPorDocumentoWord(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionPorDocumentoRepository.ListarWord(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una lista de documentos asociados a una cotizacion específico por su ID.
        /// </summary>
        /// <param name="id">ID de la cotizacion cuyos documentos se desean listar.</param>
        /// <returns>Un objeto ServiceResult que contiene la lista de  los documentos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarCotizacionesPorDocumentoImagenes(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cotizacionPorDocumentoRepository.ListarImagenes(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un documento específico.
        /// </summary>
        /// <param name="id">ID del documento a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarCotizacionPorDocumento(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _cotizacionPorDocumentoRepository.Delete(id);

                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }





        #endregion

        #region Compra Encabezado
        /// <summary>
        /// Lista todos los encabezados de compra disponibles.
        /// </summary>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de encabezados de compra o un mensaje de error.</returns>
        public ServiceResult ListarCompraEncabezado()
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraEncabezadoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Lista los métodos de pago disponibles.
        /// </summary>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de métodos de pago o un mensaje de error.</returns>
        public ServiceResult ListarMetodosPago()
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraEncabezadoRepository.ListMeto();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca los encabezados de compra dentro de un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de encabezados de compra encontrados o un mensaje de error.</returns>
        public ServiceResult FindFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraEncabezadoRepository.FindFechas(fechaInicio, fechaFin);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un encabezado de compra por el ID de cotización.
        /// </summary>
        /// <param name="coti_Id">ID de la cotización.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene el encabezado de compra asociado o un mensaje de error.</returns>
        public ServiceResult FindByCotizacionId(int coti_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraEncabezadoRepository.FindByCotizacionId(coti_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un detalle de compra por el ID de cotización.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene los detalles de la compra o un mensaje de error.</returns>
        public ServiceResult FindByCotizacionCompraDetalleId(string coen_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraEncabezadoRepository.FindByCotizacionCompraDetalleId(coen_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo encabezado de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraEncabezado(tbComprasEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.Insert(item);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo encabezado de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult ActualizarCompraEncabezadoNumero(tbComprasEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.UpdateCompra(item);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una compra completa por su ID de encabezado.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult EliminarCompra(string coen_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.EliminarCompra(coen_Id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Verifica si un número de compra es único para una cotización específica.
        /// </summary>
        /// <param name="coen_numeroCompra">Número de compra a verificar.</param>
        /// <param name="coti_Id">ID de la cotización.</param>
        /// <returns>Resultado de la verificación (1 si es único, 0 si está duplicado).</returns>
        public ServiceResult VerificarNumeroCompraUnico(string coen_numeroCompra, int prov_Id)
        {
            var result = new ServiceResult();
            try
            {
                var esUnico = _compraEncabezadoRepository.VerificarNumeroCompraUnico(coen_numeroCompra, prov_Id);
                return result.Ok(esUnico);  // esUnico será 1 o 0
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Actualiza un encabezado de compra existente en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos actualizados del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult ActualizarCompraEncabezado(tbComprasEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene el encabezado de compra encontrado o un mensaje de error.</returns>
        public ServiceResult BuscarCompraEncabezado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra a eliminar.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult EliminarCompraEncabezado(string id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraEncabezadoRepository.Delete(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region CompraDetalles
        /// <summary>
        /// Lista todos los detalles de compra disponibles.
        /// </summary>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de detalles de compra o un mensaje de error.</returns>
        public ServiceResult ListarCompraDetalle()
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraDetalleRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Lista los detalles de compra para un destino específico.
        /// </summary>
        /// <param name="id">ID del destino.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de detalles de compra para el destino o un mensaje de error.</returns>
        public ServiceResult ListarCompraDetalleDestino(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraDetalleRepository.ListPorDetalleCompraDetalleDestino(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Lista los detalles de compra para un destino específico de maquinaria.
        /// </summary>
        /// <param name="id">ID del destino de maquinaria.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de detalles de compra de maquinaria para el destino o un mensaje de error.</returns>
        public ServiceResult ListarCompraDetalleDestinoMaquinaria(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraDetalleRepository.ListPorDetalleCompraDetalleDestinoMaquinaria(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraDetalle(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.Insert(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraDetalleDestino(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.InsertCompraDetalleDestino(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino exacto.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino exacto.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraDetalleDestinoExacto(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.InsertCompraDetalleDestinoExacto(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Lista las actividades por etapas relacionadas con un ID de compra.
        /// </summary>
        /// <param name="id">ID de la compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene la lista de actividades por etapas o un mensaje de error.</returns>
        public ServiceResult ListarActividadesPorEtapas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraDetalleRepository.ListarActividadesPorEtapas(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino por proyecto por defecto.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino por proyecto por defecto.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraDetalleDestinoPorProyectoPorDefecto(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.InsertCompraDetalleDestinoProyecto(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map.Message);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino por proyecto.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino por proyecto.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult InsertarCompraDetalleDestinoPorProyecto(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.InsertCompraDetalleDestinoProyectoExacto(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un detalle de compra de maquinaria por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra de maquinaria a eliminar.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult EliminarCompraDetalleDestinoMaquinaria(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.DeleteDestinoMaquinaria(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino por defecto.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos actualizados del detalle de compra con destino por defecto.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult ActualizarCompraDetalleDestinoDefecto(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.UpdateCompraDetalleDestinoDefecto(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra existente.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos actualizados del detalle de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult ActualizarCompraDetalle(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino existente.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos actualizados del detalle de compra con destino.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult ActualizarCompraDetalleDestino(tbComprasDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.UpdateCompraDetalleDestino(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene el detalle de compra encontrado o un mensaje de error.</returns>
        public ServiceResult BuscarCompraDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un detalle de compra por su ID de encabezado.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene el detalle de compra encontrado o un mensaje de error.</returns>
        public ServiceResult BuscarCompraDetalleEncabezado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.BuscardetallesEncabezado(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un detalle de compra con destino por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que contiene el detalle de compra con destino encontrado o un mensaje de error.</returns>
        public ServiceResult BuscarCompraDetalleDestino(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.FindCompraDetalleDestino(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra a eliminar.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult EliminarCompraDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.Delete(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un detalle de compra con destino por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino a eliminar.</param>
        /// <returns>Un objeto <see cref="ServiceResult"/> que indica el resultado de la operación o un mensaje de error.</returns>
        public ServiceResult EliminarCompraDetalleDestino(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _compraDetalleRepository.DeleteCompraDetalleDestino(id);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Maquinarias
        public ServiceResult ListarMaquinarias()//Serivicio de listar maquinaria que retorna un service result
        {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _maquinariaRepository.List(); //variable que almacena el resultado que retorna el listado del repositorio
                return result.Ok(list); //retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }

        }

        public ServiceResult BuscarMaquinaria(int id)//Serivicio de buscar maquinaria que retorna un service result y pide un id
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _maquinariaRepository.Find(id);//variable que almacena el resultado que retorna el buscar del repositorio
                return result.Ok(map);  //retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult InsertarMaquinaria(tbMaquinarias item)//Serivicio de insertar maquinaria que retorna un service result y pide el entitie de tbmaquinaria
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _maquinariaRepository.Insert(item);//variable que almacena el resultado recivido del repositorio que solicita el modelo de entitie
                if (map.CodeStatus != 0)//valida si el codigo enviado por la api es distinto de 0
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult ActualizarMaquinaria (tbMaquinarias item)//Serivicio de actulizar maquinaria que retorna un service result que pide el entitie de tbmaquinaria
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _maquinariaRepository.Update(item);//variable que almacena el resultado recivido del repositorio que solicita el modelo de entitie
                if (map.CodeStatus == 1) //valida que el resultado que envia el repositorio sea igual a 1
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult EliminarMaquinaria(int id)//Serivicio de eliminar maquinaria que retorna un service result y pide el id del campo
        {
            var result = new ServiceResult(); // Inicializamos el objeto ServiceResult que contendrá el resultado de la operación

            try
            {
                // Llamamos al método Delete del repositorio para eliminar la maquinaria y obtenemos el resultado
                var map = _maquinariaRepository.Delete(id);
                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error

                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // En caso de excepción, retornamos el error en el objeto result

            }
        }

        #endregion

        #region MaquinariasProProveedores
        public ServiceResult ListarMaquinariasPorProveedores()
        {
            var result = new ServiceResult();
            try
            {
                var list = _maquinariaPorProveedorRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult InsertarMaquinariaPorProveedor(tbMaquinariasPorProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _maquinariaPorProveedorRepository.Insert(item);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult BuscarMaquinariasPorProveedores(int prov)
        {
            var result = new ServiceResult();
            try
            {
                var map = _maquinariaPorProveedorRepository.Buscar(prov);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarMaquinariaPorProveedor(tbMaquinariasPorProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _maquinariaPorProveedorRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarMaquinariaPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _maquinariaPorProveedorRepository.Delete(id);
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
    }
}
