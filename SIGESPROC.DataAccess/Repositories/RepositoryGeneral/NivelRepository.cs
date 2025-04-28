using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class NivelRepository : IRepository<tbNiveles>
    {
        
        public RequestStatus Delete(int? id)
        {
            
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {

                var parameter = new DynamicParameters();
                parameter.Add("@nive_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarNivel, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public tbNiveles Find(int? id)
        {
            tbNiveles result = new tbNiveles();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@nive_Id", id);
                result = db.QueryFirst<tbNiveles>(ScriptsDataBase.BuscarNivel, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbNiveles item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@nive_Descripcion", item.nive_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@nive_FechaCreacion", item.nive_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarNivel, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbNiveles> List()
        {
            List<tbNiveles> result = new List<tbNiveles>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNiveles>(ScriptsDataBase.ListarNiveles, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbNiveles item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@nive_Id", item.nive_Id);
                parameter.Add("@nive_Descripcion", item.nive_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@nive_FechaModificacion", item.nive_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarNivel, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
