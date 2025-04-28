using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class PrestamoService
    {
        private readonly PrestamoRepository _prestamoRepository;
        public PrestamoService(PrestamoRepository prestamoService)
        {
            _prestamoRepository = prestamoService;

        }
        /// <summary>
        /// Obtiene una lista de todos los préstamos.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de préstamos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarPrestamos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _prestamoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Obtiene una lista de todos los abonos.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de abonos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarAbonos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _prestamoRepository.ListAbonos();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Elimina un préstamo específico.
        /// </summary>
        /// <param name="presId">ID del préstamo a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarPrestamo(int presId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _prestamoRepository.Delete(presId);
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
        /// Inserta un nuevo préstamo en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPrestamos que contiene los datos del préstamo a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult InsertarPrestamo(tbPrestamos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _prestamoRepository.Insert(item);
                if (map.CodeStatus == 1)
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
        /// Inserta un nuevo abono a un préstamo específico en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbAbonosPorPrestamos que contiene los datos del abono a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult InsertarAbono(tbAbonosPorPrestamos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _prestamoRepository.InsertAbono(item);
                if (map.CodeStatus == 1)
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

        public ServiceResult InsertPrestamosPlanilla(string item)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Insert del repositorio para insertar la planilla y obtenemos el resultado
                var map = _prestamoRepository.InsertPrestamosPlanilla(item);

                // Verificamos el estado de la respuesta
                // Si CodeStatus no es 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                if (map.CodeStatus == 2)
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
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarCuotaPorEmpleados(tbPrestamos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _prestamoRepository.InsertarCuotaPorEmpleado(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(result.Message);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarPrestamo(int frecId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _prestamoRepository.Find(frecId);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        /// <summary>
        /// Actualiza un préstamo existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPrestamos que contiene los datos actualizados del banco.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult ActualizarPrestamo(tbPrestamos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _prestamoRepository.Update(item);
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
        /// Actualiza un abono de un préstamo existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbAbonosPorPrestamos que contiene los datos actualizados del abono.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso cosntrario.</returns>
        public ServiceResult ActualizarAbono(tbAbonosPorPrestamos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _prestamoRepository.UpdateAbono(item);
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


    }
}
