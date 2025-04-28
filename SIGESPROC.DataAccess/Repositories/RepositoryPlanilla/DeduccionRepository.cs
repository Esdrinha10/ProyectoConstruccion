
﻿using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class DeduccionRepository : IRepository<tbDeducciones>
    {
        /// <summary>
        /// Elimina una deducción específico por su ID.
        /// </summary>
        /// <param name="id">El ID de la deducción a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? deduId)
        {
             string sql = ScriptsDataBase.EliminarDeduccion;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@dedu_Id", deduId);

                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }


        /// <summary>
        /// Busca y devuelve una deducción específico por su ID.
        /// </summary>
        /// <param name="id">El ID de la deducción a buscar.</param>
        /// <returns>Un objeto tbDeducciones que representa el banco encontrado.</returns>
        public tbDeducciones Find(int? dedu_Id)
        {
            string sql = ScriptsDataBase.BuscarDeduccion;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@dedu_Id", dedu_Id);

                return db.QuerySingleOrDefault<tbDeducciones>(sql, parametro, commandType: CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// Inserta una nueva deducción en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbDeducciones que contiene los datos de la deducción a insertar.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public virtual RequestStatus Insert(tbDeducciones item)
        {

             string sql = ScriptsDataBase.InsertarDeduccion;
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@dedu_Descripcion", item.dedu_Descripcion);
                parametro.Add("@dedu_Porcentaje", item.dedu_Porcentaje);
                parametro.Add("@dedu_EsMontoFijo", item.dedu_EsMontoFijo);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@dedu_FechaCreacion", item.dedu_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarDeduccion, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }

        }

        public RequestStatus InsertarDeduccionesPorPlanilla(DeduccionViewModel item)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@dedu_Id", item.dedu_Id);
                parameter.Add("@plde_Id", item.plde_Id);
                parameter.Add("@dedu_Porcentaje", item.dedu_Porcentaje);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@depl_FechaCreacion", item.dedu_FechaCreacion);

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
        /// <summary>
        /// Obtiene una lista de todos los tbDeducciones en la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbDeducciones que representa la lista de deducciones.</returns>
        public IEnumerable<tbDeducciones> List()
        {

             string sql = ScriptsDataBase.ListarDeducciones;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                return db.Query<tbDeducciones>(sql, commandType: CommandType.StoredProcedure).ToList();
            }

        }
        /// <summary>
        /// Obtiene una lista de todos los bancos en la base de datos.
        /// </summary>
        /// <param name="empl_Id">El id del empleado del cual queremos obtener las deducciones.</param>
        /// <returns>Una colección IEnumerable de objetos DeduccionPorEmpleadoViewModel que representa la lista de deducciones.</returns>
        public IEnumerable<DeduccionPorEmpleadoViewModel> ListDeduccionPorEmpleado(int empl_Id)
        {

            string sql = ScriptsDataBase.ListarDeduccionPorEmpleado;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@empl_Id", empl_Id);
                return db.Query<DeduccionPorEmpleadoViewModel>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public IEnumerable<DeduccionPorEmpleadoViewModel> BuscarDeduccionPorEmpleado(int empl_Id)
        {

            string sql = ScriptsDataBase.BuscarDeduccionPorEmpleado;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@empl_Id", empl_Id);
                return db.Query<DeduccionPorEmpleadoViewModel>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();
            }

        }
        /// <summary>
        /// Asigna o remueve una deducción a un empleado en la base de datos.
        /// </summary>
        /// <param name="item">El objeto DeduccionPorEmpleadoViewModel que contiene los datos de la deducción a asignar o remover.</param>
        /// <returns>Un mensaje de éxito si la inserción fue exitosa, o un mensaje de conflicto o error en caso contrario.</returns>
        public RequestStatus DeduccionPorEmpleado(DeduccionPorEmpleadoViewModel item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@empl_Id", item.empl_Id);
                parametro.Add("@deduccionesJSON", item.deduccionesJSON);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.DeduccionPorEmpleado, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Actualiza una deducción existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbDeducciones que contiene los datos actualizados de la deducción.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbDeducciones item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dedu_Id", item.dedu_Id);
                parameter.Add("@dedu_Descripcion", item.dedu_Descripcion);
                parameter.Add("@dedu_Porcentaje", item.dedu_Porcentaje);
                parameter.Add("@dedu_EsMontoFijo", item.dedu_EsMontoFijo);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@dedu_FechaModificacion", item.dedu_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarDeduccion, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
