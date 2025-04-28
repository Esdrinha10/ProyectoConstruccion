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
    public class RentaMaquinariaPorActividadRepository : IRepository<tbRentaMaquinariasPorActividades>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@rmac_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarRentaMaquinariaPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbRentaMaquinariasPorActividades Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbRentaMaquinariasPorActividades> List(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                return db.Query<tbRentaMaquinariasPorActividades>(ScriptsDataBase.ListarRentasMaquinariasPorActividades, parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<tbRentaMaquinariasPorActividades> ListarPresupuesto(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                return db.Query<tbRentaMaquinariasPorActividades>(ScriptsDataBase.ListarPresupuestoRentasMaquinariasPorActividades, parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public virtual RequestStatus Insert(tbRentaMaquinariasPorActividades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mapr_Id", item.mapr_Id);
                parameter.Add("@rmac_Rentapor", item.rmac_Rentapor);
                parameter.Add("@rmac_CantidadRenta", item.rmac_CantidadRenta);
                parameter.Add("@rmac_PrecioRenta", item.rmac_PrecioRenta);
                parameter.Add("@rmac_CantidadMaquinas", item.rmac_CantidadMaquinas);
                parameter.Add("@rmac_CantidadRentaFormula", item.rmac_CantidadRentaFormula);
                parameter.Add("@rmac_PrecioRentaFormula", item.rmac_PrecioRentaFormula);
                parameter.Add("@rmac_CantidadMaquinaFormula", item.rmac_CantidadMaquinaFormula);
                parameter.Add("@rmac_FechaContratacion", DateTime.Now);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@rmac_ActividadLlenado", item.rmac_ActividadLlenado);
                parameter.Add("@rmac_Estado", item.rmac_Estado);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@rmac_FechaCreacion", DateTime.Now);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarRentaMaquinariaPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbRentaMaquinariasPorActividades> List()
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Update(tbRentaMaquinariasPorActividades item)
        
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@rmac_Id", item.rmac_Id);
                parameter.Add("@mapr_Id", item.mapr_Id);
                parameter.Add("@rmac_CantidadRenta", item.rmac_CantidadRenta);
                parameter.Add("@rmac_PrecioRenta", item.rmac_PrecioRenta);
                parameter.Add("@rmac_CantidadMaquinas", item.rmac_CantidadMaquinas);
                parameter.Add("@rmac_CantidadRentaFormula", item.rmac_CantidadRentaFormula);
                parameter.Add("@rmac_PrecioRentaFormula", item.rmac_PrecioRentaFormula);
                parameter.Add("@rmac_CantidadMaquinaFormula", item.rmac_CantidadMaquinaFormula);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@rmac_FechaModificacion", DateTime.Now);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarRentaMaquinariaPorActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }
    }
}
