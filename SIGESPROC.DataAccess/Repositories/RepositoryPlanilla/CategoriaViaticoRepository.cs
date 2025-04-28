using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
  public  class CategoriaViaticoRepository : IRepository<tbCategoriasViaticos>
    {
        public RequestStatus Delete(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();

                // Añadimos el parámetro "cavi_Id" con el valor del ID proporcionado
                parameter.Add("cavi_Id", id);

                // Ejecutamos el procedimiento almacenado "EliminarCategoriaViatico" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarCategoriaViatico,
                                                          parameter,
                                                          commandType: CommandType.StoredProcedure);

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }

        public tbCategoriasViaticos Find(int? id)
        {
            tbCategoriasViaticos result = new tbCategoriasViaticos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cavi_Id", id);
                result = db.QueryFirst<tbCategoriasViaticos>(ScriptsDataBase.BuscarCategoriaViatico, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbCategoriasViaticos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cavi_Descripcion", item.cavi_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@cavi_FechaCreacion", item.cavi_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarcategoriaViatico, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbCategoriasViaticos> List()
        {
            List<tbCategoriasViaticos> result = new List<tbCategoriasViaticos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCategoriasViaticos>(ScriptsDataBase.ListarCategoriaViaticos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbCategoriasViaticos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@cavi_Id", item.cavi_Id);
                parameter.Add("@cavi_Descripcion", item.cavi_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@cavi_FechaModificacion", item.cavi_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarcategoriaViatico, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
