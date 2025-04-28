using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class ClienteRepository : IRepository<tbClientes>
    {
        
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@clie_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarClientes,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbClientes Find(int? id)
        {
            tbClientes result = new tbClientes();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@clie_Id", id);
                result = db.QueryFirst<tbClientes>(ScriptsDataBase.BuscarClientes, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbClientes item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@clie_DNI", item.clie_DNI);
                parameter.Add("@clie_Nombre", item.clie_Nombre);
                parameter.Add("@clie_Apellido", item.clie_Apellido);
                parameter.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico);
                parameter.Add("@clie_Telefono", item.clie_Telefono);
                parameter.Add("@clie_FechaNacimiento", item.clie_FechaNacimiento);
                parameter.Add("@clie_Sexo", item.clie_Sexo);
                parameter.Add("@clie_DireccionExacta", item.clie_DireccionExacta);
                parameter.Add("@ciud_Id", item.ciud_Id);
                parameter.Add("@civi_Id", item.civi_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@clie_FechaCreacion", item.clie_FechaCreacion);
                parameter.Add("@clie_Tipo", item.clie_Tipo);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarClientes, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbClientes> List()
        {
            List<tbClientes> result = new List<tbClientes>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbClientes>(ScriptsDataBase.ListarClientes, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbClientes item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@clie_Id", item.clie_Id);
                parameter.Add("@clie_DNI", item.clie_DNI);
                parameter.Add("@clie_Nombre", item.clie_Nombre);
                parameter.Add("@clie_Apellido", item.clie_Apellido);
                parameter.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico);
                parameter.Add("@clie_Telefono", item.clie_Telefono);
                parameter.Add("@clie_FechaNacimiento", item.clie_FechaNacimiento);
                parameter.Add("@clie_Sexo", item.clie_Sexo);
                parameter.Add("@clie_DireccionExacta", item.clie_DireccionExacta);
                parameter.Add("@ciud_Id", item.ciud_Id);
                parameter.Add("@civi_Id", item.civi_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@clie_FechaModificacion", item.clie_FechaModificacion);
                parameter.Add("@clie_Tipo", item.clie_Tipo);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarClientes, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
