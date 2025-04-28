using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class ViaticoDetalleService
    {
        private readonly ViaticoDetalleRepository _viaticoDetalleRepository;

        public ViaticoDetalleService(ViaticoDetalleRepository viaticoDetalleRepository)
        {
            _viaticoDetalleRepository = viaticoDetalleRepository;
        }

        public ServiceResult ListarViaticosDetalles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoDetalleRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarViaticoDetalle(int? vide_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoDetalleRepository.Delete(vide_Id);
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

        public ServiceResult InsertarViaticoDetalle(tbViaticosDetalles item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _viaticoDetalleRepository.Insert(item);
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

        public ServiceResult BuscarViaticoDetalle(int? vide_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoDetalleRepository.Find(vide_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult ActualizarViaticoDetalle(tbViaticosDetalles item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _viaticoDetalleRepository.Update(item);
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
