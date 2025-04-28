using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class DeduccionService
    {
        private readonly DeduccionRepository _deduccionRepository;
        public DeduccionService(DeduccionRepository deduccionRepository)
        {
            _deduccionRepository = deduccionRepository;
            
        }
        /// <summary>
        /// Obtiene una lista de todas las deducciones.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de deducciones o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarDeduccion()
        {
            var result = new ServiceResult();
            try
            {
                var list = _deduccionRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Obtiene una lista de todas las deducciones de un empleado específico.
        /// </summary>
        /// <param name="empl_Id">ID del empleado.</param>
        /// <returns>Un mensaje de éxito con la lista de deducciones o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarDeduccionPorEmpleado(int empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _deduccionRepository.ListDeduccionPorEmpleado(empl_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarDeduccionPorEmpleado(int empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _deduccionRepository.BuscarDeduccionPorEmpleado(empl_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Elimina una deducción específica.
        /// </summary>
        /// <param name="id">ID de la deducción a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarDeduccion(int deduccion_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _deduccionRepository.Delete(deduccion_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok("La acción ha sido exitosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la acción");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        /// <summary>
        /// Inserta una nueva deducción en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbDeducciones que contiene los datos de la deducción a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult InsertarDeduccion(tbDeducciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.Insert(item);
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

        public ServiceResult InsertarDeduccionPorEmpleado(DeduccionViewModel deduccion)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.InsertarDeduccionesPorPlanilla(deduccion);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error("El código no es válido");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Busca una deduccióna específica por su ID.
        /// </summary>
        /// <param name="id">ID de la deducción a buscar.</param>
        /// <returns>Un mensaje de éxito con la deducción encontrada o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarDeduccion(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _deduccionRepository.Find(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        /// <summary>
        /// Actualiza una deducción existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbDeducciones que contiene los datos actualizados de la deducción.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult ActualizarDeduccion(tbDeducciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.Update(item);
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
        /// Asigna o remueve una deducción a un empleado en la base de datos.
        /// </summary>
        /// <param name="deduccionPorEmpleadoViewModel">El objeto DeduccionPorEmpleadoViewModel que contiene los datos de la deducción a asignar o remover.</param>
        /// <returns>Un mensaje de éxito si la inserción o eliminación fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult DeduccionPorEmpleado(DeduccionPorEmpleadoViewModel deduccionPorEmpleadoViewModel)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.DeduccionPorEmpleado(deduccionPorEmpleadoViewModel);
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error("El código no es válido");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


    }
}
