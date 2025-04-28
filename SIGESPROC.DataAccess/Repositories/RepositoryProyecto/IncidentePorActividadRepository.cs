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
    public class IncidentePorActividadRepository : IRepository<tbIncidenciasPorActividades>
    {
        
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inac_Id", id);

                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarIncidentePorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public tbIncidenciasPorActividades Find(int? id)
        {
            tbIncidenciasPorActividades result = new tbIncidenciasPorActividades();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.QueryFirst<tbIncidenciasPorActividades>(ScriptsDataBase.BuscarIncidentePorActividad, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public IEnumerable<tbIncidenciasPorActividades> List(int? id)
        {
            List<tbIncidenciasPorActividades> result = new List<tbIncidenciasPorActividades>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.Query<tbIncidenciasPorActividades>(ScriptsDataBase.BuscarIncidentePorActividad, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Insert(tbIncidenciasPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@inci_Id", item.inci_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@inac_FechaCreacion", item.inac_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarIncidentePorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbIncidenciasPorActividades> List()
        {
            List<tbIncidenciasPorActividades> result = new List<tbIncidenciasPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbIncidenciasPorActividades>(ScriptsDataBase.ListarImagenesPorIncidente, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbIncidenciasPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inac_Id", item.inac_Id);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@inci_Id", item.inci_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@inac_FechaModificacion", item.inac_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarIncidentePorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }
    }
}
