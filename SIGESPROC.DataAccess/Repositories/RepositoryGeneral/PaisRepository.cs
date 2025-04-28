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
    public class PaisRepository : IRepository<tbPaises>
    {
        /// <summary>
        /// Elimina un país por su ID.
        /// </summary>
        /// <param name="id">ID del país a eliminar</param>
        /// <returns>Estado de la solicitud de eliminación</returns>
        public RequestStatus Delete(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();

                // Añadimos el parámetro "pais_Id" con el valor del ID proporcionado
                parametro.Add("@pais_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Pais" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarPais,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }

        /// <summary>
        /// Busca un país por su ID.
        /// </summary>
        /// <param name="id">ID del país a buscar</param>
        /// <returns>El país encontrado</returns>
        public tbPaises Find(int? id)
        {
            tbPaises result = new tbPaises();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@pais_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_Pais" y obtenemos el primer resultado como tbPaises
                result = db.QueryFirst<tbPaises>(ScriptsDataBase.BuscarPais, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo país.
        /// </summary>
        /// <param name="item">Objeto tbPaises a insertar</param>
        /// <returns>Estado de la solicitud de inserción</returns>
        public virtual RequestStatus Insert(tbPaises item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@pais_Nombre", item.pais_Nombre);
                parameter.Add("@pais_Codigo", item.pais_Codigo);
                parameter.Add("@pais_Prefijo", item.pais_Prefijo);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pais_FechaCreacion", item.pais_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_Pais" y obtenemos el primer resultado como int
                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarPais, parameter, commandType: CommandType.StoredProcedure);

                // Verificamos el resultado y retornamos el estado adecuado
                string mensaje;
                switch (respuesta)
                {
                    case 1:
                        mensaje = "Insertado con éxito";
                        break;
                    case -1:
                        mensaje = "El nombre del país ya existe";
                        break;
                    case -2:
                        mensaje = "El prefijo del país ya existe";
                        break;
                    case -3:
                        mensaje = "El código del país ya existe";
                        break;
                    default:
                        mensaje = "Error desconocido";
                        break;
                }

                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }

        /// <summary>
        /// Lista todos los países.
        /// </summary>
        /// <returns>Enumerable de tbPaises</returns>
        public IEnumerable<tbPaises> List()
        {
            List<tbPaises> result = new List<tbPaises>();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos el procedimiento almacenado "Listar_Paises" y obtenemos los resultados como IEnumerable de tbPaises
                result = db.Query<tbPaises>(ScriptsDataBase.ListarPaises, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista los países para un dropdown.
        /// </summary>
        /// <returns>Enumerable de tbPaises</returns>
        public IEnumerable<tbPaises> DropDownPaises()
        {
            List<tbPaises> result = new List<tbPaises>();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos el procedimiento almacenado "DropDown_Paises" y obtenemos los resultados como IEnumerable de tbPaises
                result = db.Query<tbPaises>(ScriptsDataBase.DropDownPaises, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza un país existente.
        /// </summary>
        /// <param name="item">Objeto tbPaises con los datos actualizados</param>
        /// <returns>Estado de la solicitud de actualización</returns>
        public virtual RequestStatus Update(tbPaises item)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@pais_Id", item.pais_Id);
                parameter.Add("@pais_Nombre", item.pais_Nombre);
                parameter.Add("@pais_Codigo", item.pais_Codigo);
                parameter.Add("@pais_Prefijo", item.pais_Prefijo);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pais_FechaModificacion", item.pais_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_Pais" y obtenemos el primer resultado como int
                var result = db.QueryFirst<int>(ScriptsDataBase.ActualizarPais, parameter, commandType: CommandType.StoredProcedure);

                // Verificamos el resultado y retornamos el estado adecuado
                string mensaje;
                switch (result)
                {
                    case 1:
                        mensaje = "Insertado con éxito";
                        break;
                    case -1:
                        mensaje = "El nombre del país ya existe";
                        break;
                    case -2:
                        mensaje = "El código del país ya existe";
                        break;
                    case -3:
                        mensaje = "El prefijo del país ya existe";
                        break;
                    default:
                        mensaje = "Error desconocido";
                        break;
                }

                // Devolvemos el estado de la solicitud de actualización
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
