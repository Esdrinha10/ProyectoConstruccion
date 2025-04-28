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
    public class IncidenteRepository : IRepository<tbIncidentes>
    {
        
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inci_Id", id);

                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }


        public IEnumerable<tbIncidentes> ListarIncidentesPorProyecto(int proy_Id)
        {
            List<tbIncidentes> result = new List<tbIncidentes>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Id", proy_Id);


                result = db.Query<tbIncidentes>(ScriptsDataBase.ListarIncidentesPorProyecto, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbIncidentes> ListarProyectosConIncidentes()
        {
            List<tbIncidentes> result = new List<tbIncidentes>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbIncidentes>(ScriptsDataBase.ListarProyectosPorIncidente, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        public tbIncidentes Find(int? id)
        {
            tbIncidentes result = new tbIncidentes();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inci_Id", id);
                result = db.QueryFirst<tbIncidentes>(ScriptsDataBase.BuscarIncidente, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public tbIncidentes FiltrarIncidencias(int? id)
        {
            tbIncidentes result = new tbIncidentes();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.QueryFirst<tbIncidentes>(ScriptsDataBase.IncidentesPorActividadPorEtapa, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbIncidentes item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inci_Descripcion", item.inci_Descripcion);
                parameter.Add("@inci_Fecha", item.inci_Fecha);
                parameter.Add("@inci_Costo", item.inci_Costo);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@inci_FechaCreacion", item.inci_FechaCreacion);
                parameter.Add("@imin_Imagen", item.imin_Imagen);
                parameter.Add("@imin_FechaCreacion", item.imin_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbIncidentes> Listar(int id)
        {
            List<tbIncidentes> result = new List<tbIncidentes>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.Query<tbIncidentes>(ScriptsDataBase.ListarIncidentes, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbIncidentes item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inci_Id", item.inci_Id);
                parameter.Add("@inci_Descripcion", item.inci_Descripcion);
                parameter.Add("@inci_Fecha", item.inci_Fecha);
                parameter.Add("@inci_Costo", item.inci_Costo);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@inci_FechaModificacion", item.inci_FechaModificacion);
                parameter.Add("@imin_Imagen", item.imin_Imagen);
                parameter.Add("@imin_FechaModificacion", item.imin_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbIncidentes> List()
        {
            throw new NotImplementedException();
        }
    }
    }
