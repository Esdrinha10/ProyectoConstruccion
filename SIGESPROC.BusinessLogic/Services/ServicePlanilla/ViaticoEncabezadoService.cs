using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
    public class ViaticoEncabezadoService
    {
        private readonly ViaticoEncabezadoRepository _viaticoEncabezadoRepository;
        private readonly ViaticoDetEncRepository _viaticoDetEncRepository;

        public ViaticoEncabezadoService(ViaticoEncabezadoRepository viaticoEncabezadoRepository, ViaticoDetEncRepository viaticoDetEncRepository)
        {
            _viaticoEncabezadoRepository = viaticoEncabezadoRepository;
            _viaticoDetEncRepository = viaticoDetEncRepository;
        }

        public ServiceResult ListarViaticosEncabezados(int? usua_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoEncabezadoRepository.ListR( usua_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarViaticoEncabezado(int? vien_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoEncabezadoRepository.Delete(vien_Id);
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

        public ServiceResult FinalizarViaticoEncabezado(int? vien_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoEncabezadoRepository.FnalizarEnc(vien_Id);
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

        public ServiceResult InsertarViaticoEncabezado(tbViaticosEncabezados item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _viaticoEncabezadoRepository.Insert(item);
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

        public ServiceResult BuscarViaticoEncabezado(int? vien_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoEncabezadoRepository.Find(vien_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult BuscarViaticoEncDet(int? vien_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _viaticoDetEncRepository.Find(vien_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult ActualizarViaticoEncabezado(tbViaticosEncabezados item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _viaticoEncabezadoRepository.Update(item);
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
