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
    public class PresupuestoDetalleRepository : IRepository<tbPresupuestosDetalle>
    {

        /// <summary>
        /// Elimina un los detalles de un presupuesto específico por su ID.
        /// </summary>
        /// <param name="id">El ID del detalle presupuesto a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pdet_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarPresupuestoDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbPresupuestosDetalle Find(int? id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Inserta un nuevo detalle de presupuesto en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosDetalle que contiene los datos del nuevo presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbPresupuestosDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pdet_Cantidad", item.pdet_Cantidad);
                parameter.Add("@pdet_PrecioManoObra", item.pdet_PrecioManoObra);
                parameter.Add("@pdet_PrecioMateriales", item.pdet_PrecioMateriales);
                parameter.Add("@pdet_PrecioMaquinaria", item.pdet_PrecioMaquinaria);
                parameter.Add("@unme_Id", item.unme_Id);
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@pdet_ManoObraFormula", item.pdet_ManoObraFormula);
                parameter.Add("@pdet_MaterialFormula", item.pdet_MaterialFormula);
                parameter.Add("@pdet_MaquinariaFormula", item.pdet_MaquinariaFormula);
                parameter.Add("@pdet_CantidadFormula", item.pdet_CantidadFormula);
                //parameter.Add("@acti_Id", item.acti_Id);
                parameter.Add("@pdet_Incluido", item.pdet_Incluido);
                parameter.Add("@pdet_Ganancia", item.pdet_Ganancia);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pdet_FechaCreacion", item.pdet_FechaCreacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarPresupuestoDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los detalles de presupuesto.
        /// </summary>
        /// /// <param name="id">El ID del presupuesto enzabezado.</param>
        /// <returns>Una colección IEnumerable de objetos tbPresupuestosDetalle que representa los detalles de presupuesto encontrados.</returns>
        public IEnumerable<tbPresupuestosDetalle> List(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", id);
                return db.Query<tbPresupuestosDetalle>(ScriptsDataBase.ListarPresupuestosDetalle, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<tbPresupuestosDetalle> List()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Actualiza los datos de un detalle de presupuesto existente.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosDetalle que contiene los datos actualizados del detalle presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbPresupuestosDetalle item)
         {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pdet_Id", item.pdet_Id);
                parameter.Add("@pdet_Cantidad", item.pdet_Cantidad);
                parameter.Add("@pdet_PrecioManoObra", item.pdet_PrecioManoObra);
                parameter.Add("@pdet_PrecioMaquinaria", item.pdet_PrecioMaquinaria);
                parameter.Add("@pdet_PrecioMateriales", item.pdet_PrecioMateriales);
                parameter.Add("@pdet_ManoObraFormula", item.pdet_ManoObraFormula);
                parameter.Add("@pdet_MaterialFormula", item.pdet_MaterialFormula);
                parameter.Add("@pdet_MaquinariaFormula", item.pdet_MaquinariaFormula);
                parameter.Add("@pdet_CantidadFormula", item.pdet_CantidadFormula);
                parameter.Add("@unme_Id", item.unme_Id);
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@pdet_Incluido", item.pdet_Incluido);
                parameter.Add("@pdet_Ganancia", item.pdet_Ganancia);
                //parameter.Add("@acti_Id", item.acti_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pdet_FechaModificacion", item.pdet_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarPresupuestoDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
