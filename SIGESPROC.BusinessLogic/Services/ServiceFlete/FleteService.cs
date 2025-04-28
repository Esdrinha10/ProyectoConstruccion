using SIGESPROC.DataAccess.Repositories.RepositoryFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceFlete
{
    public class FleteService
    {
        private readonly FleteEncabezadoRepository _fleteRepository;
        private readonly FleteDetalleRepository _fleteDetalleRepository;

        // Constructor que recibe repositorios de encabezado y detalle de fletes
        public FleteService(FleteEncabezadoRepository fleteRepository, FleteDetalleRepository fleteDetalleRepository)
        {
            _fleteRepository = fleteRepository;
            _fleteDetalleRepository = fleteDetalleRepository;
        }

        #region Flete

        // Método para listar todos los fletes
        public ServiceResult ListarFletes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteRepository.List(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para buscar un flete por su ID
        public ServiceResult BuscarFlete(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteRepository.Find(id); // Llama al repositorio para buscar un flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para insertar un nuevo flete
        public  ServiceResult InsertarFlete(tbFletesEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteRepository.Insert(item); // Llama al repositorio para insertar un nuevo flete
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map); // Retorna el resultado exitoso si el código de estado es mayor o igual a 1
                }
                else
                {
                    return result.Error(map); // Retorna un error si el código de estado es menor a 1
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para actualizar un flete existente
        public ServiceResult ActualizarFlete(tbFletesEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteRepository.Update(item); // Llama al repositorio para actualizar el flete
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna el resultado exitoso si el código de estado es 1
                }
                else
                {
                    return result.Error(map); // Retorna un error si el código de estado no es 1
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para eliminar un flete por su ID
        public ServiceResult EliminarFlete(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteRepository.Delete(id); // Llama al repositorio para eliminar el flete por su ID
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna el resultado exitoso si el código de estado es 1
                }
                else
                {
                    return result.Error(map); // Retorna un error si el código de estado no es 1
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        #endregion

        #region Flete detalle

        // Método para eliminar un detalle de flete por su ID
        public ServiceResult EliminarFleteDetalle(int frecId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteDetalleRepository.Delete(frecId); // Llama al repositorio para eliminar el detalle del flete por su ID
                if (list.CodeStatus > 0)
                {
                    return result.Ok("La acción ha sido exitosa", list); // Retorna el resultado exitoso si el código de estado es mayor a 0
                }
                else
                {
                    return result.Error("No se pudo realizar la acción"); // Retorna un error si el código de estado es 0 o menor
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex); // Retorna un error con la excepción
            }
        }

        // Método para buscar un detalle de flete por su ID
        public ServiceResult BuscarFleteDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.Find(id); // Llama al repositorio para buscar el detalle del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }


        // Método para buscar un detalle de flete por su ID
        public ServiceResult BuscarFleteDetalles(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.FindDetalle(id); // Llama al repositorio para buscar el detalle del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para insertar un nuevo detalle de flete
        public ServiceResult InsertarFleteDetalle(tbFletesDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.Insert(item); // Llama al repositorio para insertar un nuevo detalle de flete
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map); // Retorna el resultado exitoso si el código de estado es mayor o igual a 1
                }
                else
                {
                    return result.Error("El código no es válido"); // Retorna un error si el código de estado es menor a 1
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        // Método para listar los detalles de un flete por su ID
        public ServiceResult ListarFleteDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.List(id); // Llama al repositorio para listar los detalles del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con la lista de detalles del flete
            }
            catch (Exception ex)
            {
                return result.Error(ex); // Retorna un error con la excepción
            }
        }

        // Método para actualizar un detalle de flete existente
        public ServiceResult ActualizarFleteDetalle(tbFletesDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.Update(item); // Llama al repositorio para actualizar el detalle del flete
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna el resultado exitoso si el código de estado es 1
                }
                else
                {
                    return result.Error(map); // Retorna un error si el código de estado no es 1
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
        #endregion



        #region InsumoPorProveedores


        public ServiceResult ListarInsumoPorProveedor()
        {
            var result = new ServiceResult();
            try
            {
                var list = _fleteDetalleRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarInsumoPorActividadEtap(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.FindInsumoPorActividadEtapa(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult BuscarEquipoPorActividadEtap(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _fleteDetalleRepository.FindEquipoPorActividadEtapa(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

    }

}