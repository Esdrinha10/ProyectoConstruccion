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
    public class PresupuestoPorTasaCambioRepository : IRepository<tbPresupuestosPorTasasCambio>
    {

        /// <summary>
        /// Elimina una tasa de cambio de un presupuesto por su ID.
        /// </summary>
        /// <param name="id">El ID de la tasa de cambio de presupuesto a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pptc_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarPresupuestoPorTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbPresupuestosPorTasasCambio Find(int? id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Inserta una nueva tasa de cambio a un presupuesto en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosPorTasasCambio que contiene los datos de la nueva tasa de cambio para un presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbPresupuestosPorTasasCambio item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@taca_Id", item.taca_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pptc_FechaCreacion", item.pptc_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarPresupuestoPorTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las tasas de cambio de un presupuesto.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbPresupuestosPorTasasCambio que representa los las tasas de cambio de ese presupuesto.</returns>
        public IEnumerable<tbPresupuestosPorTasasCambio> List(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", id);
                return db.Query<tbPresupuestosPorTasasCambio>(ScriptsDataBase.ListarPresupuestosPorTasasCambio, parameter, commandType: CommandType.StoredProcedure);
            }
        }
   
    

        public IEnumerable<tbPresupuestosPorTasasCambio> List()
        {
            throw new NotImplementedException();    
        }

        /// <summary>
        /// Actualiza los datos de una tasa de cambio de un presupuesto existente.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosPorTasasCambio que contiene los datos actualizados de la tasa de cambio por presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbPresupuestosPorTasasCambio item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pptc_Id", item.pptc_Id);
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@taca_Id", item.taca_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pptc_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarPresupuestoPorTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
