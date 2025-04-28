using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class ReferenciasRepository : IRepository<tbReferenciasCeldas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Eliminar(tbReferenciasCeldas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("rece_Referencia", item.rece_Referencia);
                parametro.Add("rece_Tipo", item.rece_Tipo);
                parametro.Add("acet_Id", item.acet_Id);
                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.ReferenciasCeldasEliminar,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbReferenciasCeldas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbReferenciasCeldas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("rece_Referencia", item.rece_Referencia);
                parametro.Add("rece_Tipo", item.rece_Tipo);
                parametro.Add("acet_Id", item.acet_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("rece_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.ReferenciasCeldasInsertar,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbReferenciasCeldas> List()
        {
            List<tbReferenciasCeldas> result = new List<tbReferenciasCeldas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbReferenciasCeldas>(ScriptsDataBase.ReferenciasCeldasListar, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbReferenciasCeldas item)
        {
            throw new NotImplementedException();
        }
    }
}
