using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsPlanilla;
using System.Data;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class PlanillaJefeCuadrillaRepository
    {
        public IEnumerable<PagoJefeObraPlanillaViewModel> List(DateTime fecha)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@fecha", fecha, DbType.DateTime);
                return db.Query<PagoJefeObraPlanillaViewModel>(ScriptsDataBase.PlanillaJefeObraListar, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<DeduccionPorEmpleadoViewModel> ListDeducciones(DateTime fecha )
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@fecha", fecha, DbType.DateTime);

                return db.Query<DeduccionPorEmpleadoViewModel>(
                    ScriptsDataBase.DeduccionesJefeListar,
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public IEnumerable<PagoJefeObraPlanillaViewModel> ListDeducciones2(DateTime fecha)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@fecha", fecha, DbType.DateTime);

                return db.Query<PagoJefeObraPlanillaViewModel>(
                    ScriptsDataBase.DeduccionesJefeListar2,
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        public RequestStatus InsertPlanillaDetalle(string item, DateTime fecha)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@json", item);
                parameter.Add("@fecha", fecha);


                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarPlanillaDetalleJefeObra, parameter, commandType: CommandType.StoredProcedure);

                var saber = ansewer.Select(ans =>
                {
                    return ans;

                }).ToList();

                result.CodeStatus = saber.Count;

                return result;
            }
        }
    }
}
