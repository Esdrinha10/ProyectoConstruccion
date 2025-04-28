using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    public class InsumoRepository : IRepository<tbInsumos>
    {
        /// <summary>
        /// Elimina un Insumo usando su ID.
        /// </summary>
        /// <param name="id">El ID del Insumo que se desea eliminar.</param>
        /// <returns>El estado de la operación de eliminación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", id);
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarInsumo, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca un Insumo por su ID.
        /// </summary>
        /// <param name="id">El ID del Insumo que se desea buscar.</param>
        /// <returns>El insumo encontrado.</returns>
        public tbInsumos Find(int? id)
        {
            tbInsumos result = new tbInsumos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", id);
                result = db.QueryFirst<tbInsumos>(ScriptsDataBase.BuscarInsumo, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca una SubCategoria por el ID de la Categoria.
        /// </summary>
        /// <param name="id">El ID de la Categoria para la SubCategoria que se desea buscar.</param>
        /// <returns>La Subcategoria encontrada.</returns>
        public IEnumerable<tbInsumos> FindCate(int? id)
        {
            IEnumerable<tbInsumos> result;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cate_Id", id);
                result = db.Query<tbInsumos>(ScriptsDataBase.MostrarSubcategoriasPorCategorias, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo Insumo en la base de datos.
        /// </summary>
        /// <param name="item">Los detalles del insumo que se desea agregar.</param>
        /// <returns>El estado de la operación de inserción.</returns>
        public virtual RequestStatus Insert(tbInsumos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Descripcion", item.insu_Descripcion);
                parameter.Add("@suca_Id", item.suca_Id);
                parameter.Add("@insu_UltimoPrecioUnitario", item.insu_UltimoPrecioUnitario);
                parameter.Add("@insu_Observacion", item.insu_Observacion);
                parameter.Add("@mate_Id", item.mate_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@insu_FechaCreacion", item.insu_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarInsumo, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = ansewer > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los Insumos.
        /// </summary>
        /// <returns>Lista de los insumos disponibles.</returns>
        public IEnumerable<tbInsumos> List()
        {
            List<tbInsumos> result = new List<tbInsumos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbInsumos>(ScriptsDataBase.ListarInsumos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos las Categorias.
        /// </summary>
        /// <returns>Lista de las Categorias disponibles.</returns>
        public IEnumerable<tbInsumos> ListCate()
        {
            List<tbInsumos> result = new List<tbInsumos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbInsumos>(ScriptsDataBase.CateListar, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        /// <summary>
        /// Actualiza la información de un Insumo existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada del Insumo.</param>
        /// <returns>El estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbInsumos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", item.insu_Id);
                parameter.Add("@insu_Descripcion", item.insu_Descripcion);
                parameter.Add("@suca_Id", item.suca_Id);
                parameter.Add("@insu_UltimoPrecioUnitario", item.insu_UltimoPrecioUnitario);
                parameter.Add("@insu_Observacion", item.insu_Observacion);
                parameter.Add("@mate_Id", item.mate_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@insu_FechaModificacion", item.insu_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarInsumo, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
