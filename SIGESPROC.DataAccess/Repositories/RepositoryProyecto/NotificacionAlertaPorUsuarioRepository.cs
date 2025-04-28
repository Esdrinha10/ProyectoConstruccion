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
    public class NotificacionAlertaPorUsuarioRepository : IRepository<tbNotificacionesAlertarPorUsuario>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@napu_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarNotiAler, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public RequestStatus Leida(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@napu_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.LeidaNotiAler, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbNotificacionesAlertarPorUsuario Find(int? id)
        {
            tbNotificacionesAlertarPorUsuario result = new tbNotificacionesAlertarPorUsuario();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", id);
                result = db.QueryFirst<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.FiltrarAlertaUsuario, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    //public tbNotificacionesAlertarPorUsuario tokenproyecto(int? id)
        //{
        //    tbNotificacionesAlertarPorUsuario result = new tbNotificacionesAlertarPorUsuario();

        //    using (var db = new SqlConnection(SIGESPROC.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@proy_Id ", id);
        //        result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.BuscarTokenPorProyecto, parameter, commandType: CommandType.StoredProcedure);
        //        return result;
        //    }
        //}
        public IEnumerable<tbNotificacionesAlertarPorUsuario> TokenProyecto(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Id", id);

                var result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.BuscarTokenPorProyecto, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public IEnumerable<tbNotificacionesAlertarPorUsuario> tokenadmin()
        {
            List<tbNotificacionesAlertarPorUsuario> result = new List<tbNotificacionesAlertarPorUsuario>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.BuscarTokenPoradministrador, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        public IEnumerable<tbNotificacionesAlertarPorUsuario> FindNoti(int? id)
        {
            List<tbNotificacionesAlertarPorUsuario> result = new List<tbNotificacionesAlertarPorUsuario>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", id);
                result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.FiltrarNotiFicacion, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbNotificacionesAlertarPorUsuario> FindTokens(int? id)
        {
            List<tbNotificacionesAlertarPorUsuario> result = new List<tbNotificacionesAlertarPorUsuario>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", id);
                result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.ListarTokensPorUsuario, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbNotificacionesAlertarPorUsuario> ListTokens()
        {
            List<tbNotificacionesAlertarPorUsuario> result = new List<tbNotificacionesAlertarPorUsuario>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbNotificacionesAlertarPorUsuario>(ScriptsDataBase.ListarTokens,  commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus InsertTokens(tbNotificacionesAlertarPorUsuario item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", item.usua_Id);
                parameter.Add("@tokn_JsonToken", item.tokn_JsonToken);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarToken, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public RequestStatus DeleteToken(int? id, string? token)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", id);
                parameter.Add("@tokn_JsonToken", token);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarToken, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public virtual RequestStatus Insert(tbNotificacionesAlertarPorUsuario item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", item.usua_Id);
                parameter.Add("@napu_AlertaOnoti", item.napu_AlertaOnoti);
                parameter.Add("@napu_AlertaONotiId", item.napu_AlertaONotiId);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@napu_FechaModificacion", item.napu_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarNotificacion, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus InsertNotificacionPorUsuario(tbNotificacionesAlertarPorUsuario item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@napu_AlertaOnoti", item.napu_AlertaOnoti);             
                parameter.Add("@napu_AlertaONotiId", item.napu_AlertaONotiId);
                parameter.Add("@usua_Id", item.usua_Id);
                parameter.Add("@napu_Leida", item.napu_Leida);
                parameter.Add("@napu_Ruta", item.napu_Ruta);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@napu_FechaCreacion", item.napu_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarNotificacionPorUsuario, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus GuardarToken(tbNotificacionesAlertarPorUsuario item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@usua_Id", item.usua_Id);
                parameter.Add("@tokn_JsonToken", item.tokn_JsonToken);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.GuardarToken, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        //public RequestStatus DeleteToken(int? id, string? token)
        //{
        //    RequestStatus result = new RequestStatus();
        //    using (var db = new SqlConnection(SIGESPROC.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@usua_Id", id);
        //        parameter.Add("@tokn_JsonToken", token);
        //        var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarToken, parameter, commandType: CommandType.StoredProcedure);
        //        result.CodeStatus = ansewer;
        //        return result;
        //    }
        //}



 
    //public IEnumerable<tbNotificaciones> List()


    public IEnumerable<tbNotificaciones> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbNotificacionesAlertarPorUsuario item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbNotificacionesAlertarPorUsuario> IRepository<tbNotificacionesAlertarPorUsuario>.List()
        {
            throw new NotImplementedException();
        }
    }
}
