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
    public class ViaticoEncabezadoRepository : IRepository<tbViaticosEncabezados>
    {
        public RequestStatus Delete(int? vien_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vien_Id", vien_Id);

                var result = db.ExecuteScalar<int>(ScriptsDataBase.ViaticosEncEliminar, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
        public RequestStatus FnalizarEnc(int? vien_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vien_Id", vien_Id);

                var result = db.ExecuteScalar<int>(ScriptsDataBase.ViaticosEncFinalizar, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }


        public tbViaticosEncabezados Find(int? vien_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vien_Id", vien_Id);

                return db.QuerySingleOrDefault<tbViaticosEncabezados>(ScriptsDataBase.ViaticosEncBuscar, parametro, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual RequestStatus Insert(tbViaticosEncabezados item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                //parametro.Add("@vien_SaberProyeto", item.vien_SaberProyeto);
                parametro.Add("@vien_MontoEstimado", item.vien_MontoEstimado);
                parametro.Add("@vien_FechaEmicion", item.vien_FechaEmicion);
                parametro.Add("@empl_Id", item.empl_Id);
                parametro.Add("@Proy_Id", item.Proy_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@vien_FechaCreacion", item.vien_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ViaticosEncInsertar, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                result.MessageStatus = (answer == 1) ? "Exito" : "Error";
                return result;
            }
        }

        public IEnumerable<tbViaticosEncabezados> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbViaticosEncabezados>(ScriptsDataBase.ViaticosEncListar, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public virtual IEnumerable<tbViaticosEncabezados> ListR(int? usua_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@usua_Id", usua_Id, DbType.Int32);

                return db.Query<tbViaticosEncabezados>(ScriptsDataBase.ViaticosEncListar, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public RequestStatus Update(tbViaticosEncabezados item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vien_Id", item.vien_Id);
                //parametro.Add("@vien_SaberProyeto", item.vien_SaberProyeto);
                parametro.Add("@vien_MontoEstimado", item.vien_MontoEstimado);
                //parametro.Add("@vien_TotalGastado", item.vien_TotalGastado);
                //parametro.Add("@vien_FechaEmicion", item.vien_FechaEmicion);
                parametro.Add("@empl_Id", item.empl_Id);
                parametro.Add("@Proy_Id", item.Proy_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                //parametro.Add("@vien_TotalReconocido", item.vien_TotalReconocido);
                parametro.Add("@vien_FechaModificacion", item.vien_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ViaticosEncActualizar, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                result.MessageStatus = (answer == 1) ? "Exito" : "Error";
                return result;
            }
        }
    }
}
