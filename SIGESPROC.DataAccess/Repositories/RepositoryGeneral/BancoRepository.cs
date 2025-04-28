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
    public class BancoRepository : IRepository<tbBancos>
    {
        /// <summary>
        /// Elimina un banco específico por su ID.
        /// </summary>
        /// <param name="id">El ID del banco a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@banc_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarBanco, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve un banco específico por su ID.
        /// </summary>
        /// <param name="id">El ID del banco a buscar.</param>
        /// <returns>Un objeto tbBancos que representa el banco encontrado.</returns>
        public tbBancos Find(int? id)
        {
            tbBancos result = new tbBancos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@banc_Id", id);
                result = db.QueryFirst<tbBancos>(ScriptsDataBase.BuscarBanco, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo banco en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbBancos que contiene los datos del banco a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbBancos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@banc_Descripcion", item.banc_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@banc_FechaCreacion", item.banc_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarBanco, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los bancos en la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbBancos que representa la lista de bancos.</returns>
        public IEnumerable<tbBancos> List()
        {
            List<tbBancos> result = new List<tbBancos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbBancos>(ScriptsDataBase.ListarBancos, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        /// <summary>
        /// Actualiza un banco existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbBancos que contiene los datos actualizados del banco.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbBancos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@banc_Id", item.banc_Id);
                parameter.Add("@banc_Descripcion", item.banc_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@banc_FechaModificacion", item.banc_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarBanco, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
