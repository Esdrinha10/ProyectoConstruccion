using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ProcesosVentaService
{
    public class ProcesoVentaService
    {
        // Inyección de dependencias de los repositorios para manejar procesos de venta e imágenes.
        private readonly ProcesoVentaRepository _procesoVentaRepository;
        private readonly ProcesoVentaImagenesRepository _procesoVentaImagenesRepository;

        // Constructor que inicializa los repositorios.
        public ProcesoVentaService(
               ProcesoVentaRepository procesoVentaRepository,
               ProcesoVentaImagenesRepository procesoVentaImagenesRepository
             )
        {
            _procesoVentaRepository = procesoVentaRepository;
            _procesoVentaImagenesRepository = procesoVentaImagenesRepository;
        }

        // Método para listar todos los procesos de venta.
        public ServiceResult ListarProcesosVenta()
        {
            var result = new ServiceResult();
            try
            {
                var list = _procesoVentaRepository.List(); // Llama al repositorio para obtener la lista de procesos de venta.
                return result.Ok(list); // Retorna la lista en caso de éxito.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para buscar un proceso de venta específico.
        public ServiceResult BuscarProcesoVenta(int id, int tipo, int id2)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.buscar(id, tipo, id2); // Busca un proceso de venta por sus identificadores.
                return result.Ok(map); // Retorna el proceso de venta encontrado.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }
        public ServiceResult BuscarClienteVendido(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.buscarcliente(id); // Busca un proceso de venta por sus identificadores.
                return result.Ok(map); // Retorna el proceso de venta encontrado.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para insertar un nuevo proceso de venta.
        public virtual ServiceResult InsertarProcesoVenta(tbProcesosVentas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.Insert(item); // Inserta el nuevo proceso de venta.
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map); // Retorna éxito si la inserción fue exitosa.
                }
                else
                {
                    return result.Error(map); // Retorna un error si la inserción falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para actualizar un proceso de venta existente.
        public virtual ServiceResult ActualizarProcesoVenta(tbProcesosVentas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.Update(item); // Actualiza el proceso de venta.
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna éxito si la actualización fue exitosa.
                }
                else
                {
                    return result.Error(map); // Retorna un error si la actualización falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para eliminar un proceso de venta.
        public ServiceResult EliminarProcesoVenta(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.Delete(id); // Elimina el proceso de venta por su ID.
                if (map.Success)
                {
                    return result.Ok(map); // Retorna éxito si la eliminación fue exitosa.
                }
                else
                {
                    return result.Error(map.Message); // Retorna un error si la eliminación falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para marcar un proceso de venta como vendido.
        public ServiceResult VendidoProcesoVenta(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.Vendido(id); // Marca el proceso de venta como vendido.
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna éxito si la operación fue exitosa.
                }
                else
                {
                    return result.Error(map); // Retorna un error si la operación falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para actualizar un proceso de venta como vendido.
        public ServiceResult ActualizarvenderProcesoVenta(tbProcesosVentas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaRepository.venderUpdate(item); // Actualiza el estado del proceso de venta como vendido.
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna éxito si la operación fue exitosa.
                }
                else
                {
                    return result.Error(map); // Retorna un error si la operación falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        #region Imagenes de proceso de venta

        // Método para buscar la documentación de un proceso de venta.
        public ServiceResult BuscarDocumentacionProcesoVenta(int tipo, int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaImagenesRepository.Bucardocumentos(tipo, id); // Busca la documentación asociada a un proceso de venta.
                return result.Ok(map); // Retorna la documentación en caso de éxito.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para listar las imágenes asociadas a un proceso de venta.
        public ServiceResult ListarImagenProcesosVenta(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaImagenesRepository.Buscar(id); // Busca las imágenes asociadas a un proceso de venta.
                return result.Ok(map); // Retorna las imágenes en caso de éxito.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para insertar imágenes asociadas a un proceso de venta.
        public ServiceResult InsertarImagenesProcesoVenta(List<tbImagenesPorProcesosVentas> items)
        {
            var result = new ServiceResult();
            try
            {
                foreach (var item in items)
                {
                    var map = _procesoVentaImagenesRepository.Insert(item); // Inserta cada imagen en la base de datos.
                    if (map.CodeStatus == 0)
                    {
                        return result.Error(map); // Retorna un error si alguna inserción falla.
                    }
                }
                return result.Ok(); // Retorna éxito si todas las inserciones fueron exitosas.
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para actualizar una imagen asociada a un proceso de venta.
        public ServiceResult ActualizarImagenProcesoVenta(tbImagenesPorProcesosVentas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaImagenesRepository.Update(item); // Actualiza la imagen en la base de datos.
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map); // Retorna éxito si la actualización fue exitosa.
                }
                else
                {
                    return result.Error(map); // Retorna un error si la actualización falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        // Método para eliminar una imagen asociada a un proceso de venta.
        public ServiceResult EliminarImagenProcesoVenta(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _procesoVentaImagenesRepository.Delete(id); // Elimina la imagen por su ID.
                if (map.Success)
                {
                    return result.Ok(map); // Retorna éxito si la eliminación fue exitosa.
                }
                else
                {
                    return result.Error(map.Message); // Retorna un error si la eliminación falló.
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error en caso de excepción.
            }
        }

        #endregion
    }
}
