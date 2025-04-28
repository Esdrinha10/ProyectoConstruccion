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
 public   class CategoriaRepository : IRepository<tbCategorias>
    {
        public RequestStatus Delete(int? id)
        {

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cate_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarCategoria, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public tbCategorias Find(int? id)
        {
            tbCategorias result = new tbCategorias();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cate_Id", id);
                result = db.QueryFirst<tbCategorias>(ScriptsDataBase.BuscarCategoria, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbCategorias item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cate_Descripcion", item.cate_Descripcion);
                parameter.Add("@cate_UsuarioCreacion", item.usua_Creacion);
                parameter.Add("@cate_FechaCreacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarCategoria, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = ansewer > 0 ? "Insertado con Éxito" : "Ese registro ya existe";

                // Devolvemos el estado de la solicitud de inserción
                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbCategorias> List()
        {
            List<tbCategorias> result = new List<tbCategorias>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCategorias>(ScriptsDataBase.ListarCategorias, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbCategorias item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cate_Id", item.cate_Id);
                parameter.Add("@cate_Descripcion", item.cate_Descripcion);
                parameter.Add("@cate_UsuarioModificacion", item.usua_Modificacion);
                parameter.Add("@cate_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCategoria, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
