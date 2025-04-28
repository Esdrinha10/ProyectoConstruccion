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
    public class EstadoProyectoRepository : IRepository<tbEstadosProyectos>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@espr_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_EstadosDeProyecto" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEstadoProyecto, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public tbEstadosProyectos Find(int? id)
        {
            tbEstadosProyectos result = new tbEstadosProyectos();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@espr_Id", id);
                // Ejecutamos el procedimiento almacenado "Buscar_EstadosDeProyecto" y obtenemos el primer resultado como Entitie
                result = db.QueryFirst<tbEstadosProyectos>(ScriptsDataBase.BuscarEstadoProyecto, parameter, commandType: CommandType.StoredProcedure);
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public virtual RequestStatus Insert(tbEstadosProyectos item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@espr_Descripcion", item.espr_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@espr_FechaCreacion", item.espr_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_EstadoDeProyecto" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEstadoProyecto, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public IEnumerable<tbEstadosProyectos> List()
        {
            List<tbEstadosProyectos> result = new List<tbEstadosProyectos>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_EstadosDeProyectos" y obtenemos el resultado como IEnumerable
                result = db.Query<tbEstadosProyectos>(ScriptsDataBase.ListarEstadosProyectos, commandType: CommandType.Text).ToList();
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public virtual RequestStatus Update(tbEstadosProyectos item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@espr_Id", item.espr_Id);
                parameter.Add("@espr_Descripcion", item.espr_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@espr_FechaModificacion", item.espr_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_EstadosDeProyecto" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEstadoProyecto, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }
    }
}
