using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using SIGESPROC.DataAccess.Context;

namespace SIGESPROC.DataAccess.Repositories.RepositoryFlete
{
    public class IncidenciaPorFleteRepository : IRepository<tbIncidenciasPorFletes>
    {
        public RequestStatus Delete(int? infl_Id)
        {
            string sql = ScriptsDataBase.EliminarIncidenciaPorFlete;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@infl_Id", infl_Id);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public tbIncidenciasPorFletes Find(int? infl_Id)
        {
            string sql = ScriptsDataBase.BuscarIncidenciaPorFlete;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@infl_Id", infl_Id);

                var result = db.QuerySingleOrDefault<tbIncidenciasPorFletes>(sql, parametro, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(tbIncidenciasPorFletes item)
        {
            string sql = ScriptsDataBase.InsertarIncidenciaPorFlete;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@inci_Id", item.inci_Id);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@infl_FechaCreacion", item.infl_FechaCreacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : result == 2 ? "El registro ya existe y está activo" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbIncidenciasPorFletes> List()
        {
            string sql = ScriptsDataBase.ListarIncidenciasPorFletes;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbIncidenciasPorFletes>(sql, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbIncidenciasPorFletes item)
        {
            string sql = ScriptsDataBase.ActualizarIncidenciaPorFlete;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@infl_Id", item.infl_Id);
                parametro.Add("@inci_Id", item.inci_Id);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@infl_FechaModificacion", item.infl_FechaModificacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
