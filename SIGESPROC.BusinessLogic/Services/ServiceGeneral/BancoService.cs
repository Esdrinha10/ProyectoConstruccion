using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.BancoService
{
    public class BancoService
    {
        private readonly BancoRepository _bancoRepository;

        public BancoService(
               BancoRepository bancoRepository
             )

        {
            _bancoRepository = bancoRepository;
         
        }
        #region Bancos
        /// <summary>
        /// Obtiene una lista de todos los bancos.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de bancos o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarBancos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _bancoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Busca un banco específico por su ID.
        /// </summary>
        /// <param name="id">ID del banco a buscar.</param>
        /// <returns>Un mensaje de éxito con el banco encontrado o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarBanco(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _bancoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Inserta un nuevo banco en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbBancos que contiene los datos del banco a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public ServiceResult InsertarBanco(tbBancos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bancoRepository.Insert(item);
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
        /// Actualiza un banco existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbBancos que contiene los datos actualizados del banco.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult ActualizarBanco(tbBancos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bancoRepository.Update(item);
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
        /// Elimina un banco específico.
        /// </summary>
        /// <param name="id">ID del banco a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarBanco(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _bancoRepository.Delete(id);
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
    }
}
