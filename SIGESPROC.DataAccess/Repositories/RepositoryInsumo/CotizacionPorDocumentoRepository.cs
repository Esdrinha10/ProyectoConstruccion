using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    public class CotizacionPorDocumentoRepository : IRepository<tbCotizaciones>
    {
        /// <summary>
        /// Elimina una cotizacion por documento específico por su ID.
        /// </summary>
        /// <param name="id">El ID de la cotizacion por documento a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@copd_Id", id);

                var answer = db.QueryFirst<RequestStatus>(
                    ScriptsDataBase.EliminarCotizacionPorDocumento,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return answer;
            }
        }

        /// <summary>
        /// Busca y obtiene una lista de de los documentos relacionados con la cotizacion
        /// </summary>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa los artículos PDF encontrados.</returns>
        public IEnumerable<tbCotizaciones> ListarPDF(int coti)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", coti);

                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarCotizacionesPorDocumentosPDF, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
        /// <summary>
        /// Busca y obtiene una lista de de los documentos relacionados con la cotizacion
        /// </summary>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa las imagenes encontradas.</returns>
        public IEnumerable<tbCotizaciones> ListarImagenes(int coti)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", coti);

                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarCotizacionesPorDocumentosImagenes, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
        /// <summary>
        /// Busca y obtiene una lista de de los documentos relacionados con la cotizacion
        /// </summary>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa los artículos Word encontrados.</returns>
        public IEnumerable<tbCotizaciones> ListarWord(int coti)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", coti);

                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarCotizacionesPorDocumentosWord, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
        public tbCotizaciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbCotizaciones item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@copd_Documento", item.copd_Documento);
                parameter.Add("@copd_Descripcion", item.copd_Descripcion);
                parameter.Add("@coti_Id", item.coti_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@copd_FechaCreacion", DateTime.Now);

                var answer = db.QueryFirst<int>(
                    ScriptsDataBase.InsertarCotizacionPorDocumento,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = answer > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = answer, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbCotizaciones> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbCotizaciones item)
        {
            throw new NotImplementedException();
        }
    }
}
