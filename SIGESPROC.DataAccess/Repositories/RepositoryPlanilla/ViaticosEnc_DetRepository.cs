using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGESPROC.Common.Models.ModelsPlanilla;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class ViaticosEnc_DetRepository : IRepository<ViaticosEnc_Det>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public ViaticosEnc_Det Find(int? vien_Id)
        {
            ViaticosEnc_Det result = new ViaticosEnc_Det();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@vien_Id", vien_Id);
                result = db.QueryFirst<ViaticosEnc_Det>(ScriptsDataBase.BuscarViaticosEncDet, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public RequestStatus Insert(ViaticosEnc_Det item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViaticosEnc_Det> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(ViaticosEnc_Det item)
        {
            throw new NotImplementedException();
        }
    }
}
