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
    public class NotificacionRepository : IRepository<tbNotificaciones>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@noti_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarNotificacion, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public IEnumerable<tbNotificaciones> Find(int? id)
        {
            List<tbNotificaciones> result = new List<tbNotificaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@noti_Id", id);
                result = db.Query<tbNotificaciones>(ScriptsDataBase.BuscarNotificacion, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public tbNotificaciones Contar()
        {
            tbNotificaciones result = new tbNotificaciones();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.QueryFirst<tbNotificaciones>(ScriptsDataBase.ContarNotificacion,  commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbNotificaciones item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@noti_Descripcion", item.noti_Descripcion);
                parameter.Add("@noti_Fecha", item.noti_Fecha);
                parameter.Add("@noti_Ruta", item.noti_Ruta);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@noti_FechaCreacion", item.noti_FechaCreacion);
                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarNotificacion, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = respuesta > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }

       

        public IEnumerable<tbNotificaciones> List()
        {
            List<tbNotificaciones> result = new List<tbNotificaciones>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNotificaciones>(ScriptsDataBase.ListarNotificaciones, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbNotificaciones> List2()
        {
            List<tbNotificaciones> result = new List<tbNotificaciones>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNotificaciones>(ScriptsDataBase.ListarNotificaciones2, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbNotificaciones> ListTipos()
        {
            List<tbNotificaciones> result = new List<tbNotificaciones>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNotificaciones>(ScriptsDataBase.ListarTiposNotificaciones, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbNotificaciones item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@noti_Id", item.noti_Id);
                parameter.Add("@noti_Descripcion", item.noti_Descripcion);
                parameter.Add("@noti_Fecha", item.noti_Fecha);
                parameter.Add("@noti_Leida", item.noti_Leida);
                parameter.Add("@noti_Tipo", item.noti_Tipo);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@noti_FechaModificacion", item.noti_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarNotificacion, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        tbNotificaciones IRepository<tbNotificaciones>.Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
