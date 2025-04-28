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
    public class InsumoPorActividadRepository : IRepository<tbInsumosPorActividades>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpa_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarInsumoPorActiviad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbInsumosPorActividades Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbInsumosPorActividades> List(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);

                return db.Query<tbInsumosPorActividades>(ScriptsDataBase.Listar_InsumosPorActividad, 
                    parameter, 
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public IEnumerable<tbInsumosPorActividades> ListarPresupuesto(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                return db.Query<tbInsumosPorActividades>(ScriptsDataBase.ListarPresupuestoInsumosPorActividades, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual RequestStatus Insert(tbInsumosPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpp_Id", item.inpp_Id);
                parameter.Add("@inpa_stock", item.inpa_stock);
                parameter.Add("@inpa_PrecioCompra", item.inpa_PrecioCompra);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@inpa_Estado", item.inpa_Estado);
                parameter.Add("@inpa_Rendimiento", item.inpa_Rendimiento);
                parameter.Add("@inpa_Desperdicio", item.inpa_Desperdicio);
                parameter.Add("@inpa_FormulaRendimiento", item.inpa_FormulaRendimiento);
                parameter.Add("@inpa_PrecioCompraFormula", item.inpa_PrecioCompraFormula);
                parameter.Add("@inpa_ActividadLlenado", item.inpa_ActividadLlenado);
                parameter.Add("@inpa_StockFormula", item.inpa_StockFormula);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@inpa_FechaCreacion", DateTime.Now);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarInsumoPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbInsumosPorActividades> List()
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Update(tbInsumosPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inpa_Id", item.inpa_Id);
                parameter.Add("@inpa_stock", item.inpa_stock);
                parameter.Add("@inpa_PrecioCompra", item.inpa_PrecioCompra);
                parameter.Add("@inpa_Rendimiento", item.inpa_Rendimiento);
                parameter.Add("@inpa_Rendimiento", item.inpa_Rendimiento);
                parameter.Add("@inpa_Desperdicio", item.inpa_Desperdicio);
                parameter.Add("@inpa_FormulaRendimiento", item.inpa_FormulaRendimiento);
                parameter.Add("@inpa_PrecioCompraFormula", item.inpa_PrecioCompraFormula);
                parameter.Add("@inpa_StockFormula", item.inpa_StockFormula);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@inpa_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarInusmoPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
