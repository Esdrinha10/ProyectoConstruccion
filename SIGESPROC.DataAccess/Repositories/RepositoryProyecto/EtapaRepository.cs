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
    public class EtapaRepository : IRepository<tbEtapas>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etap_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Etapas" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEtapa, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

        public tbEtapas Find(int? id)
        {
            tbEtapas result = new tbEtapas();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etap_Id", id);
                // Ejecutamos el procedimiento almacenado "Buscar_Etapas" y obtenemos el primer resultado como Entitie
                result = db.QueryFirst<tbEtapas>(ScriptsDataBase.BuscarEtapa, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public tbEtapas BuscarPorNombre(string? etap_Descripcion)
        {
            tbEtapas result = new tbEtapas();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etap_Descripcion", etap_Descripcion);
                result = db.QueryFirst<tbEtapas>(ScriptsDataBase.BuscarEtapaPorNombre, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbEtapas item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etap_Descripcion", item.etap_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@etap_FechaCreacion", item.etap_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_Etapas" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEtapa, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = ansewer > 0 ? "Insertado con Éxito" : "Ese registro ya existe";

                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbEtapas> List()
        {
            List<tbEtapas> result = new List<tbEtapas>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_Etapas" y obtenemos el resultado como IEnumerable
                result = db.Query<tbEtapas>(ScriptsDataBase.ListarEtapas, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbEtapas item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etap_Id", item.etap_Id);
                parameter.Add("@etap_Descripcion", item.etap_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@etap_FechaModificacion", item.etap_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_Etapas" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEtapa, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
