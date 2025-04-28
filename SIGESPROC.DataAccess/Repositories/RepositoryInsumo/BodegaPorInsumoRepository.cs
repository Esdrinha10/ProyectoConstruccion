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
    public class BodegaPorInsumoRepository : IRepository<tbBodegasPorInsumo>
    {
        public RequestStatus Delete(tbBodegasPorInsumo item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpp_Id", item.inpp_Id);
                parameter.Add("@bode_Id", item.bode_Id);
                parameter.Add("@bopi_Stock", item.bopi_Stock);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarBodegaPorInsumo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbBodegasPorInsumo Find(int? id)
        {
            tbBodegasPorInsumo result = new tbBodegasPorInsumo();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);
                result = db.QueryFirst<tbBodegasPorInsumo>(ScriptsDataBase.ListarBodegasPorInsumos, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbBodegasPorInsumo item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpp_Id", item.inpp_Id);
                parameter.Add("@bode_Id", item.bode_Id);
                parameter.Add("@bopi_Stock", item.bopi_Stock);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@bopi_FechaCreacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarBodegaPorInsumo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbBodegasPorInsumo> List()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbBodegasPorInsumo> List1(int id)
        {
            List<tbBodegasPorInsumo> result = new List<tbBodegasPorInsumo>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);
                result = db.Query<tbBodegasPorInsumo>(ScriptsDataBase.ListarBodegasPorInsumos, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public IEnumerable<tbBodegasPorInsumo> List1(int? id)
        {
            List<tbBodegasPorInsumo> result = new List<tbBodegasPorInsumo>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);
                result = db.Query<tbBodegasPorInsumo>(ScriptsDataBase.ListarBodegasPorInsumos, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbBodegasPorInsumo item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bopi_Id", item.bopi_Id);
                parameter.Add("@inpp_Id", item.inpp_Id);
                parameter.Add("@bode_Id", item.bode_Id);
                parameter.Add("@bopi_Stock", item.bopi_Stock);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@bopi_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarBodegaPorInsumo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
