using SIGESPROC.DataAccess.Repositories.RepositoryFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceFlete
{
    public class FleteControlCalidadService
    {
        private readonly FleteControlCalidadRepository _fleteControlCalidadRepository;
        public FleteControlCalidadService(FleteControlCalidadRepository fleteControlCalidadRepository)
        {
            _fleteControlCalidadRepository = fleteControlCalidadRepository;

        }

        public ServiceResult ListarFleteControlCalidad()
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteControlCalidadRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }


        public ServiceResult BuscarFleteControlCalidadIncidencias(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteControlCalidadRepository.FindIncidencias(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarFleteControlCalidad(int frecId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteControlCalidadRepository.Delete(frecId);
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

        public ServiceResult InsertarFleteControlCalidad(tbFletesControlCalidad item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteControlCalidadRepository.Insert(item);
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

        public ServiceResult BuscarFleteControlCalidad(int frecId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteControlCalidadRepository.Find(frecId);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult ActualizarFleteControlCalidad(tbFletesControlCalidad item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteControlCalidadRepository.Update(item);
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
