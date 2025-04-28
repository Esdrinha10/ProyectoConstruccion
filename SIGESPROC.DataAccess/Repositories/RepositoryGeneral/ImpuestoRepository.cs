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
    public class ImpuestoRepository : IRepository<tbImpuestos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbImpuestos Find(int? id)
        {
            tbImpuestos result = new tbImpuestos();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@impu_Id", id);

                // Ejecutamos el procedimiento almacenado para buscar el impuesto y obtenemos el primer resultado
                result = db.QueryFirst<tbImpuestos>(ScriptsDataBase.BuscarImpuestos, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(tbImpuestos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbImpuestos> List()
        {
            List<tbImpuestos> result = new List<tbImpuestos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecutamos la consulta para listar los impuestos y convertimos el resultado a una lista
                result = db.Query<tbImpuestos>(ScriptsDataBase.ListarImpuestos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbImpuestos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@impu_Id", item.impu_Id);
                parameter.Add("@impu_Porcentaje", item.impu_Porcentaje);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@impu_FechaModificacion", DateTime.Now);

                // Ejecutamos el procedimiento almacenado para actualizar el impuesto y obtenemos el primer resultado
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImpuestos, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
