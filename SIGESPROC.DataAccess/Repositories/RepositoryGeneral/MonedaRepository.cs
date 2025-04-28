using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class MonedaRepository : IRepository<tbMonedas>
    {
        /// <summary>
        /// Elimina una Moneda usando su ID.
        /// </summary>
        /// <param name="id">El ID de la Moneda que se desea eliminar.</param>
        /// <returns>El estado de la operación de eliminación.</returns>
        public RequestStatus Delete(int? id)
        {  
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mone_Id", id);
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarMoneda, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca una Moneda por su ID.
        /// </summary>
        /// <param name="id">El ID de la Moneda que se desea buscar.</param>
        /// <returns>La Moneda encontrada.</returns>
        public tbMonedas Find(int? id)
        {
            tbMonedas result = new tbMonedas();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mone_Id", id);
                result = db.QueryFirst<tbMonedas>(ScriptsDataBase.BuscarMoneda, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta una nueva Moneda en la base de datos.
        /// </summary>
        /// <param name="item">Los detalles de la Moneda que se desea agregar.</param>
        /// <returns>El estado de la operación de inserción.</returns>
        public virtual RequestStatus Insert(tbMonedas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mone_Nombre", item.mone_Nombre);
                parameter.Add("@mone_Abreviatura", item.mone_Abreviatura);
                parameter.Add("@pais_Id", item.pais_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@mone_FechaCreacion", item.mone_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarMoneda, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos las Monedas.
        /// </summary>
        /// <returns>Lista de las Monedas disponibles.</returns>
        public IEnumerable<tbMonedas> List()
        {
            List<tbMonedas> result = new List<tbMonedas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbMonedas>(ScriptsDataBase.ListarMonedas, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public tbTasasCambio ObtenerValorMoneda(int mone_Id, int taca_Id)
        {
            tbTasasCambio result = new tbTasasCambio();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mone_Id", mone_Id);
                parameter.Add("@taca_Id", taca_Id);
                result = db.QueryFirst<tbTasasCambio>(ScriptsDataBase.ObtenerValorMoneda, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Actualiza la información de una Moneda existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada de la Moneda.</param>
        /// <returns>El estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbMonedas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mone_Id", item.mone_Id);
                parameter.Add("@mone_Nombre", item.mone_Nombre);
                parameter.Add("@mone_Abreviatura", item.mone_Abreviatura);
                parameter.Add("@pais_Id", item.pais_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@mone_FechaModificacion", item.mone_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarMoneda, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
