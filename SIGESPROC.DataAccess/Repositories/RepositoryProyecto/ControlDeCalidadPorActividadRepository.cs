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
    public class ControlDeCalidadPorActividadRepository : IRepository<tbControlDeCalidadesPorActividades>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coac_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarControlDeCalidadPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbControlDeCalidadesPorActividades Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbControlDeCalidadesPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@coca_Id", item.coca_Id);
                //parameter.Add("@usua_Creacion", item.usua_Creacion);
                //parameter.Add("@coca_FechaCreacion", item.coca_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarControlDeCalidadPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public IEnumerable<tbControlDeCalidadesPorActividades> List(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coac_Id", id);
                return db.Query<tbControlDeCalidadesPorActividades>(ScriptsDataBase.ListarControlDeCalidadesPorActividades, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<tbControlDeCalidadesPorActividades> List()
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Update(tbControlDeCalidadesPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coac_Id", item.coac_Id);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@coca_Id", item.coca_Id);
                //parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                //parameter.Add("@coca_FechaModificacion", item.coca_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarControlDeCalidadPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
