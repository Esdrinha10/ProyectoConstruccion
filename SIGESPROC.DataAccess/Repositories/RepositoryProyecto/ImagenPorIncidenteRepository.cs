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
    public class ImagenPorIncidenteRepository : IRepository<tbImagenesPorIncidencias>
    {
        
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@imin_Id", id);

                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarImagenPorIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public tbImagenesPorIncidencias Find(int? id)
        {
            tbImagenesPorIncidencias result = new tbImagenesPorIncidencias();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@imin_Id", id);
                result = db.QueryFirst<tbImagenesPorIncidencias>(ScriptsDataBase.BuscarImagenPorIncidente, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<tbImagenesPorIncidencias> List(int? id)
        {
            List<tbImagenesPorIncidencias> result = new List<tbImagenesPorIncidencias>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@inac_Id", id);
                result = db.Query<tbImagenesPorIncidencias>(ScriptsDataBase.BuscarImagenPorIncidente, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Insert(tbImagenesPorIncidencias item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@imin_Imagen", item.imin_Imagen);
                parameter.Add("@inci_Id", item.inci_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@imin_FechaCreacion", item.imin_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarImagenPorIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbImagenesPorIncidencias> List()
        {
            List<tbImagenesPorIncidencias> result = new List<tbImagenesPorIncidencias>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbImagenesPorIncidencias>(ScriptsDataBase.ListarImagenesPorIncidente, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbImagenesPorIncidencias item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@imin_Id", item.imin_Id);
                parameter.Add("@imin_Imagen", item.imin_Imagen);
                parameter.Add("@inci_Id", item.inci_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@imin_FechaModificacion", item.imin_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImagenPorIncidente, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }
    }
}
