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
    public class EtapaPorProyectoRepository
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etpr_Id", id);

                var answer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEtapaPorProyecto, parameter, commandType: CommandType.StoredProcedure);

                return answer;
            }
        }

        public virtual RequestStatus Insert(tbEtapasPorProyectos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etap_Id", item.etap_Id);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@etpr_FechaCreacion", DateTime.Now);
                parameter.Add("@etpr_Estado", item.etpr_Estado);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.InsertarEtapaPorProyecto, parameter, commandType: CommandType.StoredProcedure);
                
                return ansewer;
            }
        }
        public virtual IEnumerable<tbEtapasPorProyectos> Listar(int? id)
        {
            List<tbEtapasPorProyectos>result = new  List<tbEtapasPorProyectos>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Id", id);
                result = db.Query<tbEtapasPorProyectos>(ScriptsDataBase.ListarEtapasPorProyecto, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbEtapasPorProyectos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etpr_Id", item.etpr_Id);
                parameter.Add("@etap_Id", item.etap_Id);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@etpr_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.ActualizarEtapaPorProyecto, parameter, commandType: CommandType.StoredProcedure);
                
                return ansewer;
            }
        }

        public tbEtapasPorProyectos Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@etpr_Id", id);
                
                var result = db.QueryFirst<tbEtapasPorProyectos>(ScriptsDataBase.BuscarEtapaPorProyecto, parameter, commandType: CommandType.StoredProcedure);
                
                return result;
            }
        }
    }
}
