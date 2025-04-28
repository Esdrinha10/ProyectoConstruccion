using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz
{
    public class MantenimientoRepository : IRepository<tbMantenimientos>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@mant_Id", id);
                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarClienteProcesosVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public tbMantenimientos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public tbClientes Buscar(string id)
        {
            tbClientes result = new tbClientes();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@clie_DNI", id);

                // Ejecución del procedimiento almacenado para buscar el proceso de venta.
                result = db.QueryFirst<tbClientes>(ScriptsDataBase.BuscarClienteProcesosVenta, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(tbMantenimientos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@mant_DNI", item.mant_DNI);
                parameter.Add("@mant_NombreCompleto", item.mant_NombreCompleto);
                parameter.Add("@mant_Telefono", item.mant_Telefono);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@mant_FechaCreacion", DateTime.Now);

                // Ejecución del procedimiento almacenado para insertar el proceso de venta.
                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarClienteProcesosVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public IEnumerable<tbMantenimientos> List()
        {
            List<tbMantenimientos> result = new List<tbMantenimientos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecución del procedimiento almacenado para listar todos los procesos de venta.
                result = db.Query<tbMantenimientos>(ScriptsDataBase.ListarClienteProcesosVenta, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbMantenimientos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@mand_Id", item.mant_Id);
                parameter.Add("@mant_DNI", item.mant_DNI);
                parameter.Add("@mant_NombreCompleto", item.mant_NombreCompleto);
                parameter.Add("@mant_Telefono", item.mant_Telefono);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@mant_FechaModificacion", item.mant_FechaModificacion);

                // Ejecución del procedimiento almacenado para actualizar el proceso de venta.
                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarClienteProcesosVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        public object Update(tbAgentesBienesRaices item)
        {
            throw new NotImplementedException();
        }
    }
}
