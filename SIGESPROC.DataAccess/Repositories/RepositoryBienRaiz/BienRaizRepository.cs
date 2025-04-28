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
    public class BienRaizRepository : IRepository<tbBienesRaices>
    {

        /// <summary>
        /// Elimina una  Bien Raiz específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la  Bien Raiz a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();

                parametro.Add("bien_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarBienRaiz,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbBienesRaices> DocumentoPorBienRaiz(int coti)
        {
            List<tbBienesRaices> result = new List<tbBienesRaices>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bien_Id", coti);
                result = db.Query<tbBienesRaices>(ScriptsDataBase.DocuemntoPorBienRaizListar, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Busca y devuelve una  Bien Raiz específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la  Bien Raiz a buscar.</param>
        /// <returns>Un objeto tbBienRaiz que representa la  Bien Raiz encontrada.</returns>
        public tbBienesRaices Find(int? id)
        {
            tbBienesRaices result = new tbBienesRaices();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bien_Id", id);
                result = db.QueryFirst<tbBienesRaices>(ScriptsDataBase.BuscarBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo  Bien Raiz en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tb Bien Raiz que contiene los datos de la nueva  Bien Raiz.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Insert(tbBienesRaices item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bien_Desripcion", item.bien_Desripcion);
                parameter.Add("@pcon_Id", item.pcon_Id);
                parameter.Add("@bien_Imagen", item.bien_Imagen);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@bien_FechaCreacion", item.bien_FechaCreacion);
                parameter.Add("@bien_Precio", item.bien_Precio);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de  Bienes Raices .
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbBien Raiz que representa el  Bien Raiz encontrados.</returns>
        public IEnumerable<tbBienesRaices> List()
        {
            List<tbBienesRaices> result = new List<tbBienesRaices>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbBienesRaices>(ScriptsDataBase.ListarBienesRaices, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza los datos de una  Bien Raiz existente.
        /// </summary>
        /// <param name="item">El objeto tb Bien Raiz que contiene los datos actualizados del  Bien Raiz.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbBienesRaices item)
        {   
            RequestStatus result = new RequestStatus();
        
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bien_Id", item.bien_Id);
                parameter.Add("@bien_Desripcion", item.bien_Desripcion);
                parameter.Add("@bien_Imagen", item.bien_Imagen);
                parameter.Add("@pcon_Id", item.pcon_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@bien_FechaModificacion", item.bien_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        public RequestStatus DesactivarIdentificador(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bien_Id", id);
                var answer = db.QueryFirst<int>(ScriptsDataBase.DesactivarIdentificadorbienraiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }


    }
}
