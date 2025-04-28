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
    public class EmpresaBienRaizRepository : IRepository<tbEmpresasBienesRaices>
    {
        //public RequestStatus Delete(int? id)
        //{
        //    RequestStatus result = new RequestStatus();
        //    using (var db = new SqlConnection(SIGESPROC.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@embr_Id", id);

        //        var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarEmpresaBienesRaices, parameter, commandType: CommandType.StoredProcedure);
        //        result.CodeStatus = ansewer;
        //        return result;
        //    }
        //}




        /// <summary>
        /// Elimina una empresa de bienes raíces usando su ID.
        /// </summary>
        /// <param name="id">El ID de la empresa que se desea eliminar.</param>
        /// <returns>El estado de la operación de eliminación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("embr_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEmpresaBienesRaices,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        /// <summary>
        /// Busca una empresa de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID de la empresa que se desea buscar.</param>
        /// <returns>La empresa de bienes raíces encontrada.</returns>
        public tbEmpresasBienesRaices Find(int? id)
        {
            tbEmpresasBienesRaices result = new tbEmpresasBienesRaices();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@embr_Id", id);

                result = db.QueryFirst<tbEmpresasBienesRaices>(ScriptsDataBase.BuscarEmpresaBienesRaices, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta una nueva empresa de bienes raíces en la base de datos.
        /// </summary>
        /// <param name="item">Los detalles de la empresa que se desea agregar.</param>
        /// <returns>El estado de la operación de inserción.</returns>
        public virtual RequestStatus Insert(tbEmpresasBienesRaices item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@embr_Nombre", item.embr_Nombre);
                parameter.Add("@embr_ContactoA", item.embr_ContactoA);
                parameter.Add("@embr_ContactoB", item.embr_ContactoB);
                parameter.Add("@embr_TelefonoA", item.embr_TelefonoA);
                parameter.Add("@embr_TelefonoB", item.embr_TelefonoB);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@embr_FechaCreacion", item.embr_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarEmpresaBienesRaices, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las empresas de bienes raíces.
        /// </summary>
        /// <returns>Lista de empresas de bienes raíces disponibles.</returns>
        public IEnumerable<tbEmpresasBienesRaices> List()
        {
            List<tbEmpresasBienesRaices> result = new List<tbEmpresasBienesRaices>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEmpresasBienesRaices>(ScriptsDataBase.ListarEmpresaBienesRaices, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza la información de una empresa de bienes raíces existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada de la empresa.</param>
        /// <returns>El estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbEmpresasBienesRaices item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@embr_Id", item.embr_Id);
                parameter.Add("@embr_Nombre", item.embr_Nombre);
                parameter.Add("@embr_ContactoA", item.embr_ContactoA);
                parameter.Add("@embr_ContactoB", item.embr_ContactoB);
                parameter.Add("@embr_TelefonoA", item.embr_TelefonoA);
                parameter.Add("@embr_TelefonoB", item.embr_TelefonoB);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@embr_FechaModificacion", item.embr_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEmpresaBienesRaices, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;
                return result;
            }
        }

    }
}
