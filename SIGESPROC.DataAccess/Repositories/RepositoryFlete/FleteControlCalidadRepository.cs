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
    public class FleteControlCalidadRepository : IRepository<tbFletesControlCalidad>
    {
        public RequestStatus Delete(int? flcc_Id)
        {
            string sql = ScriptsDataBase.EliminarFleteControlCalidad;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flcc_Id", flcc_Id);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public tbFletesControlCalidad Find(int? flcc_Id)
        {
            string sql = ScriptsDataBase.BuscarFleteControlCalidad;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flcc_Id", flcc_Id);

                var result = db.QuerySingleOrDefault<tbFletesControlCalidad>(sql, parametro, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(tbFletesControlCalidad item)
        {
            string sql = ScriptsDataBase.InsertarFleteControlCalidad;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flcc_DescripcionIncidencia", item.flcc_DescripcionIncidencia);
                parametro.Add("@flcc_FechaHoraIncidencia", item.flcc_FechaHoraIncidencia);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@flcc_FechaCreacion", item.flcc_FechaCreacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : result == 2 ? "El registro ya existe y está activo" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbFletesControlCalidad> FindIncidencias(int? id)
        {
            List<tbFletesControlCalidad> result = new List<tbFletesControlCalidad>();


            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@flen_Id", id);
                result = db.Query<tbFletesControlCalidad>(ScriptsDataBase.BuscarFleteControlCalidadIncidencias, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbFletesControlCalidad> List(int? id)
        {
            string sql = ScriptsDataBase.ListarFletesControlCalidades;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbFletesControlCalidad>(sql, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbFletesControlCalidad> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbFletesControlCalidad item)
        {
            string sql = ScriptsDataBase.ActualizarFleteControlCalidad;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flcc_Id", item.flcc_Id);
                parametro.Add("@flcc_DescripcionIncidencia", item.flcc_DescripcionIncidencia);
                parametro.Add("@flcc_FechaHoraIncidencia", item.flcc_FechaHoraIncidencia);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@flcc_FechaModificacion", item.flcc_FechaModificacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
