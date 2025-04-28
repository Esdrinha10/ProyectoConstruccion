using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class CostoPorActividadRepository : IRepository<tbCostoPorActividad>
    {
    

        public RequestStatus Delete(int? id)
        {
            /// <summary>
            /// Elimina un costo por actividad  específico por su Id.
            /// </summary>
            /// <param name="id">El Id costo por actividad a eliminar.</param>
            /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@copc_Id", id);
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarCostoActividad,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        /// <summary>
        /// Busca y devuelve costo por actividad  específica por su Id.
        /// </summary>
        /// <param name="id">El Id dl costo por actividad  a buscar.</param>
        /// <returns>Un objeto tbCostoporActividad que representa el costo por actividad  encontrado.</returns>

        public tbCostoPorActividad Find(int? copc_Id)
        {
            string sql = ScriptsDataBase.BuscarCostoActividad;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@copc_Id", copc_Id);

                return db.QuerySingleOrDefault<tbCostoPorActividad>(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Inserta un nuevo  costo por actividad  en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbcostoporactividad  que contiene los datos de la nuevo  costo por actividad .</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>

        public virtual RequestStatus Insert(tbCostoPorActividad item)
        {

            string sql = ScriptsDataBase.InsertarCostoActividad;
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@unme_Id", item.unme_Id);
                parametro.Add("@acti_Id", item.acti_Id);
                parametro.Add("@copc_Valor", item.copc_Valor);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@copc_FechaCreacion", item.copc_FechaCreacion);
                var answer = db.QueryFirst<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de  costos por actividades  
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos  tbcostoporactividad  que representa el   costos por actividades encontrados.</returns>
        public IEnumerable<tbCostoPorActividad> List()
        {
             string sql = ScriptsDataBase.ListarCostoActividad;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbCostoPorActividad>(sql, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        /// <summary>
        /// Actualiza los datos de un costo por actividad
        /// </summary>
        /// <param name="item">El objeto tbcostosporactividades que contiene los datos actualizados del  costo por actividad</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbCostoPorActividad item)
        {
            string sql = ScriptsDataBase.ActualizarCostoActividad;

            RequestStatus result = new RequestStatus();


            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@copc_Id", item.copc_Id);
                parametro.Add("@unme_Id", item.unme_Id);
                parametro.Add("@acti_Id", item.acti_Id);
                parametro.Add("@copc_Valor", item.copc_Valor);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@copc_FechaModificacion", item.copc_FechaModificacion);

                var answer = db.QueryFirst<int>(sql, parametro, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;

                return result;
            }
        }
    }
}
