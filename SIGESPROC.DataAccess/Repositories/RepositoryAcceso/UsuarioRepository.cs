using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryAcceso
{
    public class UsuarioRepository : IRepository<tbUsuarios>
    {
        public RequestStatus Delete(int? id, string observacion)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters(); 
                parametro.Add("usua_Id", id);
                parametro.Add("observacion", observacion);

                var result = db.QueryFirst<int>(ScriptsDataBase.Eliminar_Usuario,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : result == 0 ? "Id no encontrado" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        //public tbUsuarios Find(int? id)
        //{
        //    using (var db = new SqlConnection(SIGESPROC.ConnectionString))
        //    {
        //        var parametro = new DynamicParameters();
        //        parametro.Add("usua_Id", id);

        //        var result = db.QueryFirst<tbUsuarios>(ScriptsDataBase.Buscar_Usuario,
        //            parametro,
        //             commandType: CommandType.StoredProcedure
        //            );

        //        return result;
        //    }
        //}



        public UsuarioViewModel Find(int? id)
        {
            UsuarioViewModel result = new UsuarioViewModel();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", id);
                result = db.QueryFirst<UsuarioViewModel>(ScriptsDataBase.Buscar_Usuario, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<UsuarioViewModel> InicioSesion(string usuario, string clave)
        {
            {
                List<UsuarioViewModel> result = new List<UsuarioViewModel>();

                using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                {
                    var parametro = new DynamicParameters();
                    parametro.Add("usuario", usuario);
                    parametro.Add("clave", clave);

                    result = db.Query<UsuarioViewModel>(ScriptsDataBase.InicioSesion_Usuario,parametro,commandType: CommandType.StoredProcedure).ToList();

                    return result;
                }
            }
        }


        public RequestStatus RestablecerFultter(string usuario, string clave, string nuevaclave)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("usua_Id", usuario);
                parametro.Add("clave", clave);
                parametro.Add("nuevaclave", nuevaclave);

                //var result = db.QueryFirst<tbUsuarios>(ScriptsDataBase.RestablecerFlutter,
                //    parametro,
                //     commandType: CommandType.StoredProcedure
                //    );

                var result = db.QueryFirst<int>(ScriptsDataBase.RestablecerFlutter,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : "Error";


                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }



        public RequestStatus RestablecerCorreo(string usuario, string correo)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("usua_Id", usuario);
                parametro.Add("empl_CorreoElectronico", correo);

            

                var result = db.QueryFirst<int>(ScriptsDataBase.RestablecerCorreo,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : "Error";


                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public virtual RequestStatus Insert(tbUsuarios item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("usua_Usuario", item.usua_Usuario);
                parametro.Add("usua_Clave", item.usua_Clave);
                parametro.Add("usua_EsAdministrador", item.usua_EsAdministrador);
                parametro.Add("empl_Id", item.empl_Id);
                parametro.Add("role_Id", item.role_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("usua_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Insertar_Usuario,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public virtual IEnumerable<tbUsuarios> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbUsuarios>(ScriptsDataBase.Listar_Usuarios,
                     commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public IEnumerable<tbUsuarios> ListNotificaciones()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbUsuarios>(ScriptsDataBase.Listar_Usuarios,
                     commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public RequestStatus Reestablecer(tbUsuarios item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("usua_Id", item.usua_Id);
                parametro.Add("clave", item.usua_Clave);

                var result = db.QueryFirst<int>(ScriptsDataBase.Reestablecer_Usuario,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : result == 0 ? "Id no encontrado" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public virtual RequestStatus Update(tbUsuarios item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("usua_Id", item.usua_Id);
                parametro.Add("usua_Usuario", item.usua_Usuario);
                parametro.Add("usua_EsAdministrador", item.usua_EsAdministrador);
                parametro.Add("empl_Id", item.empl_Id);
                parametro.Add("role_Id", item.role_Id);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("usua_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Actualizar_Usuario,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : result == 0 ? "Id no encontrado" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        tbUsuarios IRepository<tbUsuarios>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus InsertarCodigoVerificacion(int usua_Id)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", usua_Id);

                parameter.Add("@UltimoCodigo", dbType: DbType.Int32, size: 100, direction: ParameterDirection.Output);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarCodigoVerificacion, parameter, commandType: CommandType.StoredProcedure);
                int ultimoID = parameter.Get<int>("UltimoCodigo");

                var saber = ansewer.Select(ans =>
                {
                    return ans;

                }).ToList();

                result.CodeStatus = saber.Count;
                result.Message = ultimoID.ToString();

                return result;
            }
        }

        public RequestStatus VeirifarCodigoReestablecer(int usua_Id, int codigo)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", usua_Id);
                parameter.Add("@codigo", codigo);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.VerificarCodigoReestablecer, parameter, commandType: CommandType.StoredProcedure);

                var saber = ansewer.Select(ans =>
                {
                    return ans;

                }).ToList();

                result.CodeStatus = saber.Count;

                return result;
            }
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
