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
    public class MaterialRepository : IRepository<tbMateriales>
    {
        /// <summary>
        /// Elimina un material por su ID.
        /// </summary>
        /// <param name="id">ID del material a eliminar</param>
        /// <returns>Estado de la solicitud de eliminación</returns>
        public RequestStatus Delete(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();

                // Añadimos el parámetro "mate_Id" con el valor del ID proporcionado
                parametro.Add("mate_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Material" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Eliminar_Material,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }

        /// <summary>
        /// Busca un material por su ID.
        /// </summary>
        /// <param name="id">ID del material a buscar</param>
        /// <returns>El material encontrado</returns>
        public tbMateriales Find(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();
                parametro.Add("mate_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_Material" y obtenemos el primer resultado como tbMateriales
                var result = db.QueryFirst<tbMateriales>(ScriptsDataBase.Buscar_Material,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Devolvemos el material encontrado
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo material.
        /// </summary>
        /// <param name="item">Objeto tbMateriales a insertar</param>
        /// <returns>Estado de la solicitud de inserción</returns>
        public RequestStatus Insert(tbMateriales item)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();
                parametro.Add("mate_Descripcion", item.mate_Descripcion);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("mate_FechaCreacion", DateTime.Now);

                // Ejecutamos el procedimiento almacenado "Insertar_Material" y obtenemos el primer resultado como int
                var result = db.QueryFirst<int>(ScriptsDataBase.Insertar_Material,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Generamos un mensaje basado en el resultado de la inserción
                string mensaje = result > 0 ? "Insertado con Éxito" : "Ese registro ya existe";

                // Devolvemos el estado de la solicitud de inserción
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        /// <summary>
        /// Lista todos los materiales.
        /// </summary>
        /// <returns>Enumerable de tbMateriales</returns>
        public IEnumerable<tbMateriales> List()
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos el procedimiento almacenado "Listar_Materiales" y obtenemos los resultados como IEnumerable de tbMateriales
                var result = db.Query<tbMateriales>(ScriptsDataBase.Listar_Materiales,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                // Devolvemos la lista de materiales
                return result;
            }
        }

        /// <summary>
        /// Actualiza un material existente.
        /// </summary>
        /// <param name="item">Objeto tbMateriales con los datos actualizados</param>
        /// <returns>Estado de la solicitud de actualización</returns>
        public RequestStatus Update(tbMateriales item)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();
                parametro.Add("mate_Id", item.mate_Id);
                parametro.Add("mate_Descripcion", item.mate_Descripcion);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("mate_FechaModificacion", DateTime.Now);

                // Ejecutamos el procedimiento almacenado "Actualizar_Material" y obtenemos el primer resultado como int
                var result = db.QueryFirst<int>(ScriptsDataBase.Actualizar_Material,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Generamos un mensaje basado en el resultado de la actualización
                string mensaje = result > 0 ? "Actualizado con Éxito" : result == 0 ? "El registro no se pudo encontrar" : "Comuníquese con un Administrador";

                // Devolvemos el estado de la solicitud de actualización
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
