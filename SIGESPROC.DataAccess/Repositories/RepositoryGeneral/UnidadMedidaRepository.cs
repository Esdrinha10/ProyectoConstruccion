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
    public class UnidadMedidaRepository : IRepository<tbUnidadesMedida>
    {
        //public RequestStatus Delete(int? id)
        //{
        //    RequestStatus result = new RequestStatus();
        //    using (var db = new SqlConnection(SIGESPROC.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@unme_Id", id);

        //        var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarUnidadDeMedida, parameter, commandType: CommandType.StoredProcedure);
        //        result.CodeStatus = ansewer;
        //        return result;
        //    }
        //}

        public RequestStatus Delete(int? id)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado
            RequestStatus result = new RequestStatus();

            // Usamos una conexión a la base de datos SQL
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();

                // Añadimos el parámetro "unme_Id" con el valor del ID proporcionado
                parameter.Add("@unme_Id", id);

                try
                {
                    // Ejecutamos el procedimiento almacenado "EliminarUnidadDeMedida" y obtenemos el primer resultado como un objeto anónimo
                    var answer = db.QueryFirst<dynamic>(ScriptsDataBase.EliminarUnidadDeMedida, parameter, commandType: CommandType.StoredProcedure);

                    // Asignamos los valores devueltos a la instancia de RequestStatus
                    result.CodeStatus = answer.CodeStatus;
                    result.MessageStatus = answer.MessageStatus;
                }
                catch (Exception ex)
                {
                    // En caso de error, asignamos el mensaje de error a la instancia de RequestStatus
                    result.CodeStatus = -1;
                    result.MessageStatus = $"Error: {ex.Message}";
                }

                // Devolvemos el resultado de la ejecución del procedimiento almacenado
                return result;
            }
        }
        public tbUnidadesMedida Find(int? id)
        {
            tbUnidadesMedida result = new tbUnidadesMedida();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@unme_Id", id);
                result = db.QueryFirst<tbUnidadesMedida>(ScriptsDataBase.BuscarUnidadDeMedida, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbUnidadesMedida item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@unme_Nombre", item.unme_Nombre);
                parameter.Add("@unme_Nomenclatura", item.unme_Nomenclatura);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@unme_FechaCreacion", item.unme_FechaCreacion);
                parameter.Add("@unme_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarUnidadDeMedida, parameter, commandType: CommandType.StoredProcedure);
                int unme_Id = 0;
                unme_Id = parameter.Get<int>("unme_Id");
                result.CodeStatus = ansewer;
                result.MessageStatus = unme_Id.ToString();
                return result;
            }
        }

        public IEnumerable<tbUnidadesMedida> List()
        {
            List<tbUnidadesMedida> result = new List<tbUnidadesMedida>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbUnidadesMedida>(ScriptsDataBase.ListarUnidadesDeMedidas, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbUnidadesMedida> List(int id)
        {
            List<tbUnidadesMedida> result = new List<tbUnidadesMedida>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@insu_Id", id);
                result = db.Query<tbUnidadesMedida>(ScriptsDataBase.ListarInsumosPorMedidas, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbUnidadesMedida item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@unme_Id", item.unme_Id);
                parameter.Add("@unme_Nombre", item.unme_Nombre);
                parameter.Add("@unme_Nomenclatura", item.unme_Nomenclatura);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@unme_FechaModificacion", item.unme_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarUnidadDeMedida, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
