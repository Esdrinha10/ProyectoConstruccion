using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class PagoRepository 
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pago_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarPago, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public virtual RequestStatus Insert(tbPagos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pago_Monto", item.pago_Monto);
                parameter.Add("@pago_Fecha", item.pago_Fecha);
                parameter.Add("@clie_Id", item.clie_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pago_FechaCreacion", item.pago_FechaCreacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarPago, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }



        public IEnumerable<tbPagos> Find(int id)
        {

            var parameters = new { clie_Id = id };
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbPagos>(ScriptsDataBase.BuscarPago, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public virtual RequestStatus Update(tbPagos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pago_Id", item.pago_Id);
                parameter.Add("@pago_Monto", item.pago_Monto);
                parameter.Add("@pago_Fecha", item.pago_Fecha);
                parameter.Add("@clie_Id", item.clie_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pago_FechaModificacion", item.pago_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarPago, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbPagos> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();

                var result = db.Query<tbPagos>(ScriptsDataBase.ListarPagos,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbPagos Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
