using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.EmpleadoService
{
    public class EmpleadoService
    {
        private readonly EmpleadoRepository _empleadoRepository;

        public EmpleadoService(
               EmpleadoRepository empleadoRepository
             )

        {
            _empleadoRepository = empleadoRepository;
         
        }
        #region Empleados
        public ServiceResult ListarEmpleados()
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarEmpleado(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.Insert(item);
                if (map.CodeStatus > 0)
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

        public ServiceResult ActualizarEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.Update(item);
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
        public ServiceResult EliminarEmpleado(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.Delete(id);
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
