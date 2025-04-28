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
    public class BodegaRepository : IRepository<tbBodegas>
    {
        /// <summary>
        /// Elimina una bodega por su ID.
        /// </summary>
        /// <param name="id">ID de la bodega a eliminar</param>
        /// <returns>Estado de la solicitud de eliminación</returns>
        public RequestStatus Delete(int? id)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parametro = new DynamicParameters();

                // Añadimos el parámetro "bode_Id" con el valor del ID proporcionado
                parametro.Add("bode_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Bodega" y obtenemos el primer resultado como RequestStatus
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarBodega,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }

        /// <summary>
        /// Busca una bodega por su ID.
        /// </summary>
        /// <param name="id">ID de la bodega a buscar</param>
        /// <returns>La bodega encontrada</returns>
        public tbBodegas Find(int? id)
        {
            tbBodegas result = new tbBodegas();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_Bodega" y obtenemos el primer resultado como tbBodegas
                result = db.QueryFirst<tbBodegas>(ScriptsDataBase.BuscarBodega, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Busca una bodega por su ID.
        /// </summary>
        /// <param name="id">ID de la bodega a buscar</param>
        /// <returns>Los equipos de seguridad y Insumos encontrados</returns>
        public IEnumerable<tbBodegas> FindInsumosEquiposSeguridad(int? id)
        {
            List<tbBodegas> result = new List<tbBodegas>();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_Bodega" y obtenemos el primer resultado como tbBodegas

                result = db.Query<tbBodegas>(ScriptsDataBase.BuscarInsumosEquiposSeguridad, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        /// <summary>
        /// Inserta una nueva bodega.
        /// </summary>
        /// <param name="item">Objeto tbBodegas a insertar</param>
        /// <returns>Estado de la solicitud de inserción</returns>
        public virtual RequestStatus Insert(tbBodegas item)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Descripcion", item.bode_Descripcion);
                parameter.Add("@bode_Latitud", item.bode_Latitud);
                parameter.Add("@bode_Longitud", item.bode_Longitud);
                parameter.Add("@bode_LinkUbicacion", item.bode_LinkUbicacion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@bode_FechaCreacion", DateTime.Now);

                // Ejecutamos el procedimiento almacenado "Insertar_Bodega" y obtenemos el primer resultado como int
                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarBodega, parameter, commandType: CommandType.StoredProcedure);

                // Generamos un mensaje basado en el resultado de la inserción
                string mensaje = respuesta > 0 ? "Insertado con Éxito" : "El registro ya existe";

                // Devolvemos el estado de la solicitud de inserción
                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }

        /// <summary>
        /// Lista todas las bodegas.
        /// </summary>
        /// <returns>Enumerable de tbBodegas</returns>
        public IEnumerable<tbBodegas> List()
        {
            List<tbBodegas> result = new List<tbBodegas>();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos el procedimiento almacenado "Listar_Bodegas" y obtenemos los resultados como IEnumerable de tbBodegas
                result = db.Query<tbBodegas>(ScriptsDataBase.ListarBodegas, commandType: CommandType.Text).ToList();
                return result;
            }
        }


        public IEnumerable<tbBodegas> BuscarBodegaInsumos(int? id, int bode)
        {
            List<tbBodegas> result = new List<tbBodegas>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", id);
                parameter.Add("@bode_Id", bode);
                result = db.Query<tbBodegas>(ScriptsDataBase.ListarBodegaInsumos, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza una bodega existente.
        /// </summary>
        /// <param name="item">Objeto tbBodegas con los datos actualizados</param>
        /// <returns>Estado de la solicitud de actualización</returns>
        public virtual RequestStatus Update(tbBodegas item)
        {
            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", item.bode_Id);
                parameter.Add("@bode_Descripcion", item.bode_Descripcion);
                parameter.Add("@bode_Latitud", item.bode_Latitud);
                parameter.Add("@bode_Longitud", item.bode_Longitud);
                parameter.Add("@bode_LinkUbicacion", item.bode_LinkUbicacion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@bode_FechaModificiacion", item.bode_FechaModificiacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_Bodega" y obtenemos el primer resultado como int
                var result = db.QueryFirst<int>(ScriptsDataBase.ActualizarBodega, parameter, commandType: CommandType.StoredProcedure);

                // Generamos un mensaje basado en el resultado de la actualización
                string mensaje = result > 0 ? "Actualizado con Éxito" : result == 0 ? "El registro no se pudo encontrar" : "Comuníquese con un Administrador";

                // Devolvemos el estado de la solicitud de actualización
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
