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
    public class CiudadRepository : IRepository<tbCiudades>
    {

        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("@ciud_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarCiudades,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbCiudades Find(int? id)
        {
            tbCiudades result = new tbCiudades();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ciud_Id", id);
                result = db.QueryFirst<tbCiudades>(ScriptsDataBase.BuscarCiudades, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbCiudades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ciud_Codigo", item.ciud_Codigo);
                parameter.Add("@ciud_Descripcion", item.ciud_Descripcion);
                parameter.Add("@esta_Id", item.esta_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@ciud_FechaCreacion", item.ciud_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarCiudades, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        public IEnumerable<tbCiudades> DropDown()
        {
            List<tbCiudades> result = new List<tbCiudades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCiudades>(ScriptsDataBase.DropDownCiudades, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        public IEnumerable<tbCiudades> List()
        {
            List<tbCiudades> result = new List<tbCiudades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCiudades>(ScriptsDataBase.ListarCiudades, commandType: CommandType.Text).ToList();
                return result;
            }
        }



        public IEnumerable<tbCiudades> CiudadPorEstado(int? id)
        {
            List<tbCiudades> result = new List<tbCiudades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            { var parameters = new DynamicParameters();
                parameters.Add("esta_Id", id);

                result = db.Query<tbCiudades>(ScriptsDataBase.CiudadPorEstado, parameters, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public virtual RequestStatus Update(tbCiudades item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ciud_Id", item.ciud_Id);
                parameter.Add("@ciud_Codigo", item.ciud_Codigo);
                parameter.Add("@ciud_Decripcion", item.ciud_Descripcion);
                parameter.Add("@esta_Id", item.esta_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@ciud_FechaModificiacion", item.ciud_FechaModificiacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCiudades, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
