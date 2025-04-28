using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz
{
    public class AgenteBienesRaicesRepository : IRepository<tbAgentesBienesRaices>
    {
        public RequestStatus Delete(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();

                // Añadimos el parámetro "agen_Id" con el valor del ID proporcionado
                parametro.Add("agen_Id", id);

                // Ejecutamos el procedimiento almacenado "EliminarAgenteBienesRaices" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarAgenteBienesRaices,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }

        public tbAgentesBienesRaices Find(int? id)
        {
            tbAgentesBienesRaices result = new tbAgentesBienesRaices();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Añadimos el parámetro "@agen_Id" con el valor del ID proporcionado
                parameter.Add("@agen_Id", id);

                // Ejecutamos el procedimiento almacenado "BuscarAgenteBienesRaices" y obtenemos el primer resultado como tbAgentesBienesRaices
                result = db.QueryFirst<tbAgentesBienesRaices>(ScriptsDataBase.BuscarAgenteBienesRaices, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public tbAgentesBienesRaices buscar(string id)
        {
            tbAgentesBienesRaices result = new tbAgentesBienesRaices();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Añadimos el parámetro "@agen_Id" con el valor del ID proporcionado
                parameter.Add("@agen_Id", id);

                // Ejecutamos el procedimiento almacenado "BuscarAgenteBienesRaices" y obtenemos el primer resultado como tbAgentesBienesRaices
                result = db.QueryFirst<tbAgentesBienesRaices>(ScriptsDataBase.BuscarAgenteBienesRaices, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(tbAgentesBienesRaices item)
        {
            RequestStatus result = new RequestStatus();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Añadimos los parámetros necesarios para el procedimiento almacenado "InsertarAgenteBienesRaices"
                parameter.Add("@agen_DNI", item.agen_DNI);
                parameter.Add("@agen_Nombre", item.agen_Nombre);
                parameter.Add("@agen_Apellido", item.agen_Apellido);
                parameter.Add("@agen_Telefono", item.agen_Telefono);
                parameter.Add("@agen_Correo", item.agen_Correo);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@agen_FechaCreacion", item.agen_FechaCreacion);
                parameter.Add("@embr_Id", item.embr_Id);

                // Ejecutamos el procedimiento almacenado "InsertarAgenteBienesRaices" y obtenemos el primer resultado como entero
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarAgenteBienesRaices, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbAgentesBienesRaices> List()
        {
            List<tbAgentesBienesRaices> result = new List<tbAgentesBienesRaices>();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos el script "ListarAgenteBienesRaices" y obtenemos una lista de tbAgentesBienesRaices
                result = db.Query<tbAgentesBienesRaices>(ScriptsDataBase.ListarAgenteBienesRaices, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbAgentesBienesRaices item)
        {
            RequestStatus result = new RequestStatus();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Añadimos los parámetros necesarios para el procedimiento almacenado "ActualizarAgenteBienesRaices"
                parameter.Add("@agen_Id", item.agen_Id);
                parameter.Add("@agen_DNI", item.agen_DNI);
                parameter.Add("@agen_Nombre", item.agen_Nombre);
                parameter.Add("@agen_Apellido", item.agen_Apellido);
                parameter.Add("@agen_Telefono", item.agen_Telefono);
                parameter.Add("@agen_Correo", item.agen_Correo);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@agen_FechaModificacion", item.agen_FechaModificacion);
                parameter.Add("@embr_Id", item.embr_Id);

                // Ejecutamos el procedimiento almacenado "ActualizarAgenteBienesRaices" y obtenemos el primer resultado como entero
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarAgenteBienesRaices, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
