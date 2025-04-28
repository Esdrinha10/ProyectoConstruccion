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
    public class TasaCambioRepository : IRepository<tbTasasCambio>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@taca_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_TasadeCambio" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarTasaCambio, parameter, commandType: CommandType.StoredProcedure);
      
                return ansewer;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public tbTasasCambio Find(int? id)
        {
            tbTasasCambio result = new tbTasasCambio();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@taca_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_TasadeCambio" y obtenemos el primer resultado como Entitie
                result = db.QueryFirst<tbTasasCambio>(ScriptsDataBase.BuscarTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public virtual RequestStatus Insert(tbTasasCambio item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@mone_A", item.mone_A);
                parameter.Add("@mone_B", item.mone_B);
                parameter.Add("@taca_ValorA", item.taca_ValorA);
                parameter.Add("@taca_ValorB", item.taca_ValorB);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@taca_FechaCreacion", item.taca_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_TasadeCambio" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }


        public IEnumerable<tbTasasCambio> List()
        {
            List<tbTasasCambio> result = new List<tbTasasCambio>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_TasadeCambio" y obtenemos el resultado como IEnumerable
                result = db.Query<tbTasasCambio>(ScriptsDataBase.ListarTasaCambios, commandType: CommandType.Text).ToList();
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }
        public IEnumerable<tbTasasCambio> ObtenerConversionesTasasCambio(int id)
            {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@mone_A", id);

                // Ejecutamos el procedimiento almacenado "ObtenerConversion_TasadeCambio" y obtenemos devolvemos el resultado como IEnumerable
                return db.Query<tbTasasCambio>(ScriptsDataBase.ObtenerConversionTasasCambio, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual RequestStatus Update(tbTasasCambio item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@taca_Id", item.taca_Id);
                parameter.Add("@mone_A", item.mone_A);
                parameter.Add("@mone_B", item.mone_B);
                parameter.Add("@taca_ValorA", item.taca_ValorA);
                parameter.Add("@taca_ValorB", item.taca_ValorB);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@taca_FechaModificacion", item.taca_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_TasadeCambio" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarTasaCambio, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }
    }
}
