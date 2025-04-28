using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    public class InsumoPorMedidaRepository : IRepository<tbInsumosPorMedidas>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpm_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarInsumoPorMedida, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public IEnumerable<tbInsumosPorMedidas> Buscar(int prov, int id)
        {
            List<tbInsumosPorMedidas> result = new List<tbInsumosPorMedidas>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", prov);
                parameter.Add("@insu_Id", id);
                result = db.Query<tbInsumosPorMedidas>(ScriptsDataBase.InsumoPorMedidasBuscar, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public tbInsumosPorMedidas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbInsumosPorMedidas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", item.insu_Id);
                parameter.Add("@unme_Id", item.unme_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@inpm_FechaCreacion", item.inpm_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarInsumoPorMedida, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

     

        public IEnumerable<tbInsumosPorMedidas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInsumosPorMedidas item)
        {
            throw new NotImplementedException();
        }
    }
}
