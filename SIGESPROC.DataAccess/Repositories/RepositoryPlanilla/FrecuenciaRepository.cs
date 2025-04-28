using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using SIGESPROC.DataAccess.Context;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class FrecuenciaRepository : IRepository<tbFrecuencias>
    {
        // Método para eliminar una frecuencia usando su ID
        public RequestStatus Delete(int? id)
        {
            // Conexión con la base de datos
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Crear objeto para manejar los parámetros
                var parametro = new DynamicParameters();

                // Añadir el ID de la frecuencia a eliminar
                parametro.Add("frec_Id", id);

                // Ejecutar el procedimiento almacenado para eliminar la frecuencia y obtener el resultado
                var result = db.QueryFirst<RequestStatus>("[Nomi].[SP_Frecuencia_Eliminar]",
                    parametro,
                    commandType: CommandType.StoredProcedure);

                // Devolver el resultado de la operación
                return result;
            }
        }

        // Método para encontrar una frecuencia por su ID
        public tbFrecuencias Find(int? id)
        {
            tbFrecuencias result = new tbFrecuencias();

            // Conexión con la base de datos
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Crear objeto para manejar los parámetros
                var parameter = new DynamicParameters();
                parameter.Add("@frec_Id", id);

                // Ejecutar el procedimiento almacenado para buscar la frecuencia y obtener el resultado
                result = db.QueryFirst<tbFrecuencias>(ScriptsDataBase.BuscarFrecuencia, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        // Método para insertar una nueva frecuencia
        public virtual RequestStatus Insert(tbFrecuencias item)
        {
            RequestStatus result = new RequestStatus();

            // Conexión con la base de datos
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Crear objeto para manejar los parámetros
                var parameter = new DynamicParameters();
                parameter.Add("@frec_Descripcion", item.frec_Descripcion);
                parameter.Add("@frec_NumeroDias", item.frec_NumeroDias);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@frec_FechaCreacion", item.frec_FechaCreacion);

                // Ejecutar el procedimiento almacenado para insertar la frecuencia y obtener el resultado
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarFrecuencia, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        // Método para listar todas las frecuencias
        public IEnumerable<tbFrecuencias> List()
        {
            List<tbFrecuencias> result = new List<tbFrecuencias>();

            // Conexión con la base de datos
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutar el procedimiento almacenado para listar las frecuencias y obtener el resultado
                result = db.Query<tbFrecuencias>(ScriptsDataBase.ListarFrecuencias, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        // Método para actualizar una frecuencia existente
        public virtual RequestStatus Update(tbFrecuencias item)
        {
            RequestStatus result = new RequestStatus();

            // Conexión con la base de datos
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Crear objeto para manejar los parámetros
                var parametro = new DynamicParameters();
                parametro.Add("@frec_Id", item.frec_Id);
                parametro.Add("@frec_Descripcion", item.frec_Descripcion);
                parametro.Add("@frec_NumeroDias", item.frec_NumeroDias);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@frec_FechaModificacion", item.frec_FechaModificacion);

                // Ejecutar el procedimiento almacenado para actualizar la frecuencia y obtener el resultado
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarFrecuencia, parametro, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
