using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    public class MaquinariaRepository : IRepository<tbMaquinarias>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado

                parameter.Add("@maqu_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Maquinaria" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarMaquinaria, parameter, commandType: CommandType.StoredProcedure);
                return result; // Devolvemos el resultado de la ejecución del procedimiento almacenado

            }
        }

        public tbMaquinarias Find(int? id)
        {
            tbMaquinarias result = new tbMaquinarias();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@maqu_Id", id);
                // Ejecutamos el procedimiento almacenado "Buscar_Maquinaria" y obtenemos el primer resultado como Entitie
                result = db.QueryFirst<tbMaquinarias>(ScriptsDataBase.BuscarMaquinaria, parameter, commandType: CommandType.StoredProcedure);
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public RequestStatus Insert(tbMaquinarias item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado

                parameter.Add("@maqu_Descripcion", item.maqu_Descripcion);
                parameter.Add("@maqu_UltimoPrecioUnitario", item.maqu_UltimoPrecioUnitario);
                parameter.Add("@nive_Id", item.nive_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@maqu_FechaCreacion", DateTime.Now);

                // Ejecutamos el procedimiento almacenado "Insertar_Maquinaria" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarMaquinaria, parameter, commandType: CommandType.StoredProcedure);

                /*Agregar msj de exito*/
                string mensaje = ansewer > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbMaquinarias> List()
        {
            List<tbMaquinarias> result = new List<tbMaquinarias>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_Maquinaria" y obtenemos el resultado como IEnumerable
                result = db.Query<tbMaquinarias>(ScriptsDataBase.ListarMaquinarias, commandType: CommandType.Text).ToList();
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public RequestStatus Update(tbMaquinarias item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@maqu_Id", item.maqu_Id);
                parameter.Add("@maqu_Descripcion", item.maqu_Descripcion);
                parameter.Add("@maqu_UltimoPrecioUnitario", item.maqu_UltimoPrecioUnitario);
                parameter.Add("@nive_Id", item.nive_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@maqu_FechaModificacion", item.maqu_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_Maquinaria" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarMaquinaria, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }
    }
}
