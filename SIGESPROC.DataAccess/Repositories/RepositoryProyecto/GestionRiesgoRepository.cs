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
    public class GestionRiesgoRepository : IRepository<tbGestionRiesgos>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@geri_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarGestionRiesgo, parameter, commandType: CommandType.StoredProcedure);

                return ansewer;
            }
        }

        public virtual RequestStatus Insert(tbGestionRiesgos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@geri_Descripcion", item.geri_Descripcion);
                parameter.Add("@geri_Impacto", item.geri_Impacto);
                parameter.Add("@geri_Probabilidad", item.geri_Probabilidad);
                parameter.Add("@geri_Mitigacion", item.geri_Mitigacion);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@geri_FechaCreacion", DateTime.Now);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.InsertarGestionRiesgo, parameter, commandType: CommandType.StoredProcedure);

                return ansewer;
            }
        }
        public tbGestionRiesgos Find(int? id)
        {
            tbGestionRiesgos result = new tbGestionRiesgos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                parameter.Add("@proy_Id", id);

                result = db.QueryFirst<tbGestionRiesgos>(ScriptsDataBase.BuscarGestionRiesgo, parameter, commandType: CommandType.StoredProcedure);
                
                return result;
            }
        }

        public virtual RequestStatus Update(tbGestionRiesgos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@geri_Id", item.geri_Id);
                parameter.Add("@geri_Descripcion", item.geri_Descripcion);
                parameter.Add("@geri_Impacto", item.geri_Impacto);
                parameter.Add("@geri_Probabilidad", item.geri_Probabilidad);
                parameter.Add("@geri_Mitigacion", item.geri_Mitigacion);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@geri_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.ActualizarGestionRiesgo, parameter, commandType: CommandType.StoredProcedure);
                
                return ansewer;
            }
        }

        public IEnumerable<tbGestionRiesgos> List(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("proy_Id", id);

                var result = db.Query<tbGestionRiesgos>(ScriptsDataBase.Listar_GestionRiesgos, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<tbGestionRiesgos> List()
        {
            throw new NotImplementedException();
        }
    }
}
