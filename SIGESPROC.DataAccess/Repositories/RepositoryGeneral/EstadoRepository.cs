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
    public class EstadoRepository : IRepository<tbEstados>
    {

        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@esta_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarEstado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public tbEstados Find(int? id)
        {
            tbEstados result = new tbEstados();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@esta_Id", id);
                result = db.QueryFirst<tbEstados>(ScriptsDataBase.BuscarEstado, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbEstados item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@esta_Codigo", item.esta_Codigo);
                parameter.Add("@esta_Nombre", item.esta_Nombre);
                parameter.Add("@pais_Id", item.pais_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@esta_FechaCreacion", item.esta_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEstado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public IEnumerable<tbEstados> DropDown()
        {
            List<tbEstados> result = new List<tbEstados>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEstados>(ScriptsDataBase.DropDownEstados, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbEstados> List()
        {
            List<tbEstados> result = new List<tbEstados>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEstados>(ScriptsDataBase.ListarEstados, commandType: CommandType.Text).ToList();
                return result;
            }
        }


        public IEnumerable<tbEstados>DropDownEstados() //EstadoPorPais
        {
            List<tbEstados> result = new List<tbEstados>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEstados>(ScriptsDataBase.DropDownEstados, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbEstados> EstadoPorPais(int? id) //EstadoPorPais
        {
            List<tbEstados> result = new List<tbEstados>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("pais_Id", id);

                result = db.Query<tbEstados>(ScriptsDataBase.EstadoPorPais, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
        public virtual RequestStatus Update(tbEstados item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@esta_Id", item.esta_Id);
                parameter.Add("@esta_Codigo", item.esta_Codigo);
                parameter.Add("@esta_Nombre", item.esta_Nombre);
                parameter.Add("@pais_Id", item.pais_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@esta_FechaModificacion", item.esta_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEstado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
