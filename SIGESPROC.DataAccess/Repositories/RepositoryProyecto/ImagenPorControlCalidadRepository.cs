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
    public class ImagenPorControlCalidadRepository : IRepository<tbImagenesPorControlesDeCalidades>
    {
        public IEnumerable<tbImagenesPorControlesDeCalidades> List1(int id)
        {
            List<tbImagenesPorControlesDeCalidades> result = new List<tbImagenesPorControlesDeCalidades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coca_Id", id);

                result = db.Query<tbImagenesPorControlesDeCalidades>(ScriptsDataBase.ListarImagenesPorControlCalidades, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@icca_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarImagenPorControlCalidad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public virtual RequestStatus Insert(tbImagenesPorControlesDeCalidades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@icca_Imagen", item.icca_Imagen);
                parameter.Add("@coca_Id", item.coca_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@icca_FechaCreacion", item.icca_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarImagenPorControlCalidad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public tbImagenesPorControlesDeCalidades Find(int? id)
        {
            tbImagenesPorControlesDeCalidades result = new tbImagenesPorControlesDeCalidades();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@icca_Id", id);
                result = db.QueryFirst<tbImagenesPorControlesDeCalidades>(ScriptsDataBase.BuscarImagenPorControlCalidad, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Update(tbImagenesPorControlesDeCalidades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@icca_Id", item.icca_Id);
                parameter.Add("@icca_Imagen", item.icca_Imagen);
                parameter.Add("@icca_Descripcion", item.icca_Descripcion);
                parameter.Add("@coac_Id", item.coac_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@icca_FechaModificacion", item.icca_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImagenPorControlCalidad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbImagenesPorControlesDeCalidades> List()
        {
            throw new NotImplementedException();
        }
    }
}
