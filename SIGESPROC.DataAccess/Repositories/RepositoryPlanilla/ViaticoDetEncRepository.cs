using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsPlanilla;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class ViaticoDetEncRepository
    {
        public IEnumerable<ViaticosEnc_Det> Find(int? vien_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@vien_Id", vien_Id);

                return db.Query<ViaticosEnc_Det>(ScriptsDataBase.BuscarViaticosEncDet, parametro, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
