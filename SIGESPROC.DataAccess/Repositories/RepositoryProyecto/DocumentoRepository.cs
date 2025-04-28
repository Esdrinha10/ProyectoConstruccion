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
    public class DocumentoRepository
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@docu_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarDocumento, parameter, commandType: CommandType.StoredProcedure);
                
                return ansewer;
            }
        }

        public tbDocumentos Find(int? id)
        {
            tbDocumentos result = new tbDocumentos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@docu_Id", id);
                result = db.QueryFirst<tbDocumentos>(ScriptsDataBase.BuscarDocumento, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbDocumentos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("docu_Tipo", item.docu_Tipo);
                parameter.Add("@docu_Descripcion", item.docu_Descripcion);
                parameter.Add("@docu_Ruta", item.docu_Ruta);
                parameter.Add("docu_Fecha", item.docu_Fecha);
                parameter.Add("empl_Id", item.empl_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@docu_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.InsertarDocumento, parameter, commandType: CommandType.StoredProcedure);
                
                return result;
            }
        }

        public IEnumerable<tbDocumentos> List(int? id)
        {
            List<tbDocumentos> result = new List<tbDocumentos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("proy_Id", id);

                result = db.Query<tbDocumentos>(ScriptsDataBase.ListarDocumentos, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbDocumentos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@docu_Id", item.docu_Id);
                parameter.Add("docu_Tipo", item.docu_Tipo);
                parameter.Add("@docu_Descripcion", item.docu_Descripcion);
                parameter.Add("@docu_Ruta", item.docu_Ruta);
                parameter.Add("docu_Fecha", item.docu_Fecha);
                parameter.Add("empl_Id", item.empl_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@docu_FechaModificacion", item.docu_FechaModificacion);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.ActualizarDocumento, parameter, commandType: CommandType.StoredProcedure);

                return ansewer;
            }
        }
    }
}
