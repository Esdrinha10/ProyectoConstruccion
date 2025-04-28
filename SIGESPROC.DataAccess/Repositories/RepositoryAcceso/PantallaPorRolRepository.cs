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
    public class PantallaPorRolRepository : IRepository<tbPantallasPorRoles>
    {
        /// <summary>
        /// Elimina una relación específica entre una pantalla y un rol en la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID de la relación a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", id);

                var answer = db.QueryFirst<int>(
                    ScriptsDataBase.EliminarPantallaPorRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbPantallasPorRoles> Buscar(int? id)
        {
            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", id);
                result = db.Query<tbPantallasPorRoles>(ScriptsDataBase.BuscarPantallaPorRol, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public tbPantallasPorRoles Find(int? id)
        {
            tbPantallasPorRoles result = new tbPantallasPorRoles();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", id);
                result = db.QueryFirst(ScriptsDataBase.BuscarPantallaPorRol, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Inserta una nueva relación entre una pantalla y un rol en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPantallasPorRoles que contiene los datos de la relación a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbPantallasPorRoles item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", item.role_Id);
                parameter.Add("@pant_Id", item.pant_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@paro_FechaCreacion", DateTime.Now);

                var answer = db.QueryFirst<int>(
                    ScriptsDataBase.InsertarPantallaPorRol,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                result.CodeStatus = answer;
                return result;
            }
        }

        public virtual IEnumerable<tbPantallasPorRoles> List()
        {
            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbPantallasPorRoles>(ScriptsDataBase.ListarPantallasPorRoles, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbPantallasPorRoles item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@role_Id", item.role_Id);
                parameter.Add("@paro_Id", item.paro_Id);
                parameter.Add("@pant_Id", item.pant_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@paro_FechaModificiacion", item.paro_FechaModificiacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarPantallaPorRol, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
