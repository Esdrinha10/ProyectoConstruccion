using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using SIGESPROC.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.Common.Models.ModelsProyecto;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class GestionAdicionalRepository : IRepository<tbGestionesAdicionales>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@adic_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarGestionAdicional, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public virtual RequestStatus Insert(tbGestionesAdicionales item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@adic_Descripcion", item.adic_Descripcion);
                parameter.Add("@adic_Fecha", item.adic_Fecha);
                parameter.Add("@adic_PresupuestoAdicional", item.adic_PresupuestoAdicional);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@adic_FechaCreacion", DateTime.Now);
                parameter.Add("@adic_Estado", 1);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarGestionAdicional, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public tbGestionesAdicionales Find(int? id)
        {
            tbGestionesAdicionales result = new tbGestionesAdicionales();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.QueryFirst<tbGestionesAdicionales>(ScriptsDataBase.BuscarGestionAdicional, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Update(tbGestionesAdicionales item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@adic_Id", item.adic_Id);
                parameter.Add("@adic_Descripcion", item.adic_Descripcion);
                parameter.Add("@adic_Fecha", item.adic_Fecha);
                parameter.Add("@adic_PresupuestoAdicional", item.adic_PresupuestoAdicional);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@adic_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarGestionAdicional, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbGestionesAdicionales> List()
        {
            List<tbGestionesAdicionales> result = new List<tbGestionesAdicionales>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbGestionesAdicionales>(ScriptsDataBase.ListarGestionAdicional, commandType: CommandType.Text).ToList();
                return result;
            }
        }


    }
}
