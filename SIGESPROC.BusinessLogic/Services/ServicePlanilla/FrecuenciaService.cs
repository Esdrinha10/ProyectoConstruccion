using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class FrecuenciaService
    {
        private readonly FrecuenciaRepository _frecuenciaRepository;

        // Constructor de la clase FrecuenciaService que recibe un repositorio de frecuencias
        public FrecuenciaService(FrecuenciaRepository frecuenciaService)
        {
            _frecuenciaRepository = frecuenciaService;
        }

        // Método para listar todas las frecuencias
        public ServiceResult ListarFrecuencia()
        {
            var result = new ServiceResult();
            try
            {
                var list = _frecuenciaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        // Método para eliminar una frecuencia por su ID
        public ServiceResult EliminarFrecuencia(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _frecuenciaRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        // Método para insertar una nueva frecuencia
        public ServiceResult InsertarFrecuencia(tbFrecuencias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _frecuenciaRepository.Insert(item);
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

        // Método para buscar una frecuencia por su ID
        public ServiceResult BuscarFrecuencia(int frecId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _frecuenciaRepository.Find(frecId);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        // Método para actualizar una frecuencia existente
        public ServiceResult ActualizarFrecuencia(tbFrecuencias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _frecuenciaRepository.Update(item);
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
