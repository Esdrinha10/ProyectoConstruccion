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
    public class MaquinariaPorProveedorRepository : IRepository<tbMaquinariasPorProveedores>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mapr_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarMaquinariaPorProveedor, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

       
        public tbMaquinariasPorProveedores Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMaquinariasPorProveedores item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mapr_PrecioCompra", item.mapr_PrecioCompra);
                parameter.Add("@maqu_Id", item.maqu_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@mapr_FechaCreacion", item.mapr_FechaCreacion);
                parameter.Add("@nive_Id", item.nive_Id);
                parameter.Add("@mapr_DiaHora", item.mapr_DiaHora);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarMaquinariaPorProveedor, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public IEnumerable<tbMaquinariasPorProveedores> Buscar(int prov)
        {
            List<tbMaquinariasPorProveedores> result = new List<tbMaquinariasPorProveedores>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", prov);
                result = db.Query<tbMaquinariasPorProveedores>(ScriptsDataBase.BuscarMaquinariasPorProveedor, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public IEnumerable<tbMaquinariasPorProveedores> List()
        {
            List<tbMaquinariasPorProveedores> result = new List<tbMaquinariasPorProveedores>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbMaquinariasPorProveedores>(ScriptsDataBase.ListarMaquinariasPorProveedores, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbMaquinariasPorProveedores item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mapr_Id", item.mapr_Id);
                parameter.Add("@mapr_PrecioCompra", item.mapr_PrecioCompra);
                parameter.Add("@maqu_Id", item.maqu_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@mapr_FechaCreacion", item.mapr_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarMaquinariaPorProveedor, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
