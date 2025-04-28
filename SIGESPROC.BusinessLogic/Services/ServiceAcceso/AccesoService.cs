using SIGESPROC.DataAccess.Repositories.RepositoryAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceAcceso
{
    public class AccesoService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly PantallaRepository _pantallaRepository;
        private readonly RolRepository _rolRepository;
        private readonly PantallaPorRolRepository _pantallaporrolRepository;

        public AccesoService(UsuarioRepository usuariosRepositorio, PantallaRepository pantallaRepository, RolRepository rolRepository,
               PantallaPorRolRepository pantallaporrolRepository)
        {
            _usuarioRepository = usuariosRepositorio;
            _pantallaRepository = pantallaRepository;
            _rolRepository = rolRepository;
            _pantallaporrolRepository = pantallaporrolRepository;
          
        }

        #region Usuario
        public ServiceResult EliminarUsuario(int? id, string observacion)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.Delete(id,observacion);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }

        public ServiceResult BuscarUsuario(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var usuario = _usuarioRepository.Find(id);

                return result.Ok(usuario);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }

        public ServiceResult InicioSesionUsuario(string user, string clave)
        {
            var result = new ServiceResult();

            try
            {
                var usuario = _usuarioRepository.InicioSesion(user, clave);

                return result.Ok(usuario);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }


        public ServiceResult RestablecerFlutter(string user, string clave, string nuevaclave)
        {
            var result = new ServiceResult();

            try
            {
                var usuario = _usuarioRepository.RestablecerFultter(user, clave, nuevaclave);
                if (usuario.CodeStatus >= 1)
                {
                    return result.Ok(usuario);
                }


                else
                {
                    return result.Error(usuario);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }


        }

        public ServiceResult InsertarCodigoRestablecer(int usua_Id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.InsertarCodigoVerificacion(usua_Id);

                if (request.CodeStatus == 2)    
                {
                    return result.Ok(request);
                }
                else
                {
                    return result.Error(request);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult VerificarCodigoReestablecer(int usua_Id, int codigo)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.VeirifarCodigoReestablecer(usua_Id, codigo);

                if (request.CodeStatus == 2)
                {
                    return result.Ok(request);
                }
                else
                {
                    return result.Error(request);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult RestablecerCorrero(string user, string correo)
        {
            var result = new ServiceResult();

            try
            {
                var usuario = _usuarioRepository.RestablecerCorreo(user, correo);
                if (usuario.CodeStatus >= 1)
                {
                    return result.Ok(usuario);
                }


                else
                {
                    return result.Error(usuario);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }


        }

        public ServiceResult InsertarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarUsuarios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarUsuariosMotificaciones()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.ListNotificaciones();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ReestablecerUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.Reestablecer(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _usuarioRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Pantalla
        public ServiceResult EliminarPantalla(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _pantallaRepository.Delete(id);

                return request.CodeStatus > 0 ? result.Ok(request) :
                        request.CodeStatus == 0 ? result.NotFound() : result.Error(request);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }

        public ServiceResult BuscarPantalla(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var pantalla = _pantallaRepository.Find(id);

                return result.Ok(pantalla);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }
        
        public ServiceResult InsertarPantalla(tbPantallas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _pantallaRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPantallas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallaRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPantallasPorRol()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallaRepository.ListPorRol();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarPantalla(tbPantallas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _pantallaRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) :
                                        request.CodeStatus == 0 ? result.NotFound() : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Rol
        /// <summary>
        /// Obtiene la lista de todos los roles desde la base de datos.
        /// </summary>
        /// <returns>Un mensaje de éxito con la lista de roles o un mensaje de error en caso de fallo.</returns>
        public ServiceResult ListarRoles()
        {
            var result = new ServiceResult();

            try
            {
                var list = _rolRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Busca un rol específico en la base de datos por su ID.
        /// </summary>
        /// <param name="id">ID del rol a buscar.</param>
        /// <returns>Un mensaje de éxito con el rol encontrado o un mensaje de error en caso de fallo.</returns>
        public ServiceResult BuscarRol(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _rolRepository.Find(id);

                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Inserta un nuevo rol en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbRoles que contiene la información del rol a insertar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult InsertarRol(tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _rolRepository.Insert(item);

                if (map.CodeStatus != 0)
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
        /// Actualiza un rol específico en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbRoles que contiene la información del rol a actualizar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult ActualizarRol(tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _rolRepository.Update(item);

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
        /// Elimina un rol específico.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarRol(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _rolRepository.Delete(id);

                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region PantallaPorRol
        public ServiceResult ListarPantallasPorRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallaporrolRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarPantallaPorRol(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _pantallaporrolRepository.Buscar(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        /// <summary>
        /// Inserta una nueva relación entre una pantalla y un rol en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPantallasPorRoles que contiene los datos de la relación a insertar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación.</returns>
        public ServiceResult InsertarPantallaPorRol(tbPantallasPorRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var map = _pantallaporrolRepository.Insert(item);

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


        public ServiceResult ActualizarPantallaPorRol(tbPantallasPorRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _pantallaporrolRepository.Update(item);
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
        /// Elimina la relación entre una pantalla y un rol específico en la base de datos.
        /// </summary>
        /// <param name="id">El ID de la relación a eliminar.</param>
        /// <returns>Un objeto ServiceResult que indica el resultado de la operación.</returns>
        public ServiceResult EliminarPantallaPorRol(int id)
        {
            var result = new ServiceResult();

            try
            {
                var map = _pantallaporrolRepository.Delete(id);

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