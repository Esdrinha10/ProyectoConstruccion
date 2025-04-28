using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class TipoProyectoRepository : IRepository<tbTiposProyecto>
    {
        /// <summary>
        /// Elimina un tipo específico por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tipr_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Eliminar_TipoProyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve una tipo específicp por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo a buscar.</param>
        /// <returns>Un objeto tbTiposProyecto que representa el tipo encontrado.</returns>
        public tbTiposProyecto Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tipr_Id", id);

                var result = db.QueryFirst<tbTiposProyecto>(ScriptsDataBase.Buscar_TipoProyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo tipo en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbTiposProyecto que contiene los datos de la nuevo tipo.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbTiposProyecto item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tipr_Descripcion", item.tipr_Descripcion);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("tipr_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Insertar_TipoProyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            } 
        }
        /// <summary>
        /// Obtiene una lista de tipos de proyecto.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbTiposProyecto que representa los tipos encontrados.</returns>
        public IEnumerable<tbTiposProyecto> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbTiposProyecto>(ScriptsDataBase.Listar_TipoProyectos,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Actualiza los datos de una tipo existente.
        /// </summary>
        /// <param name="item">El objeto tbTiposProyecto que contiene los datos actualizados del tipo.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbTiposProyecto item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tipr_Id", item.tipr_Id);
                parametro.Add("tipr_Descripcion", item.tipr_Descripcion);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("tipr_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Actualizar_TipoProyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
