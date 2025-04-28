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
    public class InsumoPorProveedorRepository : IRepository<tbInsumosPorProveedores>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpp_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarInsumoPorProveedores, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

        public IEnumerable<tbInsumosPorProveedores> Find(int? id)
        {
            List<tbInsumosPorProveedores> result = new List<tbInsumosPorProveedores>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);
                result = db.Query<tbInsumosPorProveedores>(ScriptsDataBase.ListarInsumoPorProveedoresFiltrado, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Insert(tbInsumosPorProveedores item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", item.insu_Id);
                parameter.Add("@suca_Id", item.suca_Id);
                parameter.Add("@mate_Id", item.mate_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@inpp_Preciocompra", item.inpp_Preciocompra);
                parameter.Add("@unme_Id", item.unme_Id);
                parameter.Add("@inpp_Observacion", item.inpp_Observacion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@inpp_FechaCreacion", item.inpp_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarInsumoPorProveedores, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbInsumosPorProveedores> List()
        {
            List<tbInsumosPorProveedores> result = new List<tbInsumosPorProveedores>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbInsumosPorProveedores>(ScriptsDataBase.ListarInsumoPorProveedores, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        public IEnumerable<tbInsumosPorProveedores> Listar(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", id);
                return db.Query<tbInsumosPorProveedores>(ScriptsDataBase.ListarInsumosPorProveedores, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual RequestStatus Update(tbInsumosPorProveedores item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpp_Id", item.inpp_Id);
                parameter.Add("@insu_Id", item.insu_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@inpp_Preciocompra", item.inpp_Preciocompra);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@inpp_FechaModificacion", item.inpp_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarInsumoPorProveedores, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        tbInsumosPorProveedores IRepository<tbInsumosPorProveedores>.Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
