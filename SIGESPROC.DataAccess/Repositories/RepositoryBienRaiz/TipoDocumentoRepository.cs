using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz
{
   public class TipoDocumentoRepository : IRepository<tbTiposDocumentos>
    {
        /// <summary>
        /// Elimina un tipo de documento usando su ID.
        /// </summary>
        /// <param name="id">El ID del tipo de documento que se desea eliminar.</param>
        /// <returns>El estado de la operación de eliminación.</returns>
   

        public RequestStatus Delete(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tido_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarTipoDocumentos,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }


        /// <summary>
        /// Busca un terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo de documento que se desea buscar.</param>
        /// <returns>El tipo de documento encontrado.</returns>
        public tbTiposDocumentos Find(int? id)
        {
            tbTiposDocumentos result = new tbTiposDocumentos();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@tido_Id", id);
                result = db.QueryFirst<tbTiposDocumentos>(ScriptsDataBase.BuscarTipoDocumentos, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca un terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo de documento que se desea buscar.</param>
        /// <returns>El tipo de documento encontrado.</returns>
        public tbTiposDocumentos buscar(string id)
        {
            tbTiposDocumentos result = new tbTiposDocumentos();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@tido_Id", id);
                result = db.QueryFirst<tbTiposDocumentos>(ScriptsDataBase.BuscarTipoDocumentos, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }




        /// <summary>
        /// Inserta un nuevo tipo de documento en la base de datos.
        /// </summary>
        /// <param name="item">Los detalles del tipo de documento que se desea agregar.</param>
        /// <returns>El estado de la operación de inserción.</returns>
        public virtual RequestStatus Insert(tbTiposDocumentos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@tido_Descripcion", item.tido_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@tido_FechaCreacion", item.tido_FechaCreacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarTipoDocumentos, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }



        /// <summary>
        /// Obtiene una lista de todos los tipos de documento.
        /// </summary>
        /// <returns>Lista de terrenos disponibles.</returns>
        public IEnumerable<tbTiposDocumentos> List()
        {
            List<tbTiposDocumentos> result = new List<tbTiposDocumentos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbTiposDocumentos>(ScriptsDataBase.ListarTipoDocumentos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza la información de un tipo de documento existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada del tipo de documento.</param>
        /// <returns>El estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbTiposDocumentos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@tido_Id", item.tido_Id);
                parameter.Add("@tido_Descripcion", item.tido_Descripcion);
                parameter.Add("@usua_Mofificacion", item.usua_Mofificacion);
                parameter.Add("@tido_FechaModificacion", item.tido_FechaModificacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarTipoDocumentos, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
