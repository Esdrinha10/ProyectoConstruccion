using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using SIGESPROC.DataAccess.Context;
using SIGESPROC.Common.Models.ModelsPlanilla;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class PrestamoRepository : IRepository<tbPrestamos>
    {
        public RequestStatus Delete(int? presId)
        {
            string sql = ScriptsDataBase.EliminarPrestamo;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@pres_Id", presId);

                var result = db.QuerySingleOrDefault<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }

        public tbPrestamos Find(int? presId)
        {
            string sql = ScriptsDataBase.BuscarPrestamo;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@pres_Id", presId);

                return db.QuerySingleOrDefault<tbPrestamos>(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual RequestStatus Insert(tbPrestamos item)
        {
            string sql = "Nomi.SP_Prestamo_Insertar";

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@pres_Monto", item.pres_Monto);
                parametro.Add("@pres_TasaInteres", item.pres_TasaInteres);
                parametro.Add("@pres_Descripcion", item.pres_Descripcion);
                parametro.Add("@pres_FechaPrimerPago", item.pres_FechaPrimerPago);
                parametro.Add("@pres_Pagos", item.pres_Pagos);
                parametro.Add("@empl_Id", item.empl_Id);
                parametro.Add("@frec_Id", item.frec_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@pres_FechaCreacion", item.pres_FechaCreacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public RequestStatus InsertPrestamosPlanilla(string item)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@json", item);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarPrestamoPlanilla, parameter, commandType: CommandType.StoredProcedure);

                var saber = ansewer.Select(ans =>
                {
                    return ans;

                }).ToList();

                result.CodeStatus = saber.Count;

                return result;
            }
        }

        public RequestStatus InsertAbono(tbAbonosPorPrestamos item)
        {
            string sql = "Nomi.SP_Abono_Insertar";

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@pres_Id", item.pres_Id);
                parametro.Add("@abpr_MontoAbonado", item.abpr_MontoAbonado);
                parametro.Add("@abpr_Fecha", item.abpr_Fecha);
                parametro.Add("@abpr_DeducidoEnPlanilla", 0);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@abpr_FechaCreacion", item.abpr_FechaCreacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public RequestStatus InsertarCuotaPorEmpleado(tbPrestamos item)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@pres_Id", item.pres_Id);
                parameter.Add("@Cuota", item.pres_Abonado);
                parameter.Add("@pres_UltimaFechaPago", item.pres_UltimaFechaPago);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pres_FechaModificacion", item.pres_FechaModificacion);

                parameter.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameter.Add("@MENSAJE", dbType: DbType.String, direction: ParameterDirection.Output);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarDeduccionesPorPlanilla, parameter, commandType: CommandType.StoredProcedure);

                int ultimoID = parameter.Get<int>("@ID");
                string errorr = parameter.Get<string>("@MENSAJE");

                if (ultimoID != 1)
                {
                    result.Message = errorr;
                }

                result.CodeStatus = ultimoID;

                return result;
            }
        }

        public IEnumerable<tbPrestamos> List()
        {
            string sql = ScriptsDataBase.ListarPrestamos;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbPrestamos>(sql, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public IEnumerable<tbAbonosPorPrestamos> ListAbonos()
        {
            string sql = ScriptsDataBase.ListarAbonos;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbAbonosPorPrestamos>(sql, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbPrestamos item)
        {
             string sql = ScriptsDataBase.ActualizarPrestamo;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@pres_Id", item.pres_Id);
                parametro.Add("@pres_Monto", item.pres_Monto);
                parametro.Add("@pres_TasaInteres", item.pres_TasaInteres);
                parametro.Add("@pres_Descripcion", item.pres_Descripcion);
                parametro.Add("@pres_FechaPrimerPago", item.pres_FechaPrimerPago);
                parametro.Add("@pres_Pagos", item.pres_Pagos);
                parametro.Add("@empl_Id", item.empl_Id);
                parametro.Add("@frec_Id", item.frec_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@pres_FechaModificacion", item.pres_FechaModificacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
        public RequestStatus UpdateAbono(tbAbonosPorPrestamos item)
        {
            string sql = "Nomi.SP_Abono_Actualizar";

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@abpr_Id", item.abpr_Id);
                parametro.Add("@pres_Id", item.pres_Id);
                parametro.Add("@abpr_MontoAbonado", item.abpr_MontoAbonado);
                parametro.Add("@abpr_Fecha", item.abpr_Fecha);
                parametro.Add("@abpr_DeducidoEnPlanilla", 0);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@abpr_FechaModificacion", item.abpr_FechaModificacion);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
