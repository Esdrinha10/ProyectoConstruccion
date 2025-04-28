using Microsoft.AspNetCore.Http;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.GeneralService
{
    public class GeneralService
    {
        private readonly NivelRepository _nivelRepository;
        private readonly PaisRepository _paisRepository;
        private readonly TasaCambioRepository _tasaCambioRepository;
        private readonly TipoProyectoRepository _tipoProyectoRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly EstadoRepository _estadoRepository;
        private readonly MonedaRepository _monedaRepository;
        private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly UnidadMedidaRepository _unidadMedidaRepository;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly CiudadRepository _ciudadRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly ImpuestoRepository _impuestoRepository;
        public GeneralService(
               NivelRepository nivelRepository,
               PaisRepository paisRepository,
               TasaCambioRepository tasaCambioRepository,
               TipoProyectoRepository tipoProyectoRepository,
               EmpleadoRepository empleadoRepository,
               EstadoRepository estadoRepository,
               MonedaRepository monedaRepository,
               EstadoCivilRepository estadoCivilRepository,
               CargoRepository cargoRepository,
               UnidadMedidaRepository unidadMedidaRepository,
               CategoriaRepository categoriaRepository,
               CiudadRepository ciudadRepository,
               ClienteRepository clienteRepository,
               ImpuestoRepository impuestoRepository
             )
          {
           _nivelRepository = nivelRepository;
            _paisRepository = paisRepository;
            _tasaCambioRepository = tasaCambioRepository;
            _tipoProyectoRepository = tipoProyectoRepository;
            _clienteRepository = clienteRepository;
            _nivelRepository = nivelRepository;
            _empleadoRepository = empleadoRepository;
            _estadoRepository = estadoRepository;
            _monedaRepository = monedaRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _cargoRepository = cargoRepository;
            _unidadMedidaRepository = unidadMedidaRepository;
            _ciudadRepository = ciudadRepository;
            _categoriaRepository = categoriaRepository;
            _impuestoRepository = impuestoRepository;
        }
        #region Categorias
        public ServiceResult ListarCategorias()
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarCategoria(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaRepository.Insert(item);
                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ActualizarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaRepository.Update(item);
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
        public ServiceResult EliminarCategoria(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var request = _categoriaRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Niveles
        public ServiceResult ListarNiveles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _nivelRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarNivel(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _nivelRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarNivel(tbNiveles item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _nivelRepository.Insert(item);
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

        public ServiceResult ActualizarNivel(tbNiveles item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _nivelRepository.Update(item);
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

        public ServiceResult EliminarNivel(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var request = _nivelRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Paises
        /// <summary>
        /// Lista todos los países.
        /// </summary>
        /// <returns>Un objeto ServiceResult que contiene la lista de países</returns>
        public ServiceResult ListarPaises()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paisRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una lista de países para un dropdown.
        /// </summary>
        /// <returns>Un objeto ServiceResult que contiene la lista de países</returns>
        public ServiceResult DropDownPaises()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paisRepository.DropDownPaises();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un país por su ID.
        /// </summary>
        /// <param name="id">El ID del país a buscar</param>
        /// <returns>Un objeto ServiceResult que contiene el país encontrado</returns>
        public ServiceResult BuscarPaises(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _paisRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo país.
        /// </summary>
        /// <param name="item">El objeto tbPaises a insertar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult InsertarPaises(tbPaises item)
        {
            var result = new ServiceResult();
            try
            {
                var request = _paisRepository.Insert(item);

                // Retorna OK si la inserción fue exitosa, o conflicto si ocurrió un error
                return request.CodeStatus == 1 ? result.Ok(request) : result.Conflict(request.MessageStatus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un país existente.
        /// </summary>
        /// <param name="item">El objeto tbPaises con los datos actualizados</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult ActualizarPaises(tbPaises item)
        {
            var result = new ServiceResult();
            try
            {
                var request = _paisRepository.Update(item);
                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un país por su ID.
        /// </summary>
        /// <param name="id">El ID del país a eliminar</param>
        /// <returns>Un objeto ServiceResult que contiene el resultado de la operación</returns>
        public ServiceResult EliminarPaises(int? id)
        {
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Delete del repositorio para eliminar el país y obtenemos el resultado
                var request = _paisRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Empleados
        /// <summary>
        /// Obtiene una lista de todos los empleados.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de empleados o un mensaje de error en caso de fallo.</returns>
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

        public ServiceResult Lisst()
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.Lisst();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Busca un empleado específico por su ID.
        /// </summary>
        /// <param name="id">ID del empleado a buscar.</param>
        /// <returns>Un mensaje de éxito con el empleado encontrado o un mensaje de error en caso de fallo.</returns>
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
        /// <summary>
        /// Obtiene la imagen de un empleado específico por su ID.
        /// </summary>
        /// <param name="empl_Id">ID del empleado a buscar.</param>
        /// <returns>Un mensaje de éxito con el empleado encontrado o un mensaje de error en caso de fallo.</returns>
        public async Task<ServiceResult> ObtenerImagen(int empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var imageResult = await _empleadoRepository.ObtenerImagen(empl_Id);
                if (imageResult != null)
                {
                    return result.Ok(imageResult);
                }
                else
                {
                    return result.Error("Imagen no encontrada.");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Busca un empleado específico por su DNI.
        /// </summary>
        /// <param name="DNI">DNI del empleado a buscar.</param>
        /// <returns>Un mensaje de éxito con el empleado encontrado o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarEmpleadoPorDNI(string DNI)

        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.FindPorEmpleado(DNI);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Inserta un nuevo empleado y le asigna sus deducciones en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos del empleado a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
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
        /// <summary>
        /// Actualiza la imagen del empleado.
        /// </summary>
        /// <param name="imagen">La imagen.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public async Task<ServiceResult> ActualizarImagenDelEmpleado(IFormFile imagen)
        {
            var result = new ServiceResult();
            try
            {
                var map = await _empleadoRepository.ActualizarImagen(imagen);
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
        /// <summary>
        /// Quita la imagen del empleado.
        /// </summary>
        /// <param name="empl_Id">El id del empleado.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult QuitarImagenDelEmpleado(int empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.QuitarImagen(empl_Id);
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
        /// <summary>
        /// Actualiza los datos generales de un empleado existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos generales actualizados del empleado.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
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
        /// <summary>
        /// Desactiva un empleado existente en la base de datos.
        /// </summary>
        /// <param name="id">El id del empleado a desactivar.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult DesactivarEmpleado(tbEmpleados item)

        {
            var result = new ServiceResult();
            try
            {
               var map = _empleadoRepository.Desactivar(item);
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
        /// <summary>
        /// Activa un empleado existente en la base de datos.
        /// </summary>
        /// <param name="id">El id del empleado a activar.</param>
        /// <returns>Un mensaje de éxito si la actualización fue exitosa, o un mensaje de error en caso contrario.</returns>
        public ServiceResult ActivarEmpleado(tbEmpleados item)

        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadoRepository.Activar(item);
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
        /// <summary>
        /// Obtiene una lista de todos los empleados.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de empleados o un mensaje de error en caso de fallo.</returns>
        public ServiceResult HistorialDePago(int empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.Historial(empl_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Unidades de Medidas
        public ServiceResult ListarUnidadesMedidas()
        {
          var result = new ServiceResult();
           try
         {
          var list = _unidadMedidaRepository.List();
                 return result.Ok(list);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarInsumosPorMedidas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _unidadMedidaRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarUnidadMedida(int id)
              {
            var result = new ServiceResult();
            try
            {
              var map = _unidadMedidaRepository.Find(id);
              return result.Ok(map);
               }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

              
               public ServiceResult InsertarUnidadMedida(tbUnidadesMedida item)
            {
            var result = new ServiceResult();
            try
            {
             var map = _unidadMedidaRepository.Insert(item);
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
      
      public ServiceResult ActualizarUnidadMedida(tbUnidadesMedida item)
         {
            var result = new ServiceResult();
            try
            {
var map = _unidadMedidaRepository.Update(item);
       
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
        // public ServiceResult EliminarUnidadMedida(int id)
        //{
        //     var result = new ServiceResult();
        //     try
        //     {
        //         var map = _unidadMedidaRepository.Delete(id);
        //          if (map.CodeStatus == 1)

        //         {
        //             return result.Ok(map);
        //         }
        //         else
        //         {
        //             return result.Error(map);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return result.Error(ex.Message);
        //     }
        // }
        public ServiceResult EliminarUnidadMedida(int id)
        {
            // Inicializamos el objeto ServiceResult que contendrá el resultado de la operación
            var result = new ServiceResult();

            try
            {
                // Llamamos al método Delete del repositorio para eliminar la unidad de medida y obtenemos el resultado
                var request = _unidadMedidaRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Estados
        public ServiceResult ListarEstados()

        {
            var result = new ServiceResult();
            try
            { var list = _estadoRepository.List();
            return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult EstadoPorPais(int? id)

        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoRepository.EstadoPorPais(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult DropDownEstados()

        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoRepository.DropDown();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarEstado(int id)  
               {
            var result = new ServiceResult();
            try
            {
              
              var map = _estadoRepository.Find(id);
                      return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
              
      public ServiceResult InsertarEstado(tbEstados item)
               {
            var result = new ServiceResult();
            try
            {
              var map = _estadoRepository.Insert(item);
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
              public ServiceResult ActualizarEstado(tbEstados item)
               {
            var result = new ServiceResult();
            try
            {
               var map = _estadoRepository.Update(item);
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
              public ServiceResult EliminarEstado(int id)
                {
            var result = new ServiceResult();
            try
            {
               var map = _estadoRepository.Delete(id);
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
      
        #region Ciudades
        public ServiceResult ListarCiudades()   //CiudadPorEstado
        {
          var result = new ServiceResult();
           try
         {
           var list = _ciudadRepository.List(); 

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }


         public ServiceResult CiudadPorEstado(int? id)   
        {
            var result = new ServiceResult();
            try
            {
                var list = _ciudadRepository.CiudadPorEstado(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarCiudades(int id)
        {
            var result = new ServiceResult();
            try
            {
              var map = _ciudadRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
      
        public ServiceResult InsertarCiudades(tbCiudades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _ciudadRepository.Insert(item);

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
            public ServiceResult ActualizarCiudades(tbCiudades item)

        {
            var result = new ServiceResult();
            try
            {
                var map = _ciudadRepository.Update(item);

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
       public ServiceResult EliminarCiudades(int id)

        {
            var result = new ServiceResult();

            try
            {
                var request = _ciudadRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
      #endregion
        
        #region EstadosCiviles
        public ServiceResult ListarEstadosCiviles() //objeto de tipo service result que devuelve el listado de la tabla
           {
            var result = new ServiceResult();//variable de tipo service result que devolveremos despues
            try
            {
                var list = _estadoCivilRepository.List();//si no hay errores entra al listar del repositorio y setea el resultado en una variable
          
             return result.Ok(list);//retorna el codigo 200 juto con la variable de tipo service result y el resultado del servicio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//si hubo errores devuelve la variable tipo service result y un mensaje de error
            }

        }
        public ServiceResult DropDownEstadoCiviles()//objeto publico de tipo serviceResult que devuelve los datos de la tabla, para ser utilizado en un viewmodel
        {
            var result = new ServiceResult(); //variable de service result que devolveremos mas tarde
            try//excepcion de errores
            {
                //si no hubo ningun error entra al repsitorio y setea el resultado en una variable
                var list = _estadoCivilRepository.DropDownEstadoCivil();

                //devuelve la variable de tipo service result junto con la variable que almacena el listado resultado del repositorio
                return result.Ok(list);
            }
            catch (Exception ex) 
            {
                //si ocurrio un error se envia la variable de tipo service result junto con un mensaje de error
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarEstadoCivil(int id)//objeto de tipo serviceresult que devuelve los datos del registro de un campo buscado por id
        {
            var result = new ServiceResult();//variable de tipo serviceResult que devolveremos mas tarde 
            try//manejo de errores try cat
            {
                var map = _estadoCivilRepository.Find(id);//si no hubo ningun error envia el id al repositorio y setea el resultado en una variable
                return result.Ok(map);//retorna el resultado junto con la variable de tipo service result
            }
            catch (Exception ex)//setea el error encontrado en una variable
            {
                return result.Error(ex.Message);//si ocurrio un error se retorna la variable de service result y el mensaje de error
            }
        }  
              
       public ServiceResult InsertarEstadoCivil(tbEstadosCiviles item)//objeto publico de tipo service result que pide el entitie de la tabla como parametro
               {
            var result = new ServiceResult();//variable de tipo service result que de se devolvera luego
            try
            { 
                  var map = _estadoCivilRepository.Insert(item);//si no hay ningun error, se envia el entitie como paramentro al repositorio y se setea el resultado en una variable
                  if (map.CodeStatus == 1)//verificamos que el codigo de estatus sea 1 
                {
                    return result.Ok(map);//si la condicion se cumple se envia el resultado junto con la variable de service result y el codigo 200
                }
                else
                {   //si no se cumple la condicion enviamos el resultado junto con la variable de tipo service result y el codigo de error
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//si ocurrio un error se devuelve la variable de tipo service result junto con el mensaje de error 
            }
        }
          public ServiceResult ActualizarEstadoCivil(tbEstadosCiviles item)//objeto publico de tipo  service result que pide el entitie de la tabla como parametro 
        {
            var result = new ServiceResult();//variable de service result que sera la que retornaremos
            try//manejo de errores try-catch
            {
               var map = _estadoCivilRepository.Update(item);//envio del entitie al repositorio y setea el valor en una variable
                        if (map.CodeStatus == 1)//varifica que el codestatus sea 1
                {
                    return result.Ok(map);//si la condicion se cumple, se retorna la variavble de tipo serviceresult junto con el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//si no se cumple la condicion, se devuelve la variable service result junto con el resultado pero con formado de error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//si ocurrio algun error, retorna la variable de tipo serice result junto con un mensaje de error
            }
        }
       public ServiceResult EliminarEstadoCivil(int id) //objeto de tipo publico que pide como parametro el id de un registro de la tabla para eliminarle
               {
            var result = new ServiceResult();//varaible de retorno tipo service result
            try//manejo de errores try catch
            {
              var map = _estadoCivilRepository.Delete(id); //variable que almacena el resultado que retorna el eliminar del repositorio

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); //si hubo un error, se retorna la variable de tipo service result junto con el mensaje de error
            }
        }
        #endregion

        #region TasasCambios
        //Servicio de listar tasa de cambio
        public ServiceResult ListarTasasCambios()
            {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _tasaCambioRepository.List();//variable que almacena el resultado que retorna el listado del repositorio
                return result.Ok(list);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }

        }
        //Servicio de buscar conversiones de tasa de cambio
        public ServiceResult ObteneroConversionTasasCambio(int id)
        {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _tasaCambioRepository.ObtenerConversionesTasasCambio(id);//variable que almacena el resultado que retorna el obtener converciones del repositorio
                return result.Ok(list);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        //Servicio de buscar tasa de cambio
        public ServiceResult BuscarTasasCambios(int id)
        {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _tasaCambioRepository.Find(id);//variable que almacena el resultado que retorna el buscar del repositorio
                return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        //Servicio de insertar tasa de cambio
       public ServiceResult InsertarTasasCambios(tbTasasCambio item)
      {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
              var map = _tasaCambioRepository.Insert(item);//variable que almacena el resultado recivido del repositorio que solicita el modelo de entitie
                if (map.CodeStatus >= 1)
        {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        //Servicio de Actualizar tasa de cambio
       public ServiceResult ActualizarTasasCambios(tbTasasCambio item)
            {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
           var map = _tasaCambioRepository.Update(item);//variable que almacena el resultado recivido del repositorio que solicita el modelo de entitie
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
      
        //Servicio de eliminar tasa de cambio
      public ServiceResult EliminarTasasCambios(int id)
          {
            var result = new ServiceResult(); //variable de tipo service result que retornaremos mas tarde
            try
            {
               var map = _tasaCambioRepository.Delete(id);// Llamamos al método Delete del repositorio para eliminar la maquinaria y obtenemos el resultado
               // Verificamos el estado de la respuesta
               // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
               // De lo contrario, retornamos un resultado de error
               return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        #endregion

        #region Tipo Proyecto
        /// <summary>
        /// Elimina un tipo de proyecto específico.
        /// </summary>
        /// <param name="id">ID del tipo a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarTipoProyecto(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _tipoProyectoRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca un tipo de proyecto específico.
        /// </summary>
        /// <param name="id">ID del tipo a buscar.</param>
        /// <returns>La tipo encontrada o un mensaje de error.</returns>
        public ServiceResult BuscarTipoProyecto(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var tipoporetapa = _tipoProyectoRepository.Find(id);

                return result.Ok(tipoporetapa);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevp tipo de proyecto.
        /// </summary>
        /// <param name="item">Entidad de tipo de proyecto.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult InsertarTipoProyecto(tbTiposProyecto item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _tipoProyectoRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Conflict();
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Lista todas las tipos de proyecto.
        /// </summary>
        /// <param name="id">ID del tipo de proyecto.</param>
        /// <returns>Una lista de tipos de proyecto.</returns>
        public ServiceResult ListarTiposProyecto()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoProyectoRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza un tipo de proyecto existente.
        /// </summary>
        /// <param name="item">Entidad de tipo de proyecto.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarTipoProyecto(tbTiposProyecto item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _tipoProyectoRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Monedas
        /// <summary>
        /// lista todas las monedas.
        /// </summary>
        /// <returns>Listado de Moneda.</returns>
        public ServiceResult ListarMonedas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _monedaRepository.List();
                      return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene un valor en la tasa de cambio con la moneda.
        /// </summary>
        /// <param name="mone_Id">ID de la moneda.</param>
        /// <param name="taca_Id">ID de la tasa de cambio.</param>
        /// <returns>Valor de la moneda con la tasa de cambio</returns>
        public ServiceResult ObtenerValorMoneda(int mone_Id, int taca_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _monedaRepository.ObtenerValorMoneda(mone_Id, taca_Id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Busca una Moneda por medio del ID.
        /// </summary>
        /// <param name="id">ID de la Moneda.</param>
        /// <returns>La moneds encontrada o un mensaje de error.</returns>
        public ServiceResult BuscarMoneda(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _monedaRepository.Find(id);
                return result.Ok(map);       
                }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Inserta una nueva monedda.
        /// </summary>
        /// <param name="item">Entidad de moneda.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult InsertarMoneda(tbMonedas item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _monedaRepository.Insert(item);   
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
        /// <summary>
        /// Actualiza una moneda existente.
        /// </summary>
        /// <param name="item">Entidad de moneda.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarMoneda(tbMonedas item)
            {
            var result = new ServiceResult();
            try
            {    
          
          var map = _monedaRepository.Update(item);
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

        public ServiceResult EliminarMoneda(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _monedaRepository.Delete(id);

                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Cliente
        public ServiceResult ListarClientes()
           {
            var result = new ServiceResult();
            try
            {
               var list = _clienteRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
              public ServiceResult BuscarClientes(int id)
             {
            var result = new ServiceResult();
            try
            {
               var map = _clienteRepository.Find(id);
                    return result.Ok(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
              
              
               public ServiceResult InsertarClientes(tbClientes item)  
          {
            var result = new ServiceResult();
            try
            {
             var map = _clienteRepository.Insert(item);
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
      public ServiceResult ActualizarClientes(tbClientes item)
        {
            var result = new ServiceResult();
            try
            {
               var map = _clienteRepository.Update(item);
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
           public ServiceResult EliminarClientes(int id)
              {
            var result = new ServiceResult();
            try
            {
                var request = _clienteRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
      
      
       
              #endregion
             
        #region Cargos
        public ServiceResult ListarCargos()
          {
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.List();

              return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
               public ServiceResult BuscarCargo(int id) {
            var result = new ServiceResult();
            try
            {
            var map = _cargoRepository.Find(id);
               return result.Ok(map);
  }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
       public ServiceResult InsertarCargo(tbCargos item)
       {
            var result = new ServiceResult();
            try
            {
              var map = _cargoRepository.Insert(item);
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
           public ServiceResult ActualizarCargo(tbCargos item)
                {
            var result = new ServiceResult();
            try
            {
               var map = _cargoRepository.Update(item);
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
      public ServiceResult EliminarCargo(int id)
       {
            var result = new ServiceResult();
            try
            {
                var request = _cargoRepository.Delete(id);
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Impuestos
        public ServiceResult ListarImpuestos()
        {
            var result = new ServiceResult();
            try
            {
                // Obtenemos la lista de impuestos desde el repositorio
                var list = _impuestoRepository.List();

                // Retornamos el resultado exitoso con la lista de impuestos
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarImpuesto(tbImpuestos item)
        {
            var result = new ServiceResult();
            try
            {
                // Actualizamos el impuesto en el repositorio
                var map = _impuestoRepository.Update(item);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es 1, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
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
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarImpuesto(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Buscamos el impuesto por su ID en el repositorio
                var map = _impuestoRepository.Find(id);

                // Retornamos el resultado exitoso con el impuesto encontrado
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        #endregion

    }
}
