using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class CostoPorActividadService
    {
        private readonly CostoPorActividadRepository _costoPorActividadRepository;

        /// <summary>
        /// Servicio que gestiona la lógica de negocio relacionada con un costo por actividad
        /// </summary>
        public CostoPorActividadService(CostoPorActividadRepository costoPorActividadRepository)
        {
            _costoPorActividadRepository = costoPorActividadRepository;

        }
        /// <summary>
        /// Lista de costo por actividad.
        /// </summary>

        public ServiceResult ListarCostoActividad()
        {
            var result = new ServiceResult();
            try
            {
                var list = _costoPorActividadRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }




        /// <summary>
        /// Elimina un costo por actividadespecífica.
        /// </summary>
        /// <param name="id">Id del costo por actividad a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarCostoActividad(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _costoPorActividadRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un costo por actividad
        /// </summary>
        /// <param name="item">Entidad de costo por actividad</param>
        /// <returns>Resultado de la operación.</returns>

        public ServiceResult InsertarCostoActividad(tbCostoPorActividad item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _costoPorActividadRepository.Insert(item);
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
        /// Busca un Costo por actividad específico.
        /// </summary>
        /// <param name="id">Id del  Costo por actividad a buscar.</param>
        /// <returns>Del  Costo por actividad encontrado o un mensaje de error.</returns>
     
        public ServiceResult BuscarCostoActividad(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _costoPorActividadRepository.Find(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        /// <summary>
        /// Actualiza un  Costo por actividad existente.
        /// </summary>
        /// <param name="item">Entidad de  Costo por actividad.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarCostoActividad(tbCostoPorActividad item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _costoPorActividadRepository.Update(item);
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
