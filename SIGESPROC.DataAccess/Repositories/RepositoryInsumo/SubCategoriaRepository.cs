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
    // Repositorio para manejar operaciones de CRUD en la entidad de subcategorías
    public class SubCategoriaRepository : IRepository<tbSubcategorias>
    {
        // Método para eliminar una subcategoría por su ID
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus(); // Inicializa el estado de la solicitud
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos usando la cadena de conexión definida en SIGESPROC
            {
                var parameter = new DynamicParameters(); // Crea un objeto para almacenar los parámetros del procedimiento almacenado
                parameter.Add("@suca_Id", id); // Agrega el parámetro del ID de la subcategoría a eliminar

                // Ejecuta el procedimiento almacenado para eliminar la subcategoría y obtiene el resultado
                var queryResult = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarSubCategoria, parameter, commandType: CommandType.StoredProcedure);

             

                return queryResult; // Devuelve el estado de la solicitud
            }
        }

        // Método para encontrar una subcategoría por su ID
        public tbSubcategorias Find(int? id)
        {
            tbSubcategorias result = new tbSubcategorias(); // Inicializa un nuevo objeto de subcategoría

            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos usando la cadena de conexión definida en SIGESPROC
            {
                var parameter = new DynamicParameters(); // Crea un objeto para almacenar los parámetros del procedimiento almacenado
                parameter.Add("@suca_Id", id); // Agrega el parámetro del ID de la subcategoría a buscar

                // Ejecuta el procedimiento almacenado para encontrar la subcategoría y asigna el resultado al objeto result
                result = db.QueryFirst<tbSubcategorias>(ScriptsDataBase.BuscarSubCategoria, parameter, commandType: CommandType.StoredProcedure);

                return result; // Devuelve la subcategoría encontrada
            }
        }

        // Método para insertar una nueva subcategoría
        public RequestStatus Insert(tbSubcategorias item)
        {
            RequestStatus result = new RequestStatus(); // Inicializa el estado de la solicitud
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos usando la cadena de conexión definida en SIGESPROC
            {
                var parameter = new DynamicParameters(); // Crea un objeto para almacenar los parámetros del procedimiento almacenado
                //asignacion de parametros correspondientes al procedimiento almacenado referenciado
                parameter.Add("@suca_Descripcion", item.suca_Descripcion);
                parameter.Add("@cate_Id", item.cate_Id); 
                parameter.Add("@usua_Creacion", item.usua_Creacion); 
                parameter.Add("@suca_FechaCreacion", item.suca_FechaCreacion); 

                // Ejecuta el procedimiento almacenado para insertar la subcategoría y obtiene el resultado
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarSubCategoria, parameter, commandType: CommandType.StoredProcedure);

                // Asigna el código de estado del resultado al objeto result
                string mensaje = ansewer > 0 ? "Insertado con Éxito" : "Ese registro ya existe";

                // Devolvemos el estado de la solicitud de inserción
                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }

        // Método para listar todas las subcategorías
        public IEnumerable<tbSubcategorias> List()
        {
            List<tbSubcategorias> result = new List<tbSubcategorias>(); // Inicializa una lista para almacenar los resultados
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos usando la cadena de conexión definida en SIGESPROC
            {
                // Ejecuta la consulta para obtener todas las subcategorías y asigna los resultados a la lista result
                result = db.Query<tbSubcategorias>(ScriptsDataBase.ListarSubCategorias, commandType: CommandType.Text).ToList();
                return result; // Devuelve la lista de subcategorías
            }
        }

        // Método para listar las subcategorías por categoría
        public IEnumerable<tbSubcategorias> ListPorCategoria(int id)
        {
            List<tbSubcategorias> result = new List<tbSubcategorias>(); // Inicializa una lista para almacenar los resultados
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos usando la cadena de conexión definida en SIGESPROC
            {
                var parameter = new DynamicParameters(); // Crea un objeto para almacenar los parámetros del procedimiento almacenado
                parameter.Add("@cate_Id", id); // Agrega el parámetro del ID de la categoría

                // Ejecuta el procedimiento almacenado para obtener las subcategorías de una categoría específica y asigna los resultados a la lista result
                result = db.Query<tbSubcategorias>(ScriptsDataBase.MostrarSubcategoriasPorCategorias, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Devuelve la lista de subcategorías
            }
        }

        // Método para actualizar una subcategoría existente
        public RequestStatus Update(tbSubcategorias item)
        {
            RequestStatus result = new RequestStatus(); // Inicializa el estado de la solicitud
            using (var db = new SqlConnection(SIGESPROC.ConnectionString)) // Abre una conexión con la base de datos 
            {

                var parameter = new DynamicParameters();
                //asignacion de parametros correspondientes al procedimiento almacenado referenciado

                parameter.Add("@suca_Id", item.suca_Id); 
                parameter.Add("@suca_Descripcion", item.suca_Descripcion); 
                parameter.Add("@cate_Id", item.cate_Id); 
                parameter.Add("@usua_Modificacion", item.usua_Modificacion); 
                parameter.Add("@suca_FechaModificacion", item.suca_FechaModificacion); 

                // Ejecuta el procedimiento almacenado para actualizar la subcategoría y obtiene el resultado
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarSubCategoria, parameter, commandType: CommandType.StoredProcedure);

                // Asigna el código de estado del resultado al objeto result
                result.CodeStatus = ansewer;
                return result; // Devuelve el estado de la solicitud
            }
        }
    }
}
