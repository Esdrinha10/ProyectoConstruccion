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
    public class CargoRepository : IRepository<tbCargos>
    {
        
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@carg_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarCargo,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbCargos Find(int? id)
        {
            tbCargos result = new tbCargos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@carg_Id", id);
                result = db.QueryFirst<tbCargos>(ScriptsDataBase.BuscarCargo, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbCargos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@carg_Descripcion", item.carg_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@carg_FechaCreacion", item.carg_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarCargo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbCargos> List()
        {
            List<tbCargos> result = new List<tbCargos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCargos>(ScriptsDataBase.ListarCargos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbCargos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@carg_Id", item.carg_Id);
                parameter.Add("@carg_Descripcion", item.carg_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@carg_FechaModificacion", item.carg_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCargo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
