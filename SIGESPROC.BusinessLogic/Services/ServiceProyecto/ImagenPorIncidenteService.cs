using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ImagenPorIncidenteService
{
    public class ImagenPorIncidenteService
    {
        private readonly ImagenPorIncidenteRepository _imagenPorIncidenteRepository;

        public ImagenPorIncidenteService(
               ImagenPorIncidenteRepository imagenPorIncidenteRepository
             )

        {
            _imagenPorIncidenteRepository = imagenPorIncidenteRepository;
        }

        public ServiceResult ListarImagenesPorIncidente()
        {
            var result = new ServiceResult();
            try
            {
                var list = _imagenPorIncidenteRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarImagenPorIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorIncidenteRepository.List(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public virtual ServiceResult InsertarImagenPorIncidente(tbImagenesPorIncidencias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorIncidenteRepository.Insert(item);
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

        public virtual ServiceResult ActualizarImagenPorIncidente(tbImagenesPorIncidencias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorIncidenteRepository.Update(item);
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

        public ServiceResult EliminarImagenPorIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorIncidenteRepository.Delete(id);
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
