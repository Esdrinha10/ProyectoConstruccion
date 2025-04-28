using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SIGESPROC.DataAccess.Repositories.RepositoryAcceso
{
    public class RolRepository : IRepository<tbRoles>
    {
        /// <summary>
        /// Elimina un rol específico por su ID.
        /// </summary>
        /// <param name="id">El ID del rol a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", id);

                var answer = db.QueryFirst<RequestStatus>(
                    ScriptsDataBase.EliminarRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return answer;
            }
        }

        /// <summary>
        /// Busca y devuelve un rol específico por su ID.
        /// </summary>
        /// <param name="id">El ID del rol a buscar.</param>
        /// <returns>Un objeto tbRoles que representa el rol encontrado.</returns>
        public tbRoles Find(int? id)
        {
            tbRoles result = new tbRoles();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", id);

                result = db.QueryFirst<tbRoles>(
                    ScriptsDataBase.BuscarRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        // <summary>
        /// Inserta un nuevo rol en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbRoles que contiene los datos del nuevo rol.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación junto al ID creado.</returns>
        public virtual RequestStatus Insert(tbRoles item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Descripcion", item.role_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@role_FechaCreacion", DateTime.Now);

                var answer = db.QueryFirst<int>(
                    ScriptsDataBase.InsertarRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = answer > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = answer, MessageStatus = mensaje };
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los roles disponibles en la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbRoles que representa los roles encontrados.</returns>
        public virtual IEnumerable<tbRoles> List()
        {
            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbRoles>(
                    ScriptsDataBase.ListarRoles,
                    commandType: CommandType.Text
                ).ToList();

                return result;
            }
        }

        /// <summary>
        /// Actualiza un rol existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbRoles que contiene los datos actualizados del rol.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación junto al ID creado.</returns>
        public virtual RequestStatus Update(tbRoles item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", item.role_Id);
                parameter.Add("@role_Descripcion", item.role_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@role_FechaModificiacion", DateTime.Now);

                var answer = db.QueryFirst<int>(
                    ScriptsDataBase.ActualizarRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                result.CodeStatus = answer;

                return result;
            }
        }

    }
}
