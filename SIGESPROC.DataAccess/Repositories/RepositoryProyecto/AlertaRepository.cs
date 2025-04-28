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
    public class AlertaRepository : IRepository<tbAlertas>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@aler_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarAlerta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbAlertas Find(int? id)
        {
            tbAlertas result = new tbAlertas();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@aler_Id", id);
                result = db.QueryFirst<tbAlertas>(ScriptsDataBase.BuscarAlerta, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        public virtual RequestStatus Insert(tbAlertas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@aler_Fecha", item.aler_Fecha);
                parameter.Add("@aler_Descripcion", item.aler_Descripcion);
                parameter.Add("@aler_Ruta", item.aler_Ruta);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@aler_FechaCreacion", item.aler_FechaCreacion);

                // Captura el ID retornado por el procedimiento almacenado
                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarAlerta, parameter, commandType: CommandType.StoredProcedure);

                // Determina el mensaje en función del resultado
                string mensaje = respuesta > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }


        public IEnumerable<tbAlertas> List()
        {
            List<tbAlertas> result = new List<tbAlertas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbAlertas>(ScriptsDataBase.ListarAlertas, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbAlertas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@aler_Id", item.aler_Id);
                parameter.Add("@aler_Fecha", item.aler_Fecha);
                parameter.Add("@aler_Descripcion", item.aler_Descripcion);
                parameter.Add("@aler_Ruta", item.aler_Ruta);
                parameter.Add("@usua_Id", item.usua_Id);
                parameter.Add("@tian_Id", item.tian_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@aler_FechaModificacion", item.aler_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarAlerta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
