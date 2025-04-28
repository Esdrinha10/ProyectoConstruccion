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
    public class ViaticoDetalleRepository : IRepository<tbViaticosDetalles>
    {
        public RequestStatus Delete(int? vide_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vide_Id", vide_Id);

                var result = db.ExecuteScalar<int>(ScriptsDataBase.ViaticosDetEliminar, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public tbViaticosDetalles Find(int? vide_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vide_Id", vide_Id);

                return db.QuerySingleOrDefault<tbViaticosDetalles>(ScriptsDataBase.ViaticosDetBuscar, parametro, commandType: CommandType.StoredProcedure);
            }
        }

        public RequestStatus Insert(tbViaticosDetalles item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vide_Descripcion", item.vide_Descripcion);
                parametro.Add("@vide_ImagenFactura", item.vide_ImagenFactura);
                parametro.Add("@vide_MontoGastado", item.vide_MontoGastado);
                parametro.Add("@vien_Id", item.vien_Id);
                parametro.Add("@cavi_Id", item.cavi_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@vide_FechaCreacion", item.vide_FechaCreacion);
                parametro.Add("@vide_MontoReconocido", item.vide_MontoReconocido);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ViaticosDetInsertar, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                result.MessageStatus = (answer == 1) ? "Exito" : "Error";
                return result;
            }
        }

        public IEnumerable<tbViaticosDetalles> List()
        {

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbViaticosDetalles>(ScriptsDataBase.ViaticosDetListar, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public RequestStatus Update(tbViaticosDetalles item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vide_Id", item.vide_Id);
                parametro.Add("@vide_Descripcion", item.vide_Descripcion);
                parametro.Add("@vide_ImagenFactura", item.vide_ImagenFactura);
                parametro.Add("@vide_MontoGastado", item.vide_MontoGastado);
                parametro.Add("@vien_Id", item.vien_Id);
                parametro.Add("@cavi_Id", item.cavi_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@vide_FechaModificacion", item.vide_FechaModificacion);
                parametro.Add("@vide_MontoReconocido", item.vide_MontoReconocido);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ViaticosDetActualizar, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                result.MessageStatus = (answer == 1) ? "Exito" : "Error";
                return result;
            }
        }
    }
}
