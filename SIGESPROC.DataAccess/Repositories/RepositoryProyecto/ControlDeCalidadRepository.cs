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
    public class RequestStatus1
    {
        public float CodeStatus { get; set; }
        public string MessageStatus { get; set; }
        public string Message { get; internal set; }
        public bool Success { get; set; }
    }
    public class ControlDeCalidadRepository : IRepository<tbControlDeCalidadesPorActividades>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coca_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure);
                
                return ansewer;
            }
        }
        public RequestStatus Aprobar(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coca_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.AprobarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure);

                return ansewer;
            }
        }
        public tbControlDeCalidadesPorActividades Find(int? id)
        {
            tbControlDeCalidadesPorActividades result = new tbControlDeCalidadesPorActividades();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coca_Id", id);
                result = db.QueryFirst<tbControlDeCalidadesPorActividades>(ScriptsDataBase.BuscarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<tbControlDeCalidadesPorActividades> FindByActividad(int? id)
        {
            List<tbControlDeCalidadesPorActividades> result = new List<tbControlDeCalidadesPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.Query<tbControlDeCalidadesPorActividades>(ScriptsDataBase.FiltrarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus1 Insert1(tbControlDeCalidadesPorActividades item)
        {
            RequestStatus1 result = new RequestStatus1();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coca_Descripcion", item.coca_Descripcion);
                parameter.Add("@coca_Fecha", item.coca_Fecha);
                parameter.Add("@coca_Cantidadtrabajada", item.coca_CantidadTrabajada);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@coca_FechaCreacion", item.coca_FechaCreacion);

                var ansewer = db.QueryFirst<float>(ScriptsDataBase.InsertarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }    
        }

        public  IEnumerable<tbControlDeCalidadesPorActividades> List()
        {
            List<tbControlDeCalidadesPorActividades> result = new List<tbControlDeCalidadesPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbControlDeCalidadesPorActividades>(ScriptsDataBase.ListarControlDeCalidades, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbControlDeCalidadesPorActividades> ListProyectosConControlesDeCalidad()
        {
            List<tbControlDeCalidadesPorActividades> result = new List<tbControlDeCalidadesPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbControlDeCalidadesPorActividades>(ScriptsDataBase.ListarProyectosConControlesDeCalidad, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbControlDeCalidadesPorActividades> ListControlesDeCalidadPorProyectos (int proy_Id)
        {
            List<tbControlDeCalidadesPorActividades> result = new List<tbControlDeCalidadesPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Id", proy_Id);


                result = db.Query<tbControlDeCalidadesPorActividades>(ScriptsDataBase.ListarControlesDeCalidadPorProyectos, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus1 Update1(tbControlDeCalidadesPorActividades item)
        {
            RequestStatus1 result = new RequestStatus1();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@coca_Id", item.coca_Id);
                parameter.Add("@coca_Descripcion", item.coca_Descripcion);
                parameter.Add("@coca_Fecha", item.coca_Fecha);
                parameter.Add("@coca_Cantidadtrabajada", item.coca_CantidadTrabajada);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@coca_FechaModificacion", item.coca_FechaModificacion);

                var ansewer = db.QueryFirst<float>(ScriptsDataBase.ActualizarControlDeCalidades, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus Insert(tbControlDeCalidadesPorActividades item)
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbControlDeCalidadesPorActividades>.Update(tbControlDeCalidadesPorActividades item)
        {
            throw new NotImplementedException();
        }
    }
}
