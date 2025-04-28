using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ProyectoService
{
    public class IncidenteService
    {
        private readonly IncidenteRepository _incidenteRepository;

        public IncidenteService(
               IncidenteRepository incidenteRepository
             )

        {
            _incidenteRepository = incidenteRepository;
        }

        public ServiceResult ListarIncidentes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _incidenteRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarIncidente(tbIncidentes item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Insert(item);
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

        public ServiceResult ActualizarIncidente(tbIncidentes item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Update(item);
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

        public ServiceResult EliminarIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Delete(id);
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
