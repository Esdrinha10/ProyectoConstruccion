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
    public class EstadoCivilRepository : IRepository<tbEstadosCiviles>
    {
        
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@civi_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_EstadoCivil" y obtenemos el primer resultado como RequestStatus                                                                         
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEstadoCivil, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

        public tbEstadosCiviles Find(int? id)
        {
            tbEstadosCiviles result = new tbEstadosCiviles();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@civi_Id", id);
                // Ejecutamos el procedimiento almacenado "buscar_EstadoCivil" y obtenemos el primer resultado como tbEstadosCiviles
                result = db.QueryFirst<tbEstadosCiviles>(ScriptsDataBase.BuscarEstadoCivil, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbEstadosCiviles item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado

                parameter.Add("@civi_Descripcion", item.civi_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@civi_FechaCreacion", item.civi_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_EstadoCivil" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEstadoCivil, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_EstadoCivil" y obtenemos el resultado como IEnumerable<tbEstadosCiviles>
                result = db.Query<tbEstadosCiviles>(ScriptsDataBase.ListarEstadosCiviles, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbEstadosCiviles> DropDownEstadoCivil()
        {
            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "DropDown_EstadoCivil" y obtenemos el resultado como IEnumerable<tbEstadosCiviles>
                result = db.Query<tbEstadosCiviles>(ScriptsDataBase.DropDownEstadoCivil, commandType: CommandType.Text).ToList();
                return result;
            }

        }

            public virtual RequestStatus Update(tbEstadosCiviles item)
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@civi_Id", item.civi_Id);
                parameter.Add("@civi_Descripcion", item.civi_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@civi_FechaModificacion", item.civi_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_EstadoCivil" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEstadoCivil, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
