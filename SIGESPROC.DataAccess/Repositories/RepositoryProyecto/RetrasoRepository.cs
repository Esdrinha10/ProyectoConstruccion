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
    public class RetrasoRepository : IRepository<tbRetrasos>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@retr_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarRetraso, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public IEnumerable<tbRetrasos> Find(int id)
        {

            var parameters = new { Proy_Id = id };
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbRetrasos>(ScriptsDataBase.BuscarRetraso, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public tbRetrasos Find(int? id)
        {
            tbRetrasos result = new tbRetrasos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Proy_Id", id);
                result = db.QueryFirst<tbRetrasos>(ScriptsDataBase.BuscarPago, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }



        public virtual RequestStatus Insert(tbRetrasos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@retr_Descripcion", item.retr_Descripcion);
                parameter.Add("@retr_Monto", item.retr_Monto);
                parameter.Add("@retr_Fecha", item.retr_Fecha);
                parameter.Add("@Proy_Id", item.Proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@retr_FechaCreacion", item.retr_FechaCreacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarRetraso, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbRetrasos> List()
        {
            List<tbRetrasos> result = new List<tbRetrasos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbRetrasos>(ScriptsDataBase.ListarNiveles, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbRetrasos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@retr_Id", item.retr_Id);
                parameter.Add("@retr_Descripcion", item.retr_Descripcion);
                parameter.Add("@retr_Monto", item.retr_Monto);
                parameter.Add("@retr_Fecha", item.retr_Fecha);
                parameter.Add("@usua_Modificacion", item.usua_Creacion);
                parameter.Add("@retr_FechaModificacion", item.retr_FechaCreacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarRetraso, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
