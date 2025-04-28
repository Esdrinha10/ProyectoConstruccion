using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ProyectoService
{
    public class IncidentePorActividadService
    {
        private readonly IncidentePorActividadRepository _incidentePorActividadRepository;

        public IncidentePorActividadService(
               IncidentePorActividadRepository incidentePorActividadRepository
             )

        {
            _incidentePorActividadRepository = incidentePorActividadRepository;
        }

        public ServiceResult ListarIncidentesPorActividad()
        {
            var result = new ServiceResult();
            try
            {
                var list = _incidentePorActividadRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarIncidentePorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidentePorActividadRepository.List(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarIncidentePorActividad(tbIncidenciasPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidentePorActividadRepository.Insert(item);
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

        public ServiceResult ActualizarIncidentePorActividad(tbIncidenciasPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidentePorActividadRepository.Update(item);
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

        public ServiceResult EliminarIncidentePorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidentePorActividadRepository.Delete(id);
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
